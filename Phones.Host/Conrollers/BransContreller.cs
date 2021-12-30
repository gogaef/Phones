using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phones.Domain.Abstractions.Services;
using Phones.Domain.DTOs.Brands;

namespace Phones.Host.Conrollers
{
    [Route("api/brands")]
    public class BransContreller : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BransContreller(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _brandService.Get();
            return Ok(result.Select(x => new BrandDto{ Id = x.Id, Name = x.Name }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _brandService.Create(payload);
            return StatusCode(StatusCodes.Status201Created, new BrandDto {Id = result.Id, Name = result.Name});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _brandService.Delete(id);
            return NoContent();
        }
    }
}