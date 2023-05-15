using MusicShopc.Models;

namespace MusicShopc.Services
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllSales();
        Task<Sale> CreateSale(Sale sale);
        Task<bool> UpdateSale(int id, Sale updatedSale);
        Task<bool> DeleteSale(int id);
    }

    public class SaleService : ISaleService
    {
        private readonly List<Sale> _sales;

        public SaleService()
        {
            _sales = new List<Sale>
            {
                new Sale {Id = 0, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 1, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 2, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 3, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 4, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 5, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 6, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 7, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 8, ProductId = 1, Amount = 10, Date = new DateTime()},
                new Sale {Id = 9, ProductId = 1, Amount = 10, Date = new DateTime()},
            };
        }

        public async Task<List<Sale>> GetAllSales()
        {
            return await Task.FromResult(_sales);
        }

        public async Task<Sale> CreateSale(Sale sale)
        {
            _sales.Add(sale);
            return await Task.FromResult(sale);
        }

        public async Task<bool> UpdateSale(int id, Sale updatedSale)
        {
            var sale = _sales.FirstOrDefault(s => s.Id == id);
            if (sale == null)
                return false;

            sale.Amount = updatedSale.Amount;
            sale.Date = updatedSale.Date;

            return true;
        }

        public async Task<bool> DeleteSale(int id)
        {
            var sale = _sales.FirstOrDefault(s => s.Id == id);
            if (sale == null)
                return false;

            _sales.Remove(sale);
            return true;
        }
    }


}
