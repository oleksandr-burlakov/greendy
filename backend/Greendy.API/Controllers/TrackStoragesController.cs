using Greendy.API.ViewModel.TrackStorages;
using Greendy.API.ViewModels.TrackStorages;
using Greendy.BLL.Commands.TrackStorages;
using Greendy.BLL.Queries.TrackStorage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greendy.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrackStorageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrackStorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            var result = await _mediator.Send(new CreateStorageCommand(model.Name,
                model.Description, User!.Identity!.Name!));
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            await _mediator.Send(new DeleteTrackStorageCommand(model.TrackStorageId,
                model.TrackStorageName));
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {
            await _mediator.Send(new UpdateTrackStorageCommand(model.Id, model.Name, model.Description));
            return Ok();
        }

        [HttpGet("get-my")]
        public async Task<IActionResult> GetMy()
        {
            var userName = User.Identity.Name;
            var result = await _mediator.Send(new GetMyTrackStorageQuery(userName));
            return Ok(result);
        }
    }
}