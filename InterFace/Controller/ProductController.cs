using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace.Controller
{
    internal class ProductController
    {

        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }


        public void GetCount()
        {
            int count = _productService.GetCount();

            Console.WriteLine(count);
        }

        public void SearchByName()
        {
            Console.WriteLine("Add Product Search Text");

            string searchText = Console.ReadLine();

            var result = _productService.Search(searchText);

            foreach (var item in result)
            {
                string data = $"Name: {item.Name}, Price: {item.Price}, Category: {item.Category.Name}";
                Console.WriteLine(data);
            }

        }

        public void GetAll()
        {

            var result = _productService.GetAll();

            foreach (var item in result)
            {
                string data = $"Name: {item.Name}, Price: {item.Price}, Category: {item.Category.Name}";
                Console.WriteLine(data);
            }
        }

        public void GetAvarage()
        {
            var avgPrice = _productService.GetAveragePrice();
            Console.WriteLine(avgPrice);
        }


        public void OrderByDate()
        {
            var result = _productService.OrderByDate();

            foreach (var item in result)
            {
                string data = $"Name: {item.Name}, Price: {item.Price}, Category: {item.Category.Name}";
                Console.WriteLine(data);
            }
        }
    }
}