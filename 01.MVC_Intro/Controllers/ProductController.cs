
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using WebApplicationASPNetDemo.ViewModels.Product;

namespace WebApplicationASPNetDemo.Controllers
{
    using static Seeding.ProductsData;
    public class ProductController : Controller
    {
        public IActionResult All(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return View(Products);
            }
            IEnumerable<ProductViewModel> searchProduct = Products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .ToArray();
            return View(searchProduct);

        }
       
        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products
                .FirstOrDefault(p => p.Id.ToString().Equals(id));
            if (product==null)
            {
                return this.RedirectToAction("All");

            }
            return View(product);
        }
        //return Json 1 variant
        //public IActionResult AllAsJson()
        //{
        //    string jsonText = JsonConvert.SerializeObject(Products, Formatting.Indented );
        //    return Json(jsonText);
        //}

        //return Json2 variant
        public IActionResult AllAsJson()
        {

            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            }); 
        }
        public IActionResult DownloadProductInfo() 
        {
            StringBuilder sb = new();
            foreach (var product in Products)
            {
                sb.AppendLine($"Product with Id: {product.Id}")
                  .AppendLine($"##Product Name: {product.Name}")
                  .AppendLine($"##Price: {product.Price:f2}$")
                  .AppendLine($"____________________________");
            }
            Response.Headers
                .Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/pain");

        }
    }

}
