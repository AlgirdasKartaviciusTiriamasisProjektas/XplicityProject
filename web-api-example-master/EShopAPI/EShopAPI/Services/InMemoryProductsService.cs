using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Constants;
using EShopAPI.Contracts.Products;
using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace EShopAPI.Services
{
    public class InMemoryProductsService : IProductsService
    {
        private readonly IList<ProductDto> _items;
        private int _nextId;

        public InMemoryProductsService()
        {
            _items = new List<ProductDto>();
            _nextId = 0;
            Seed();
        }

        public Task<ProductDto> GetById(int id)
        {
            return Task.FromResult(_items.SingleOrDefault(x => x.Id == id));
        }

        public Task<ICollection<ProductDto>> GetAll()
        {
            return Task.FromResult((ICollection<ProductDto>)_items.ToArray());
        }

        public Task<ProductDto> Create(NewProductDto newItem)
        {
            var newProduct = new ProductDto
            {
                Created = DateTime.UtcNow,
                Category = newItem.Category,
                Id = _nextId++,
                Quantity = newItem.Quantity,
                LastModified = DateTime.UtcNow,
                Description = newItem.Description,
                Price = newItem.Price,
                Title = newItem.Title
            };

            _items.Add(newProduct);

            return Task.FromResult(newProduct);
        }

        public Task Update(int id, NewProductDto updateData)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new InvalidOperationException($"Item {id} was not found");
            }

            item.Category = updateData.Category;
            item.Quantity = updateData.Quantity;
            item.Description = updateData.Description;
            item.Title = updateData.Title;
            item.Price = updateData.Price;
            item.LastModified = DateTime.UtcNow;

            return Task.CompletedTask;
        }

        public Task<bool> PartialUpdate(int id, JsonPatchDocument<NewProductDto> propertiesToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            var itemToRemove = _items.FirstOrDefault(x => x.Id == id);
            if (itemToRemove == null)
            {
                return Task.FromResult(false);
            }
            _items.Remove(itemToRemove);

            return Task.FromResult(true);
        }

        private void Seed()
        {
            var product1 = new ProductDto
            {
                Created = new DateTime(2018, 7, 21, 15, 2, 3),
                Category = ProductCategory.Phone,
                Id = 1,
                Description = "Samsung 9s",
                Quantity = 5,
                LastModified = new DateTime(2018, 7, 21, 15, 2, 3),
                Price = 900,
                Title = "Samsung 9s Red With extra items"
            };

            var product2 = new ProductDto
            {
                Created = new DateTime(2018, 7, 22, 10, 45, 55),
                Category = ProductCategory.Computer,
                Id = 15,
                Description = "Dell",
                Quantity = 2,
                LastModified = new DateTime(2018, 7, 25, 15, 2, 3),
                Price = 1200,
                Title = "Dell Inspirion"
            };
            var product3 = new ProductDto
            {
                Created = new DateTime(2018, 7, 29, 1, 45, 55),
                Category = ProductCategory.Other,
                Id = 29,
                Description = "Smart Watch",
                Quantity = 0,
                LastModified = new DateTime(2018, 7, 29, 1, 2, 3),
                Price = 99.99m,
                Title = "Smart watch for kids"
            };

            _items.Add(product1);
            _items.Add(product2);
            _items.Add(product3);
            _nextId = 30;
        }
    }
}