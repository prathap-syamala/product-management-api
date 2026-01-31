using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs.Franchise;
using ProductApi.DTOs.Franchises;
using ProductApi.Services;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/franchises")]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IFranchiseService franchiseService)
        {
            _franchiseService = franchiseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _franchiseService.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFranchiseDto dto)
        {
            // 1️⃣ DTO validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _franchiseService.CreateAsync(dto);

                return Ok(new
                {
                    message = "Franchise created successfully"
                });
            }
            catch (Exception ex)
            {
                // 2️⃣ Business validation errors
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var franchise = await _franchiseService.GetByIdAsync(id);

            if (franchise == null)
                return NotFound();

            return Ok(franchise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateFranchiseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _franchiseService.UpdateAsync(id, dto);
                return Ok(new { message = "Franchise updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _franchiseService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
