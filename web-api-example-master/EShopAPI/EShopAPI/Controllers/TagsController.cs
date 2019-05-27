using EShopAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EShopAPI.Constants;
using EShopAPI.Contracts.Tags;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        [Produces(typeof(TagDto[]))]
        public async Task<IActionResult> Get()
        {
            var orders = await _tagsService.GetAll();

            return Ok(orders);
        }

        [HttpGet("{id}", Name = nameof(RoutingEnum.GetTag))]
        [Produces(typeof(TagDto))]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _tagsService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Produces(typeof(TagDto))]
        public async Task<IActionResult> Post([FromBody] NewTagDto newTag)
        {
            var createdTag = await _tagsService.Create(newTag);
            var tagUri = CreateResourceUri(createdTag.Id);

            return Created(tagUri, createdTag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tagsService.Delete(id);

            return NoContent();
        }

        private Uri CreateResourceUri(int id)
        {
            // ReSharper disable once RedundantAnonymousTypePropertyName
            return new Uri(Url.Link(nameof(RoutingEnum.GetTag), new { id = id }));
        }
    }
}