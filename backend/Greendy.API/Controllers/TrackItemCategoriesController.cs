using Greendy.Application.DTO.TrackItemCategory;
using Greendy.Application.Interfaces;
using Greendy.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greendy.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TrackItemCategoriesController :  ControllerBase
{
    private readonly ITrackItemCategoryService _trackItemCategoryService;
    public TrackItemCategoriesController(ITrackItemCategoryService trackItemCategoryService)
    {
        _trackItemCategoryService = trackItemCategoryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddTrackItemCategoryRequest request, CancellationToken token)
    {
        await _trackItemCategoryService.AddAsync(request);
        return Ok();
    }

    [HttpPut("update")] 
    public async Task<IActionResult> Update([FromBody] UpdateTrackItemCategoryRequest request, CancellationToken token)
    {
        await _trackItemCategoryService.UpdateAsync(request);
        return Ok();
    }

    [HttpGet("get-by-storage")]
    public async Task<IActionResult> GetByStorage([FromQuery] Guid trackStorageId, CancellationToken token)
    {
        var result = await _trackItemCategoryService.GetByTrackStorageAsync(trackStorageId);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromQuery] Guid trackItemCategoryId, CancellationToken token)
    {
        await _trackItemCategoryService.DeleteAsync(trackItemCategoryId);
        return NoContent();
    }
}
