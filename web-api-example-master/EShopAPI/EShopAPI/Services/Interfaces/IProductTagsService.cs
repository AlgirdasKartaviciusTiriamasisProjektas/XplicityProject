using System.Collections.Generic;
using System.Threading.Tasks;
using EShopAPI.Contracts;

namespace EShopAPI.Services.Interfaces
{
    public interface IProductTagsService
    {
        Task<ICollection<int>> GetProductIds(int tagId);
        Task AddTag(int tagId, NewProductTagDto newProductTag);
        Task<bool> RemoveTag(int tagId, int productId);
    }
}
