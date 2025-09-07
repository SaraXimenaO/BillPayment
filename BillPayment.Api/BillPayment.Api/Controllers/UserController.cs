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

            try
            {
                var createdProductId = await _mediator.Send(userCreateCommand);
                return CreatedAtAction(
                    nameof(CreateUser),
                    new { productId = createdProductId },
                    createdProductId
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while inserting product");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
