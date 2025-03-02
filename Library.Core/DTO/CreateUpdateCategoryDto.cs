using Library.Core.Entities;

namespace Library.Core.DTO
{
    public class CreateUpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
