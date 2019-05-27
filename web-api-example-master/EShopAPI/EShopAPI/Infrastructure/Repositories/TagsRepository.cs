using EShopAPI.Infrastructure.Database;
using EShopAPI.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Infrastructure.Repositories
{
    public class TagsRepository : RepositoryBase<Tag>
    {
        protected override DbSet<Tag> ItemSet { get; }

        public TagsRepository(EShopDbContext context) : base(context)
        {
            ItemSet = context.Tags;
        }
    }
}