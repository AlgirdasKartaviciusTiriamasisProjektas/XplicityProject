using System;
using System.Threading.Tasks;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories.InMemory
{
    public class TagsInMemoryRepository : InMemoryRepositoryBase<Tag>
    {
        public override Task<bool> Update(Tag entity)
        {
            throw new InvalidOperationException("It is not possible to update Tag");
        }
    }
}