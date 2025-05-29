using AgriConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriConnectPlatform.Controllers
{
    public class EmployeeController : Controller
    {
        //Action method to display the EmployeeHome view with emploee details
        public ActionResult EmployeeHome(string employeeName, string employeeEmail)
        {
            // Pass the employee name and email to the view
            ViewBag.EmployeeName = employeeName;
            ViewBag.EmployeeEmail = employeeEmail;
            return View();
        }
    
    public IActionResult Index()
        {
            return View();
        }

        // Action method redirects to the AddFarmer action method in the FarmerController
        public IActionResult AddFarmer()
        {
            // Redirect to AddFarmer view
            return RedirectToAction("AddFarmer", "Farmer");
        }

        // Action method redirects to FilterProductsByCategory action method in the ProductController
        [HttpGet]
        public IActionResult FilterProducts(string category)
        {
            // Redirect to FilterProductsByCategory view
            return RedirectToAction("FilterProductsByCategory", "Product", new { category });
        }



        // Action method to filter farmers
        [HttpGet]
        public IActionResult FilterFarmers(string name, string email)
        {
            return RedirectToAction("FilterFarmers", "Farmer", new { name, email });
        }

    }
}
