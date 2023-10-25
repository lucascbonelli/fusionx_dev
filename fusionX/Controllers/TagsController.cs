using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;

        public TagsController(ITagService tagService)
        {
            _service = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            return Ok(await _service.GetAllTagsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(uint id)
        {
            var tag = await _service.GetTagByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagDtoCreate tagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTag = await _service.CreateTagAsync(tagDto);
            return CreatedAtAction(nameof(GetTagById), new { id = createdTag.Id }, createdTag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(uint id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }
            await _service.UpdateTagAsync(tag);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(uint id)
        {
            var tag = await _service.GetTagByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            await _service.DeleteTagAsync(id);
            return NoContent();
        }
    }
}
