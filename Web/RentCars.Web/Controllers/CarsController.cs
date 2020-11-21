namespace RentCars.Web.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Cars;
    using RentCars.Web.ViewModels.Home;

    public class CarsController : BaseController
    {
        private const string TimeAdded = "TimeAdded";
        private const int DefaultPageIndex = 1;
        private const int DefaultCarsPerPage = 9;
        private readonly ICarsService carsService;
        private readonly IMapper mapper;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;

        }

        public IActionResult All(int id = 1)
        {
            var viewModel = new CarsLstinViewtModel
            {

                PageNumber = id,
                Cars = this.carsService.GetAll(id, 6),
            };

            return this.View(viewModel);
        }
    }




    //[HttpPost]
    //    public async Task<IActionResult> Available(SearchCarsViewModel model)
    //    {
    //        if (!this.User.Identity.IsAuthenticated)
    //        {
    //            return this.Redirect("/Identity/Account/Login");
    //        }

    //        if (!this.ModelState.IsValid)
    //        {
    //            return this.RedirectToAction("Index", "Home");
    //        }

    //        var cars = await this.carsService.GetAvailableCars(model.Pickup, model.Return, model.PickupPlace)
    //                                         .ToListAsync();

    //        var viewModel = new AvailableCarsViewModel
    //        {
    //            Cars = cars,
    //            Start = model.Pickup,
    //            End = model.Return,
    //            Days = (model.Return.Date - model.Pickup.Date).TotalDays,
    //            PickUpPlace = model.PickupPlace,
    //            ReturnPlace = model.ReturnPlace,
    //        };

    //        return this.View(viewModel);
    //    }
}
