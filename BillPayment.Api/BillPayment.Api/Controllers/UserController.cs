using MediatR;
using Microsoft.AspNetCore.Mvc;
using BillPayment.Application.Users.Commands;

namespace BillPayment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateCommand userCreateCommand)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProductId = await _mediator.Send(userCreateCommand);
            return CreatedAtAction(
                nameof(CreateUser),
                new { productId = createdProductId },
                createdProductId
            );
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateCommand userUpdateCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(userUpdateCommand);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid user ID.");
            var deleteCommand = new UserDeleteCommand(userId);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
