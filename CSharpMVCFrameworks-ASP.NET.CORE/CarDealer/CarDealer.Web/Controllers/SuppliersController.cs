using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Suppliers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealer.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        [Route("/suppliers/local")]
        public IActionResult LocalSuppliers()
        {
            var suppliers = this.suppliers.Suppliers();

            return View(new AllSuppliersModel
            {
                Suppliers = suppliers.Where(b => b.IsImporter == false)
            });
        }


        [Route("/suppliers/importer")]
        public IActionResult ImporterSuppliers()
        {
            var suppliers = this.suppliers.Suppliers();

            return View(new AllSuppliersModel
            {
                Suppliers = suppliers.Where(b => b.IsImporter == true)
            });
        }
    }
}
