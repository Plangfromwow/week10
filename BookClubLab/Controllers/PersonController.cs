using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> list = DAL.GetAllPeople();
            return View(list);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Person per)
        {
            bool isValid = true;
            if (per.firstname == null)
            {
                ViewBag.FirstNameMessage = "First Name is required.";
                isValid = false;
            }
            if (per.lastname == null)
            {
                ViewBag.LastNameMessage = "Last Name is required.";
                isValid = false;
            }
            if (per.email == null)
            {
                ViewBag.EmailMessage = "Email is required.";
                isValid = false;
            }
            if (isValid)
            {
                DAL.CreatePerson(per);
                return Redirect("/person");
            }
            else
            {
                return View("addform");
            }
        }
        public IActionResult EditForm(int id)
        {
            return View(DAL.GetPerson(id));
        }
        public IActionResult SaveChanges(Person per)
        {
            DAL.UpdatePerson(per);
            return Redirect("/person");
        }
        public IActionResult Details(int id)
        {
            return View(DAL.GetPerson(id));
        }

        public IActionResult Delete(int id)
        {
            DAL.RemovePerson(id);
            return Redirect("/person/");
        }
        
    }
}
