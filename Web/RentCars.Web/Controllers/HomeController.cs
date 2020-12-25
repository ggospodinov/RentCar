namespace RentCars.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels;
    using RentCars.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ILocationsService locationsService;
        private readonly IOrdersService ordersService;

        public HomeController(ILocationsService locationsService, IOrdersService ordersService)
        {
            this.locationsService = locationsService;
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            var locationsList = this.locationsService.GetAllLocationNames();

            this.ViewData["FinishedOrders"] = this.ordersService.UserFinishedOrders(this.User.Identity.Name);
            return this.View(new SearchCarsViewModel { Locations = locationsList });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
