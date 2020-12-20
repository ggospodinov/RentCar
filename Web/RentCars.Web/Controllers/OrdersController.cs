namespace RentCars.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RentCars.Services.Data;
    using RentCars.Web.ViewModels.Orders;
    using System.Collections.Generic;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly ICarsService carsService;


        public OrdersController(ICarsService carsService, IOrdersService ordersService)
        {
            this.carsService = carsService;
            this.ordersService = ordersService;
        }

        public IActionResult MyOrders(MyOrdersViewModel viewModels)
        {
           var userEmail = this.User.Identity.Name;
            var orders = this.ordersService.GetAllOrdersForUser(userEmail);
        //    var viewModel =  MyOrdersViewModel viewModels(orders);

            return this.View(viewModels);
        }

        [HttpPost]
        public IActionResult Preview(OrderPreviewInputModel inputModel)
        {

            return this.View(inputModel);
        }

        [HttpPost]

        public IActionResult Order(OrderInputViewModel inputModel)
        {
            var carModel = this.carsService.GetCarModelById(inputModel.Id);

            var result = this.ordersService.MakeOrder(this.User.Identity.Name, inputModel.Id, inputModel.PickUpPlace, inputModel.ReturnPlace, inputModel.Price, inputModel.PickUp, inputModel.Return);

            int days = (inputModel.Return - inputModel.PickUp).Days;

            return this.RedirectToAction(nameof(this.MyOrders));
        }
    }
}