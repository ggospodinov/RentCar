namespace RentCars.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RentCars.Data.Models;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Orders;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly ICarsService carsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(
            ICarsService carsService,
            IOrdersService ordersService,
            UserManager<ApplicationUser> userManager)
        {
            this.carsService = carsService;
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult MyOrders()
        {
            var viewModel = new AllOrderInputViewModel
            {
                Orders = this.ordersService.All(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Preview(OrderPreviewInputModel inputModel)
        {
            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Order(OrderInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var result = await this.ordersService.MakeOrder(this.User.Identity.Name, inputModel.Id, inputModel.PickUpPlace, inputModel.ReturnPlace, inputModel.Price, inputModel.PickUp, inputModel.Return);
            var carModel = this.carsService.GetCarModelById(id: inputModel.Id);
            var days = (inputModel.Return - inputModel.PickUp).Days;

            return this.RedirectToAction(nameof(this.MyOrders));
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var viewModel = new OrdersDetailsViewModel
            {
                Cars = this.ordersService.GetOrderById(id),
            };

            return this.View(viewModel);
        }
    }
}
