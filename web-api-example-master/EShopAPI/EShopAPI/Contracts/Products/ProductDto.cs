using System;
using System.Collections.Generic;
using EShopAPI.Constants;
using EShopAPI.Contracts.Tags;

namespace EShopAPI.Contracts.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public ProductCategory Category { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public ICollection<TagDto> Tags { get; set; }
    }
}
