using Greendy.API.ViewModel.TrackStorages;
using Greendy.API.ViewModels.TrackStorages;
using Greendy.Application.DTO.TrackStorage;
using Greendy.Application.Interfaces;
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
        private readonly ITrackStorageService _trackStorageService;

        public TrackStorageController(ITrackStorageService trackStorageService)
        {
            _trackStorageService = trackStorageService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddTrackStorageRequest request)
        {
            request.AuthorName = User.Identity.Name;
            var result = await _trackStorageService.AddAsync(request);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid trackStorageId)
        {
            await _trackStorageService.DeleteAsync(trackStorageId);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTrackStorageRequest request)
        {
            await _trackStorageService.UpdateAsync(request);
            return Ok();
        }

        [HttpGet("get-my")]
        public async Task<IActionResult> GetMy()
        {
            var userName = User.Identity!.Name!;
            var result = await _trackStorageService.GetMyAsync(userName);
            return Ok(result);
        }
    }
}