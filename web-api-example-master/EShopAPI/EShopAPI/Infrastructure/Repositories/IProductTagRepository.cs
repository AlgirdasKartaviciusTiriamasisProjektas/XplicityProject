using System.Threading.Tasks;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories
{
    public interface IProductTagRepository
    {
        Task<ProductTag> GetById(int tagId, int productId);
        Task Create(ProductTag item);
        Task<bool> Delete(ProductTag item);
        Task<ProductTag[]> GetProductIdsByTagId(int tagId);
    }
}