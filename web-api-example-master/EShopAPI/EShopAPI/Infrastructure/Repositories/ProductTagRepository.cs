using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Infrastructure.Database;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories
{
    public class ProductTagRepository: IProductTagRepository
    {
        private readonly EShopDbContext _context;

        public ProductTagRepository(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<ProductTag> GetById(int tagId, int productId)
        {
            var productTag = await _context.ProductTags
                .FirstOrDefaultAsync(x => x.TagId == tagId && x.ProductId == productId);
            return productTag;
        }

        public async Task Create(ProductTag item)
        {
            _context.ProductTags.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(ProductTag item)
        {
            _context.ProductTags.Remove(item);

            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

        public async Task<ProductTag[]> GetProductIdsByTagId(int tagId)
        {
            var productTags = await _context.ProductTags.Where(x => x.TagId == tagId).ToArrayAsync();

            return productTags;
        }
    }
}