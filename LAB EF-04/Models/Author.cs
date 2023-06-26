using BookShop.Entitites;
using System.Collections.Generic;

namespace BookShop.Entities
{
    public class Author : BaseEntity
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = null!;
    }
}