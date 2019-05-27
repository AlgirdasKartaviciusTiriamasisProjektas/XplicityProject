using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Contracts;
using EShopAPI.Infrastructure.Database.Models;
using EShopAPI.Infrastructure.Repositories;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class ProductTagsService : IProductTagsService
    {
        private readonly IProductTagRepository _repository;

        public ProductTagsService(IProductTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<int>> GetProductIds(int tagId)
        {
            var productTags = await _repository.GetProductIdsByTagId(tagId);
            var productIds = productTags
                .Select(x => x.ProductId)
                .ToArray();

            return productIds;
        }

        public async Task AddTag(int tagId, NewProductTagDto newProductTag)
        {
            if (newProductTag == null) throw new ArgumentNullException(nameof(newProductTag));

            var productTag = new ProductTag
            {
                ProductId = newProductTag.ProductId,
                TagId = tagId
            };
            await _repository.Create(productTag);
        }

        public async Task<bool> RemoveTag(int tagId, int productId)
        {
            var tag = await _repository.GetById(tagId, productId);
            if (tag == null)
            {
                return false;
            }

            var removed = await _repository.Delete(tag);
            return removed;
        }
    }
}