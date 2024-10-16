namespace FinTrek_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }
        public int ParentId { get; set; }
        public Category Parent { get; set; }
    }
}
