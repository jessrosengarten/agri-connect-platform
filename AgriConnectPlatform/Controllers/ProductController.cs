using AgriConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AgriConnectPlatform.Controllers
{
    public class ProductController : Controller
    {
        // Action to display the Add Product form
        public IActionResult AddProduct(int farmerId)
        {
            if (farmerId <= 0)
            {
                return BadRequest("Invalid Farmer ID.");
            }

            ViewBag.FarmerID = farmerId;
            return View();
        }


        // Action to handle the form submission for adding a product
        [HttpPost]
        public IActionResult AddProduct(int farmerId, string productName, string description, string category)
        {

            if (farmerId <= 0)
            {
                return BadRequest("Invalid Farmer ID.");
            }

            // Check if the farmer exists
            Farmer farmer = Farmer.GetFarmerById(farmerId);
            if (farmer == null)
            {
                return NotFound("Farmer not found.");
            }

            try
            {
                Product.AddProduct(farmerId, productName, description, category);
                ViewBag.SuccessMessage = "Product has been added successfully!";
            }
            catch (SqlException ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error");
            }

            ViewBag.FarmerID = farmerId;
            return View();

        }


        
        [HttpGet]
        // Action to display the list of products for a specific farmer
        public IActionResult ViewFarmerProducts(int farmerId)
        {
            if (farmerId <= 0)
            {
                return BadRequest("Invalid Farmer ID.");
            }


            // Check if the farmer exists
            Farmer farmer = Farmer.GetFarmerById(farmerId);
            if (farmer == null)
            {
                return NotFound("Farmer not found.");
            }
            try 
            {
                DataTable productsTable = Product.GetProductsByFarmerID(farmerId);
                
                ViewBag.ProductsTable = productsTable;

            }
            catch (SqlException ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error");
            }

            ViewBag.FarmerID = farmerId;
            return View("ViewFarmerProducts"); 
        }

        [HttpGet]
        // Action to display the list of products for a specific farmer
        public IActionResult ViewAllFarmerProducts()
        {
            try
            {
                DataTable productsTable = Product.GetAllProducts();

                ViewBag.ProductsTable = productsTable;
                return View("ViewAllFarmerProducts");
            }
            catch (SqlException ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        // Action to filter products by category
        public IActionResult FilterProductsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Invalid category.");
            }

            try
            {
                DataTable productsTable = Product.FilterProductsByCategory(category);

                ViewBag.ProductsTable = productsTable;
                return View("ViewAllFarmerProducts");
            }
            catch (SqlException ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
