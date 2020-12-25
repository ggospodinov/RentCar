namespace RentCars.Web.Controllers
{
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

        public IActionResult MyOrders(MyOrdersViewModel viewModels)
        {
           var userEmail = this.User.Identity.Name;
           var orders = this.ordersService.GetAllOrdersForUser(userEmail);

            // var viewModel =  MyOrdersViewModel viewModels(orders);
           return this.View(viewModels);
        }

        [HttpPost]
        public IActionResult Preview(OrderPreviewInputModel inputModel)
        {
            return this.View(inputModel);
        }

        [HttpPost]

        public async System.Threading.Tasks.Task<IActionResult> OrderAsync(OrderInputViewModel inputModel)
        {
            var carModel = this.carsService.GetCarModelById(inputModel.Id);

            var user = await this.userManager.GetUserAsync(this.User);

            //var result = this.ordersService.CreateAsync(inputModel, user.Id, user.Email, carModel, inputModel.PickUpPlace, inputModel.ReturnPlace);

            int days = (inputModel.Return - inputModel.PickUp).Days;

            return this.RedirectToAction(nameof(this.MyOrders));
        }
    }
}
