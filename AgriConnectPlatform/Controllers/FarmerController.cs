using Microsoft.AspNetCore.Mvc;
using AgriConnectPlatform.Models;
using System.Data.SqlClient;

namespace AgriConnectPlatform.Controllers
{
    public class FarmerController : Controller
    {

        // Displays the FarmerHome view with farmer details
        public ActionResult FarmerHome(int farmerId, string farmerName, string farmerEmail)
        {
            // Assigning the farmer details to ViewBag to use in the view
            ViewBag.farmerId = Farmer.getFarmerID;
            ViewBag.FarmerName = farmerName;
            ViewBag.FarmerEmail = farmerEmail;

            return View();
        }

        // Redirects to the Add Product form in ProductController
        public IActionResult RedirectToAddProduct(int farmerId)
        {
            return RedirectToAction("AddProduct", "Product", new { farmerId });

        }


        // Retrieves and displays a farmer's details by ID
        public IActionResult GetFarmer(int farmerId)
        {
            Farmer farmer = Farmer.GetFarmerById(farmerId);
            if (farmer == null)
            {
                // Returns a 404 Not Found if farmer does not exist
                return NotFound();
            }

            // Passing the farmer object to the view
            return View(farmer);
        }

        // Redirects to the View Products page in ProductController
        public IActionResult RedirectToViewProducts(int farmerId)
        {
            return RedirectToAction("ViewFarmerProducts", "Product", new { farmerId });
        }

        // Displays the AddFarmer view (GET request)
        public IActionResult AddFarmer() 
        {
            return View();
        }

        // Handles the AddFarmer form submission (POST request)
        [HttpPost]
        public IActionResult AddFarmer(string farmerName, string farmerEmail, string farmerPassword)
        {
            try 
            {
                // Add a new farmer to the database
                Farmer.AddFarmer(farmerName, farmerEmail, farmerPassword);
                ViewBag.SuccessMessage = "Farmer has been added successfully!";
            }
            catch (SqlException ex)
            {
                //Log error
                return StatusCode(500, "Internal server error");
            }

            return View();
        }


        // Action method to filter farmers
        [HttpGet]
        public IActionResult FilterFarmers(string name)
        {
            List<Farmer> farmers = Farmer.FilterFarmers(name);
            return View(farmers); 
        }
    }
}
