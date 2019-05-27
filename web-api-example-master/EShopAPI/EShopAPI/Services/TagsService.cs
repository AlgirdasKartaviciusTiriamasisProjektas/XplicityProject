using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EShopAPI.Contracts.Tags;
using EShopAPI.Infrastructure.Database.Models;
using EShopAPI.Infrastructure.Repositories;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class TagsService : ITagsService
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;

        public TagsService(IRepository<Tag> repository, IMapper mapper, ITimeService timeService)
        {
            _repository = repository;
            _mapper = mapper;
            _timeService = timeService;
        }

        public async Task<TagDto> GetById(int id)
        {
            var tag = await _repository.GetById(id);
            var tagDto = _mapper.Map<TagDto>(tag);
            return tagDto;
        }

        public async Task<ICollection<TagDto>> GetAll()
        {
            var tags = await _repository.GetAll();
            var tagDto = _mapper.Map<TagDto[]>(tags);
            return tagDto;
        }

        public async Task<TagDto> Create(NewTagDto newItem)
        {
            if (newItem == null) throw new ArgumentNullException(nameof(newItem));

            var creationDate = _timeService.GetCurrentTime();
            var newTag = _mapper.Map<Tag>(newItem);
            newTag.Created = creationDate;
            await _repository.Create(newTag);
            var tagDto = _mapper.Map<TagDto>(newTag);
            return tagDto;
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
    }
}