using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stylo_Spin.Dtos;
using Stylo_Spin.Models;
using Stylo_Spin.Services.Defination;

namespace Stylo_Spin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _service;

        public SliderController(ISliderService service)
        {
            _service = service;
        }

        // POST: api/Slider/add
        [HttpPost("add")]
        public async Task<IActionResult> AddSlider([FromForm] SliderDto dto)
        {
            if (dto.Image == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Image is required"));

            var slider = await _service.AddSliderAsync(dto);
            return CreatedAtAction(nameof(GetSliderById),
                new { id = slider.Id },
                ApiResponse<TblSlider>.SuccessResponse(slider, "Slider added successfully"));
        }

        // GET: api/Slider/list
        [HttpGet("list")]
        public async Task<IActionResult> GetAllSliders()
        {
            var sliders = await _service.GetAllSlidersAsync();
            return Ok(ApiResponse<List<TblSlider>>.SuccessResponse(sliders, "All sliders retrieved successfully"));
        }

        // GET: api/Slider/get/5
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            try
            {
                var slider = await _service.GetSliderByIdAsync(id);
                return Ok(ApiResponse<TblSlider>.SuccessResponse(slider, "Slider retrieved successfully"));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(ApiResponse<string>.ErrorResponse("Slider not found"));
            }
        }

        // DELETE: api/Slider/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var result = await _service.DeleteSliderAsync(id);
            if (!result)
                return NotFound(ApiResponse<string>.ErrorResponse("Slider not found or already deleted"));

            return Ok(ApiResponse<string>.SuccessResponse("Slider deleted successfully"));
        }
    }
}
