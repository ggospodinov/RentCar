namespace RentCars.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Locations;

    public class LocationsController : BaseController
    {
        private readonly ILocationsService locatonsService;

        public LocationsController(ILocationsService locatonsService)
        {
            this.locatonsService = locatonsService;
        }


        public IActionResult All()
        {


            var viewModel = new LocationListViewModel
            {
                Locations = this.locatonsService.GetAllLocation(),
            };

            return this.View(viewModel);
        }
    }
}
