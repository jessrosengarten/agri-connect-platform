using Microsoft.AspNetCore.Mvc;

namespace AgriConnectPlatform.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult EmployeeHome(string employeeName, string employeeEmail)
        {
            ViewBag.EmployeeName = employeeName;
            ViewBag.EmployeeEmail = employeeEmail;
            return View();
        }
    
    public IActionResult Index()
        {
            return View();
        }

        // Add the AddFarmer action method
        public IActionResult AddFarmer()
        {
            // Redirect to AddFarmer view
            return RedirectToAction("AddFarmer", "Farmer");
        }

        [HttpGet]
        public IActionResult FilterProducts(string category)
        {
            return RedirectToAction("FilterProductsByCategory", "Product", new { category });
        }

    }
}
