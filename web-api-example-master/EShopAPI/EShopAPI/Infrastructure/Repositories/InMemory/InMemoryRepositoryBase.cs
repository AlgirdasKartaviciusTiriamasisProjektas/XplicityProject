using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Infrastructure.Database.Models;

namespace EShopAPI.Infrastructure.Repositories.InMemory
{
    public abstract class InMemoryRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IList<TEntity> Items;
        protected int NextId;

        protected InMemoryRepositoryBase()
        {
            Items = new List<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await Task.FromResult(Items.ToArray());
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Task.FromResult(Items.SingleOrDefault(x => x.Id == id));
        }

        public async Task<int> Create(TEntity entity)
        {
            entity.Id = NextId;
            NextId++;
            Items.Add(entity);

            return await Task.FromResult(entity.Id);
        }

        public abstract Task<bool> Update(TEntity entity);


        public async Task<bool> Delete(TEntity entity)
        {
            var itemToRemove = Items.FirstOrDefault(x => x.Id == entity.Id);
            if (itemToRemove == null)
            {
                return await Task.FromResult(false);
            }

            Items.Remove(itemToRemove);

            return await Task.FromResult(true);
        }
    }
}