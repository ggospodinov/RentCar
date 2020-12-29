namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;
    using RentCars.Web.ViewModels.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> ordersRepository;
        private readonly IUsersService usersService;
        private readonly ILocationsService locationsService;

        public OrdersService(IRepository<Order> ordersRepository, IUsersService usersService, ILocationsService locationsService)
        {
            this.ordersRepository = ordersRepository;
            this.usersService = usersService;
            this.locationsService = locationsService;
        }

        public IEnumerable<MyOrdersViewModel> All()
        {
            var orders = this.ordersRepository.AllAsNoTracking().OrderBy(x => x.User.Email).OrderByDescending(x => x.CreatedOn).Select(x => new MyOrdersViewModel
            {
                Id = x.Id,
                CarModel = x.Car.Model,
                PickUpLocation = x.PickUpLocation.Name,
                ReturnLocation = x.ReturnLocation.Name,
                Price = x.Price,
                RentStart = x.RentStart,
                RentEnd = x.RentEnd,
                Status = x.Status,
            }).ToList();

            return orders;
        }

        public IEnumerable<OrderDetailsInputModel> GetOrderById(string id)
        {
            var orders = this.ordersRepository.AllAsNoTracking()
                .OrderBy(x => x.User.Email).OrderByDescending(x => x.CreatedOn).
                Select(x => new OrderDetailsInputModel
            {
                    Id = x.CarId,
                    Email = x.User.Email,
                    PickUpLocation = x.PickUpLocation.Name,
                    ReturnLocation = x.ReturnLocation.Name,
                    RentStart = x.RentStart,
                    RentEnd = x.RentEnd,
                    CarModel = x.Car.Model,
                    Image = x.Car.Image,
                    Description = x.Car.Description,
                    CarGearType = x.Car.GearType,
                    Year = x.Car.Year,
                    Price = x.Price,
            }).ToList();

            return orders;
        }

        public async Task<bool> MakeOrder(string email, int carId, string startLocation, string returnLocation, decimal price, DateTime startRent, DateTime endRent)
       {
           var userId = this.usersService.GetUserIdByEmail(email);

           var pickupLocationId = this.locationsService.GetIdByName(startLocation);
           var returnLocationId = this.locationsService.GetIdByName(returnLocation);
           if (userId is null)
            {
                return false;
            }

           var order = new Order
           {
              ApplicationUserId = userId,
              CarId = carId,
              RentEnd = endRent,
              RentStart = startRent,
              Price = price,
              PickUpLocationId = pickupLocationId,
              ReturnLocationId = returnLocationId,
              Status = RentCars.Data.Models.Enums.OrderStatus.Active,
           };

           await this.ordersRepository.AddAsync(order);
           await this.ordersRepository.SaveChangesAsync();

           return true;
        }

        public IEnumerable<OrderPreviewInputModel> OrderPreviewGetId(string id)
        {
            var orders = this.ordersRepository.AllAsNoTracking()
            .OrderBy(x => x.Id)
            .Select(x => new OrderPreviewInputModel
            {
                Id = x.Id,
                Model = x.Car.Model,
                RentStart = x.RentStart,
                RentEnd = x.RentEnd,
                PricePerDay = x.Price,
                Image = x.Car.Image,
                PickUpPlace = x.Car.Location.Name,
                ReturnPlace = x.Car.Location.Name,
            }).ToList();

            return orders;
        }

        public bool UserFinishedOrders(string name)
        {
            return this.ordersRepository.AllAsNoTracking().
                   Any(x => x.User.UserName == name && x.ReviewId == null);
        }
    }
}
