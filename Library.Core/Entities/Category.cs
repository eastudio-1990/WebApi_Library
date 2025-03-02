namespace Library.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        /// <summary>
        /// زیرمجموعه‌های این دسته‌بندی
        /// </summary>
        public ICollection<Category> SubCategories { get; set; } = new HashSet<Category>();

        /// <summary>
        /// لیست کتاب‌های این دسته‌بندی
        /// </summary>
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
