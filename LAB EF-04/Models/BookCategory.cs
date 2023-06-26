using BookShop.Entitites;
using System;

namespace BookShop.Entities
{
    public class BookCategory : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}