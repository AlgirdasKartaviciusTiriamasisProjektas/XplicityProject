using System.Collections.Generic;
using System.Threading.Tasks;
using EShopAPI.Contracts.Products;
using Microsoft.AspNetCore.JsonPatch;

namespace EShopAPI.Services.Interfaces
{
    public interface IProductsService
    {
        Task<ProductDto> GetById(int id);
        Task<ICollection<ProductDto>> GetAll();
        Task<ProductDto> Create(NewProductDto newItem);
        Task Update(int id, NewProductDto updateData);
        Task<bool> PartialUpdate(int id, JsonPatchDocument<NewProductDto> itemPatch);
        Task<bool> Delete(int id);
    }
}
