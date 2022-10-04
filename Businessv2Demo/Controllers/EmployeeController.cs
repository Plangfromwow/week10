using Microsoft.AspNetCore.Mvc;
using Businessv2Demo.Models;

namespace Businessv2Demo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> emps = DAL.GetAllEmployee();
            return View(emps);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Employee emp)
        {
            DAL.AddEmployee(emp);
            return Redirect("/employee");
        }
    }
}
