using CarDealer.Services;
using CarDealer.Web.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars)
        {
            this.cars = cars;
        }

        [Route("cars/{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMake
            {
                Cars = cars,
                Make = make
            });
        }

        [Route("cars/{id}/parts")]
        public IActionResult CarWithParts(int id)
        {
            var carWithParts = this.cars.CarWithParts(id);

            return View(carWithParts);
        }
    }
}
