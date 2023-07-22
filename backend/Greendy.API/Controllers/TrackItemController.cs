using Greendy.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Greendy.API.ViewModels.TrackItem;
using Greendy.API.Helpers;

namespace Greendy.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TrackItemController : ControllerBase
{
    private readonly ITrackItemService _trackItemService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TrackItemController(ITrackItemService trackItemService,
        IWebHostEnvironment webHostEnvironment)
    {
        _trackItemService = trackItemService;
        _webHostEnvironment = webHostEnvironment;
    }


    [HttpGet("get-by-category")]
    public async Task<IActionResult> GetByCategory(Guid categoryId)
    {
        var trackItems = await _trackItemService.GetByCategoryAsync(categoryId);
        return Ok(trackItems);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromForm]AddTrackItemRequest request)
    {
        var webRootPath = _webHostEnvironment.WebRootPath;
        string? savePath = null;
        byte[]? imageBytes = null;
        if (request.Image != null)
        {
            var helper = new FileHelper();
            savePath = Path.Combine(webRootPath, "TrackItem", request.Image.FileName);
            imageBytes = await helper.GetByteArray(request.Image);
        }
        var response = _trackItemService.AddAsync(new Application.DTO.TrackItem.AddTrackItemRequest() {
            Description = request.Description,
            ImageBytes = imageBytes,
            ImagePath = savePath,
            Name = request.Name,
            TrackItemCategoryId = request.TrackItemCategoryId 
        });
        return Ok(response);
    }
    
}
