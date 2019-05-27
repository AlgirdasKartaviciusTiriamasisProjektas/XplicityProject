using System;
using System.Collections.Generic;
using EShopAPI.Constants;

namespace EShopAPI.Infrastructure.Database.Models
{
    public class Product: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }

        public ICollection<ProductTag> ProductTag { get; set; }
    }
}
