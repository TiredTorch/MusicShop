using Microsoft.AspNetCore.Mvc;
using MusicShopc.Models;
using MusicShopc.Services;

namespace MusicShopc.Controllers
{
    [Route("api/purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAllPurchases()
        {
            var purchases = await _purchaseService.GetAllPurchases();
            return Ok(purchases);
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> CreatePurchase(Purchase purchase)
        {
            var createdPurchase = await _purchaseService.CreatePurchase(purchase);
            return CreatedAtAction(nameof(GetAllPurchases), null, createdPurchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, Purchase updatedPurchase)
        {
            var success = await _purchaseService.UpdatePurchase(id, updatedPurchase);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var success = await _purchaseService.DeletePurchase(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }


}
