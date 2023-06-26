using System.Collections.Generic;
namespace BookShop.Entities
{
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BookCategory> BookCategories { get; set; } = null!;
    }
}
