using Microsoft.AspNetCore.Mvc;
using AgriConnectPlatform.Models;
using System.Data.SqlClient;

namespace AgriConnectPlatform.Controllers
{
    public class FarmerController : Controller
    {

        public ActionResult FarmerHome(int farmerId, string farmerName, string farmerEmail)
        {
            ViewBag.farmerId = Farmer.getFarmerID;
            ViewBag.FarmerName = farmerName;
            ViewBag.FarmerEmail = farmerEmail;

            return View();
        }

        // Action to redirect to the Add Product form
        public IActionResult RedirectToAddProduct(int farmerId)
        {
            return RedirectToAction("AddProduct", "Product", new { farmerId });

        }


        // Action to get a farmer by ID
        public IActionResult GetFarmer(int farmerId)
        {
            Farmer farmer = Farmer.GetFarmerById(farmerId);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // Action to redirect to the View Products page
        public IActionResult RedirectToViewProducts(int farmerId)
        {
            return RedirectToAction("ViewFarmerProducts", "Product", new { farmerId });
        }


        public IActionResult AddFarmer() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFarmer(string farmerName, string farmerEmail, string farmerPassword)
        {
            try 
            {
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
    }
}
