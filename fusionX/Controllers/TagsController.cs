using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTags()
        {
            return Ok(await _service.GetAllTagsAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTagById(uint id)
        {
            try
            {
                var tag = await _service.GetTagByIdAsync(id);
                if(tag == null) return NotFound();
                return Ok(tag);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<IActionResult> CreateTag(TagDtoCreate tagDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdTag = await _service.CreateTagAsync(tagDto);
                return CreatedAtAction(nameof(GetTagById), new { id = createdTag.Id }, createdTag);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<IActionResult> UpdateTag(uint id, Tag tag)
        {
            try
            {
                if(id != tag.Id)
                {
                    return BadRequest();
                }
                var flag = await _service.UpdateTagAsync(tag);
                if(!flag)
                {
                    return NotFound("Tag not found!");
                }
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Admin + "," + UserConstraints.Roles.Company)]
        public async Task<IActionResult> DeleteTag(uint id)
        {
            try
            {
                var tag = await _service.GetTagByIdAsync(id);
                if(tag == null)
                {
                    return NotFound();
                }
                await _service.DeleteTagAsync(id);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
