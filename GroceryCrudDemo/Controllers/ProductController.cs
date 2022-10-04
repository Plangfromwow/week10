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
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult add(Product prod)
        {
            // if field is blank, set a message for it and send them back to the form
            // add method in product controller is where we are 

            bool isValid = true;
            if (prod.name == null)
            {
                ViewBag.NameMessage = "Name is required";
                isValid = false;
            }
            if (prod.description == null)
            {
                ViewBag.DescriptionMessage = "Description is required";
                isValid = false;
            }
            if (prod.price <= 0)
            {
                ViewBag.PriceMessage = "Price must be greater than 0";
                isValid = false;
            }

            if (isValid)
            {
                DAL.InsertProduct(prod);
                return Redirect("/product");
            }
            else
            {
                List<Category> cats = DAL.GetAllCategories();
                return View("addform",cats);
            }
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
           
            ViewData["categories"] = DAL.GetAllCategories();
            return View(DAL.GetOneProduct(id));
        }
        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }

    }
}
