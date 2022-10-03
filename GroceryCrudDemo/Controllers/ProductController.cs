using Microsoft.AspNetCore.Mvc;
using Dapper.Contrib.Extensions;
using GroceryCrudDemo.Models;

namespace GroceryCrudDemo.Controllers
{
    public class ProductController : Controller
    {
        // List all products
        public IActionResult Index()
        {
            // can simplify by placing the method in the return value 
            return View(DAL.GetAllProducts());
        }

        // see detail for single product 
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
        }
        // add new product 
        public IActionResult addForm()
        {
            return View();
        }

        public IActionResult add(Product prod)
        {
            DAL.InsertProduct(prod);
            return Redirect("/product");
        }
        // delete a product 
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }
        // edit a product 
        public IActionResult EditForm(int id)
        {
            return View(DAL.GetOneProduct(id));
        }
        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }

    }
}
