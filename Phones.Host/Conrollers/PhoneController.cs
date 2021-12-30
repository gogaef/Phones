using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phones.Domain.Abstractions.Services;
using Phones.Domain.DTOs.Brands;

namespace Phones.Host.Conrollers
{
    [Route("api/phones")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhoneDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _phoneService.Create(payload);
            var resultDto = new PhoneDto
            {
                Id = result.Id,
                Model = result.Model,
                Brand = result.Brand,
                Price = result.Price,
                Color = result.Color,
                Type = result.Type,
                OSType = result.OSType
            };
            return StatusCode(StatusCodes.Status201Created, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePhoneDto payload)
        {
            var result = await _phoneService.Update(id, payload);
            var resultDto = new PhoneDto
            {
                Id = result.Id,
                Model = result.Model,
                Brand = result.Brand,
                Price = result.Price,
                Color = result.Color,
                Type = result.Type,
                OSType = result.OSType
            };
            return Ok(resultDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _phoneService.Get();
            return Ok(result.Select(x => new PhoneDto
            {
                Id = x.Id,
                Brand = x.Brand,
                Color = x.Color,
                Model = x.Model,
                Price = x.Price,
                Type = x.Type,
                OSType = x.OSType
            }));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _phoneService.Delete(id);
            return NoContent();
        }
    }
}