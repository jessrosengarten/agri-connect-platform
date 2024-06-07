using AgriConnectPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AgriConnectPlatform.Controllers
{
    public class LoginController : Controller
    {

        // Returns the login view
        public ActionResult Login()
        {
            return View();
        }


        // Verify the farmer login details
        [HttpPost]
        public ActionResult VerifyLogin(IFormCollection collection) 
        {
            try 
            {
                string email = collection["txtEmail"];
                string password = collection["txtPassword"];

                Farmer farmer = Farmer.GetFarmer(email);
                Employee employee = Employee.GetEmployee(email);

                // Check if the user is a farmer and if the farmer's email and password are correct
                if (farmer != null && farmer.FarmerEmail.Equals(email) && farmer.FarmerPassword.Equals(password))
                {
                    Farmer.getFarmerID = farmer.FarmerID;
                    // Redirect to the Farmer controller's home action
                    return RedirectToAction("FarmerHome", "Farmer", new { farmerId = farmer.FarmerID, farmerName = farmer.FarmerName, farmerEmail = farmer.FarmerEmail });
                }

                // Check if the user is an employee and if the employee's email and password are correct
                else if (employee != null && employee.EmployeeEmail.Equals(email) && employee.EmployeePassword.Equals(password))
                {

                    // Redirect to the Employee controller's home action
                    return RedirectToAction("EmployeeHome", "Employee", new { employeeName = employee.EmployeeName, employeeEmail = employee.EmployeeEmail });
                }

                // If credentials are not correct for either a farmer or an employee, the below message will appear
                else
                {
                    ViewBag.errorMsg = "Invalid Login Details";
                    return View("Login");
                }

            }
            catch (Exception ex) 
            {
                // Notifies user of an exception
                ViewBag.errorMsg = ex.Message;
                return View("Login");
            }
        }

        // Returns the FarmerHome view
        public ActionResult FarmerHome()
        {
            return View();
        }


    }
}
