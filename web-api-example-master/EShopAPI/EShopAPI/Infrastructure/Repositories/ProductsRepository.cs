using Microsoft.EntityFrameworkCore;
using System.Linq;
using EShopAPI.Infrastructure.Database;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories
{
    public class ProductsRepository: RepositoryBase<Product>
    {
        protected override DbSet<Product> ItemSet { get; }

        public ProductsRepository(EShopDbContext context) : base(context)
        {
            ItemSet = context.Products;
        }

        protected override IQueryable<Product> IncludeDependencies(IQueryable<Product> queryable)
        {
            return queryable.Include(x => x.ProductTag).ThenInclude(x => x.Tag);
        }
    }
}