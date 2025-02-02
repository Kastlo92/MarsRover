using MarsRover.DTOs;
using MarsRover.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveRoverController : ControllerBase
    {
        private readonly IRoverService _roverService;
        public MoveRoverController(IRoverService roverService)
        {
            _roverService = roverService;
        }

        [HttpPost("move")]
        public ActionResult<string> MoveRover([FromBody] RoverMovementRequestDTO request)
        {
            var result = _roverService.Move(request);
            return Ok(result);
        }
    }
}
