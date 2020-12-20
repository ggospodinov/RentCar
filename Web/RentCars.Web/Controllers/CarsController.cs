namespace RentCars.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Cars;
    using RentCars.Web.ViewModels.Home;

    public class CarsController : BaseController
    {
        private const string TimeAdded = "TimeAdded";
        private readonly ICarsService carsService;
        private readonly ILocationsService locationsService;




        public CarsController(ICarsService carsService, ILocationsService locationsService)
            {
            this.carsService = carsService;
            this.locationsService = locationsService;
            }

        public IActionResult All(int id = 1)
        {

            const int ItemsPerPage = 6;
            var viewModel = new CarsLstinViewtModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                CarsCount = this.carsService.GetCount(),
                Cars = this.carsService.GetAll(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Available(SearchCarsViewModel model)
        {
        if (!this.User.Identity.IsAuthenticated)
        {
           return this.Redirect("/Identity/Account/Login");
       }

            //   //if (!this.ModelState.IsValid)
            //    //{
            //    //    return this.RedirectToAction("Index", "Home");
            //    //}

        var cars = this.carsService.GetAvailableCars(model.Pickup, model.Return, model.PickupPlace).ToList();

            //var location = this.locationsService.GetAllLocation().ToList();

           

            var viewModel = new AvailableCarsViewModel
            {
                Cars = cars,
                Start = model.Pickup,
                End = model.Return,
                Days = (model.Return.Date - model.Pickup.Date).TotalDays,

                PickUpPlace= model.PickupPlace,
                ReturnPlace = model.PickupPlace,
            };

            
            

            //foreach(var location in model.Locations.Select(x=>x.Name))
            //{ 
            //var locations = this.locationsService.GetAllLocation();
            //}

        return this.View(viewModel);
        }

        // public IActionResult> Details(int id)
        //{
        //    var car = await this.carsService.FindCar(id);

        //    if (car is null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var viewModel = this.mapper.Map<CarDetailsViewModel>(car);
        //    viewModel.Reviews = this.mapper.Map<List<ReviewViewModel>>(car.Reviews);
        //    return this.View(viewModel);

        //}

        public IActionResult Details(int id)
        {
            const int ItemsPerPage = 1;
            var viewModel = new CarsLstinViewtModel
            {
                Cars = this.carsService.GetAll(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }
    }
}
