using EvenTech.dtos;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserTagsController : ControllerBase
    {
        private readonly IUserTagService _service;

        public UserTagsController(IUserTagService service)
        {
            _service = service;
        }

        //get
        [HttpGet("tag/{tagId}/user{userId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<UserTagDto?>> GetUserTag(uint tagId, uint userId)
        {
            var userTag = await _service.GetUserTag(tagId, userId);
            if (userTag == null)
            {
                return NotFound("UserTag não encontrada ou a combinação de tagId e userId não corresponde.");
            }

            return Ok(userTag);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> CreateUserTag(UserTagDtoInsert request)
        {
            try
            {
                await _service.CreateUserTag(request);
                return Ok("UserTag efetuada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("tag/{tagId}/user/{userId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> DeleteUserTag(uint tagId, uint userId)
        {
            try
            {
                await _service.DeleteUserTag(tagId, userId);
                return Ok("UserTag removida com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<IEnumerable<UserTagDto>>> GetUserTagsByUserId(uint userId)
        {
            var userTags = await _service.GetUserTagsByUserId(userId);
            return Ok(userTags);
        }

        [HttpGet("tag/{tagId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<IEnumerable<UserTagDto>>> GetUserTagsByTagId(uint tagId)
        {
            var userTags = await _service.GetUserTagsByUserId(tagId);
            return Ok(userTags);
        }


    }
}
