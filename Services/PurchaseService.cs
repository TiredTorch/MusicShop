using MusicShopc.Models;

namespace MusicShopc.Services
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAllPurchases();
        Task<Purchase> CreatePurchase(Purchase purchase);
        Task<bool> UpdatePurchase(int id, Purchase updatedPurchase);
        Task<bool> DeletePurchase(int id);
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly List<Purchase> _purchases;

        public PurchaseService()
        {
            _purchases = new List<Purchase>
            {
                new Purchase {Id = 0, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 1, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 2, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 3, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 4, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 5, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 6, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 7, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 8, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Purchase {Id = 9, ProductId = 1, Amount = 10, Date = new DateTime()},
            };
        }

        public async Task<List<Purchase>> GetAllPurchases()
        {
            return await Task.FromResult(_purchases);
        }

        public async Task<Purchase> CreatePurchase(Purchase purchase)
        {
            _purchases.Add(purchase);
            return await Task.FromResult(purchase);
        }

        public async Task<bool> UpdatePurchase(int id, Purchase updatedPurchase)
        {
            var purchase = _purchases.FirstOrDefault(p => p.Id == id);
            if (purchase == null)
                return false;

            purchase.Amount = updatedPurchase.Amount;
            purchase.Date = updatedPurchase.Date;

            return true;
        }

        public async Task<bool> DeletePurchase(int id)
        {
            var purchase = _purchases.FirstOrDefault(p => p.Id == id);
            if (purchase == null)
                return false;

            _purchases.Remove(purchase);
            return true;
        }
    }


}
