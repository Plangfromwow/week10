using Microsoft.AspNetCore.Mvc;
using Dapper.Contrib.Extensions;
using GroceryCrudDemo.Models;
using Dapper;

namespace GroceryCrudDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Category cat)
        {
            DAL.InsertCategory(cat);
            return Redirect("/category");
        }

        // for the detail page, we need to decide on how to write our code, we have some choices for the URL
        // We could listen for URL like this  http://localhost:7034/category/detail/fruit
        // or we could do this /category/detail/?id=FRUIT where we get the id from the query perramiters
        //public IActionResult Detail(string id)

        //[HttpGet("/category/detail/{id}")] don't need this yet 
        public IActionResult Detail(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult ConfirmDelete(string ID)
        {
            Category category = DAL.GetOneCategory(ID);
            //ViewData["categoryid"] = ID;
            return View(category);
        }


        public IActionResult Delete(string id)
        {
            

            DAL.DeleteCategory(id);
            return Redirect("/category");
        }

        public IActionResult EditForm(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult EditCategory(Category cat)
        {
            DAL.UpdatCategory(cat);
            return Redirect("/category");
        }


    }
}
