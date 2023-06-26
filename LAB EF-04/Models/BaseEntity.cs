using System;
namespace BookShop.Entities
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public BaseEntity() { ID = Guid.NewGuid(); }
    }
}