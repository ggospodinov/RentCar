﻿namespace RentCars.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Cars;
    using RentCars.Web.ViewModels.Home;

    public class CarsController : BaseController
    {
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
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

            if (!this.ModelState.IsValid)
               {
               return this.RedirectToAction("Index", "Home");
            }

            var cars = this.carsService.GetAvailableCars(model.Pickup, model.Return, model.PickupPlace).ToList();

            var viewModel = new AvailableCarsViewModel
            {
                Cars = cars,
                Start = model.Pickup,
                End = model.Return,
                Days = (model.Return.Date - model.Pickup.Date).TotalDays,

                PickUpPlace = model.PickupPlace,
                ReturnPlace = model.PickupPlace,
            };

            return this.View(viewModel);
        }

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
