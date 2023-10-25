using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbacksController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedbackById(uint id)
        {
            var feedback = await _service.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound("Feedback não encontrado.");
            }

            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFeedback(FeedbackDto request)
        {
            try
            {
                await _service.CreateFeedback(request);
                return Ok("Feedback adicionado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedback(uint id, FeedbackDtoUpdate request)
        {
            try
            {
                await _service.UpdateFeedback(id, request);
                return Ok("Feedback atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeedback(uint id)
        {
            try
            {
                await _service.DeleteFeedback(id);
                return Ok("Feedback excluído com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetFeedbackByUserId(uint userId)
        {
            var feedbacks = await _service.GetFeedbackByUserId(userId);
            return Ok(feedbacks);
        }

        [HttpGet("notification/{notificationId}")]
        public async Task<ActionResult> GetFeedbackByNotificationId(uint notificationId)
        {
            var feedbacks = await _service.GetFeedbackByNotificationId(notificationId);
            return Ok(feedbacks);
        }
    }
}
