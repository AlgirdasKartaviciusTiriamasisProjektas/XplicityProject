using AutoMapper;
using EShopAPI.Contracts.Products;
using EShopAPI.Infrastructure.Database.Models;
using EShopAPI.Infrastructure.Repositories;
using EShopAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShopAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;

        public ProductsService(IRepository<Product> repository,
            IMapper mapper, ITimeService timeService)
        {
            _repository = repository;
            _mapper = mapper;
            _timeService = timeService;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _repository.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<ICollection<ProductDto>> GetAll()
        {
            var products = await _repository.GetAll();
            var productsDto = _mapper.Map<ProductDto[]>(products);
            return productsDto;
        }

        public async Task<ProductDto> Create(NewProductDto newItem)
        {
            if (newItem == null) throw new ArgumentNullException(nameof(newItem));

            var product = CreateProductPoco(newItem);
            await _repository.Create(product);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task Update(int id, NewProductDto updateData)
        {
            if (updateData == null) throw new ArgumentNullException(nameof(updateData));

            var itemToUpdate = await _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Product {id} was not found");
            }

            var modificationDate = _timeService.GetCurrentTime();
            _mapper.Map(updateData, itemToUpdate);
            itemToUpdate.LastModified = modificationDate;
            await _repository.Update(itemToUpdate);
        }

        public async Task<bool> PartialUpdate(int id, JsonPatchDocument<NewProductDto> itemPatch)
        {
            if (itemPatch == null) throw new ArgumentNullException(nameof(itemPatch));

            var itemToUpdate = await _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Product {id} was not found");
            }

            // this is recomended way from microsoft if you don't have domain model
            var modificationDate = _timeService.GetCurrentTime();
            var updateData = _mapper.Map<NewProductDto>(itemToUpdate);
            itemPatch.ApplyTo(updateData);
            _mapper.Map(updateData, itemToUpdate);
            itemToUpdate.LastModified = modificationDate;
            var updated = await _repository.Update(itemToUpdate);
            return updated;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
            {
                return false;
            }

            var deleted = await _repository.Delete(item);
            return deleted;
        }

        private Product CreateProductPoco(NewProductDto newItem)
        {
            var creationDate = _timeService.GetCurrentTime();
            var product = _mapper.Map<Product>(newItem);
            product.LastModified = creationDate;
            product.Created = creationDate;
            return product;
        }
    }
}