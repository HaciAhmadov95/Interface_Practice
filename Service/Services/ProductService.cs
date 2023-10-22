using Domain.Data;
using Domain.Models;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService()
        {
            _context = new AppDbContext();
        }

        public Product[] GetAll()
        {
            return _context.Products();
        }

        public decimal GetAveragePrice()
        {
            var products = _context.Products();
            int productCount = products.Length;
            decimal sumOfPrice = (decimal)products.Sum(m => m.Price);
            return sumOfPrice / productCount;
        }

        public int GetCount()
        {
            var products = _context.Products();
            return products.Length;
        }

        public Product[] OrderByDate()
        {
            return _context.Products().OrderByDescending(m => m.CreatedDate).ToArray();

        }

        public Product[] Search(string searchText)
        {
          return _context.Products().Where(m=>m.Name.Trim().ToLower().Contains(searchText.ToLower())).ToArray();
        }
    }
}
