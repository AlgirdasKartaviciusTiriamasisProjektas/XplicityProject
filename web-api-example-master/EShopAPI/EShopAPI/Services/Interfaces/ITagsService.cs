using System.Collections.Generic;
using System.Threading.Tasks;
using EShopAPI.Contracts.Tags;

namespace EShopAPI.Services.Interfaces
{
    public interface ITagsService
    {
        Task<TagDto> GetById(int id);
        Task<ICollection<TagDto>> GetAll();
        Task<TagDto> Create(NewTagDto newItem);
        Task<bool> Delete(int id);
    }
}