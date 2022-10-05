using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            List<Presentation> pres = DAL.GetAllPresentations();

            return View(pres);
        }

        public IActionResult AddForm()
        {
            List<Person> pers = DAL.GetAllPeople();
            return View(pers);
        }

        public IActionResult add(Presentation pres)
        {
            bool isValid = true;
            if (pres.booktitle == null)
            {
                ViewBag.TitleMessage = "Book Title is required.";
                isValid = false;
            }
            if (pres.bookauthor == null)
            {
                ViewBag.AuthorMessage = "Book Author is required";
                isValid = false;
            }
            if (pres.genre == null)
            {
                ViewBag.GenreMessage = "Genre is required";
                isValid = false;
            }
            if (pres.presentationdate == null)
            {
                ViewBag.DateMessage = "Date is required";
                isValid = false;
            }

            if (isValid)
            {
                DAL.CreatePresentation(pres);
                return Redirect("/person/index");
            }
            else
            {
                List<Person> pers = DAL.GetAllPeople();
                return View("addform",pers);
            }
        }

        public IActionResult Details(int id)
        {
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult EditForm(int id)
        {
           ViewData["people"] = DAL.GetAllPeople();
            
            return View(DAL.GetOnePresentation(id));
        }
        public IActionResult Edit(Presentation pres)
        {
            DAL.UpdatePresentation(pres);
            return Redirect("/person/index");
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation/index");
        }
    }
}
