using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
