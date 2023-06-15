using Greendy.BLL.Commands.TrackStorageCategory;
using Greendy.BLL.Queries.TrackStorageCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greendy.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TrackStorageCategoriesController :  ControllerBase
{
    private readonly IMediator _mediator;
    public TrackStorageCategoriesController(IMediator mediator)
    {
        _mediator = mediator;   
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateTrackStorageCategoryCommand command, CancellationToken token)
    {
        await _mediator.Send(command, token);
        return Ok();
    }

    [HttpPut("update")] 
    public async Task<IActionResult> Update([FromBody] UpdateTrackStorageCategoryCommand command, CancellationToken token)
    {
        await _mediator.Send(command, token);
        return Ok();
    }

    [HttpGet("get-by-storage")]
    public async Task<IActionResult> GetByStorage([FromQuery] GetTrackStorageCategoriesByStorageQuery query, CancellationToken token)
    {
        var result = await _mediator.Send(query, token);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(DeleteTrackStorageCategoryCommand command, CancellationToken token)
    {
        await _mediator.Send(command, token);
        return NoContent();
    }
}
