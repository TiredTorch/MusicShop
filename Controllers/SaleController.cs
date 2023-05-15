using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShopc.Models;
using MusicShopc.Services;

namespace MusicShopc.Controllers
{
    [Authorize]
    [Route("api/sales")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAllSales()
        {
            var sales = await _saleService.GetAllSales();
            return Ok(sales);
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> CreateSale(Sale sale)
        {
            var createdSale = await _saleService.CreateSale(sale);
            return CreatedAtAction(nameof(GetAllSales), null, createdSale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, Sale updatedSale)
        {
            var success = await _saleService.UpdateSale(id, updatedSale);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var success = await _saleService.DeleteSale(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }



}
