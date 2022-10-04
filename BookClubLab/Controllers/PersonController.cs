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
            DAL.CreatePerson(per);
            return Redirect("/person");
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
