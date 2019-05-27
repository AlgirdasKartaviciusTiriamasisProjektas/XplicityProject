using System;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories.InMemory
{
    public class ProductsRepository : InMemoryRepositoryBase<Product>
    {
        public ProductsRepository()
        {
            Items.Add(
                new Product()
                {
                    Id = 1
                });

            Items.Add(
                new Product()
                {
                    Id = 2
                });

            NextId = 3;
        }

        public override Task<bool> Update(Product entity)
        {
            var item = Items.FirstOrDefault(x => x.Id == entity.Id);
            if (item == null)
            {
                throw new InvalidOperationException($"Item {entity.Id} was not found");
            }

            item.Category = entity.Category;
            item.Quantity = entity.Quantity;
            item.Description = entity.Description;
            item.Title = entity.Title;
            item.Price = entity.Price;

            return Task.FromResult(true);
        }
    }
}