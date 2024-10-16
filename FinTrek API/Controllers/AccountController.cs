using FinTrek_API.Models;
using FinTrek_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;  // For using Linq methods
using System.Threading.Tasks;

namespace FinTrek_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly FinTrekDBContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService, FinTrekDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Retrieve the role by role name instead of ID
            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name.ToLower() == model.RoleName.ToLower()); // Use ToLower for case-insensitive comparison

            if (role == null)
            {
                return BadRequest("Invalid role name");
            }

            // Assign role and handle subscriptions
            if (role.Name == "Admin" || role.Name == "Dev")
            {
                // Assign Admin/Dev role to the user
                await _userManager.AddToRoleAsync(user, role.Name);
            }
            else
            {
                // Assign subscription role to the user
                await _userManager.AddToRoleAsync(user, role.Name);

                // Retrieve subscription details for the given role
                var subscription = await _context.Subscriptions
                    .FirstOrDefaultAsync(s => s.Name == role.Name);

                if (subscription == null)
                {
                    return BadRequest("Subscription not found for the given role");
                }

                if (model.SubscriptionMonths.HasValue && model.SubscriptionMonths > 0 && model.SubscriptionMonths <= 12)
                {
                    var subscriptionPayment = new SubscriptionPayment
                    {
                        DatePaid = DateTime.UtcNow,
                        Amount = subscription.MonthlyPrice * model.SubscriptionMonths.Value,
                        ValidUntil = DateTime.UtcNow.AddMonths(model.SubscriptionMonths.Value),
                        ApplicationUserId = user.Id,
                        SubscriptionId = subscription.Id
                    };

                    // Save subscription payment to the database
                    await _context.SubscriptionPayments.AddAsync(subscriptionPayment);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest("Invalid number of subscription months");
                }
            }

            return Ok();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = await _userManager.GetRolesAsync(user);

                // Check subscription status if the user has a subscription role
                if (roles.Any(role => role != "Admin" && role != "Dev"))
                {
                    // Ensure you retrieve the subscription payment correctly
                    var subscriptionPayment = await _context.SubscriptionPayments
                        .FirstOrDefaultAsync(sp => sp.ApplicationUserId == user.Id);

                    if (subscriptionPayment != null && subscriptionPayment.ValidUntil > DateTime.UtcNow)
                    {
                        // Subscription is valid
                        var token = await _tokenService.GenerateJwtToken(user);
                        return Ok(new { token, roles });
                    }
                    else
                    {
                        // Subscription is not valid; revert to free role
                        var freeRole = "Free";
                        var token = await _tokenService.GenerateJwtToken(user); // Use existing user information
                        return Ok(new { token, roles = new List<string> { freeRole } });
                    }
                }

                // For Admin/Dev roles
                var adminToken = await _tokenService.GenerateJwtToken(user);
                return Ok(new { token = adminToken, roles });
            }

            return Unauthorized();
        }



        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _context.Roles
                .Select(r => new { r.Id, r.Name })
                .ToListAsync();

            return Ok(roles);
        }

        private decimal CalculateSubscriptionAmount(int months)
        {
            // Implement your logic for calculating subscription amount based on months
            return months * 10; // For example, if the price per month is $10
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string RoleName { get; set; } // RoleName for assigning a role
            public int? SubscriptionMonths { get; set; } // Optional field for subscription duration
        }
    }
}
