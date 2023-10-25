using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IEventService _event;
        private readonly IAuthService _auth;

        public NotificationsController(INotificationService service, IEventService @event, IAuthService auth)
        {
            _service = service;
            _event = @event;
            _auth = auth;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<NotificationDto?>> GetNotificationByIdAsync(uint id)
        {
            var user = await _service.GetNotificationByIdAsync(id);
            if (user == null) return NotFound("Notificação não encontrada!");

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<ActionResult> CreateNotificationAsync(NotificationDtoInsert request)
        {
            try
            {
                var idUser = await _event.GetUserIdByEvent(request.EventId) ?? 0;
                if (!_auth.HasAccessToUser(HttpContext, idUser)) return Unauthorized($"Acesso ao usuário {idUser} foi negado.");

                await _service.CreateNotificationAsync(request);
                return Ok("Notificação adicionada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<ActionResult> UpdateNotificationAsync(uint id, NotificationDtoUpdate request)
        {
            try
            {
                var idUser = await _service.GetUserIdByNotification(id) ?? 0;
                if (!_auth.HasAccessToUser(HttpContext, idUser)) return Unauthorized($"Acesso ao usuário {idUser} foi negado.");

                await _service.UpdateNotificationAsync(id, request);
                return Ok("Notificação atualizada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<ActionResult> DeleteNotificationAsync(uint id)
        {
            try
            {
                var idUser = await _service.GetUserIdByNotification(id) ?? 0;
                if (!_auth.HasAccessToUser(HttpContext, idUser)) return Unauthorized($"Acesso ao usuário {idUser} foi negado.");

                await _service.DeleteNotificationAsync(id);
                return Ok("Notificação excluída com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("event/{idEvent}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotificationsByEvent(uint idEvent)
        {
            return Ok(await _service.GetNotificationsByEvent(idEvent));
        }

        [HttpGet("user/{idUser}")]
        [Authorize(Roles = UserConstraints.Roles.User)]
        public async Task<ActionResult<NotificationDtoGetUser>> GetNotificationsByUser(uint idUser)
        {
            if (!_auth.HasAccessToUser(HttpContext, idUser)) return Unauthorized($"Acesso ao usuário {idUser} foi negado.");

            return Ok(await _service.GetNotificationsByUser(idUser));
        }

        [HttpGet("user/{idUser}/new")]
        [Authorize(Roles = UserConstraints.Roles.User)]
        public async Task<ActionResult<NotificationDtoGetUser>> GetUnreadNotifications(uint idUser)
        {
            if (!_auth.HasAccessToUser(HttpContext, idUser)) return Unauthorized($"Acesso ao usuário {idUser} foi negado.");

            return Ok(await _service.GetUnreadNotifications(idUser));
        }
    }
}