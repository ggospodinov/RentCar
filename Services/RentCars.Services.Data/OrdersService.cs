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
        private readonly ICarsService carsService;


        public OrdersService(IRepository<Order> ordersRepository, IUsersService usersService, ILocationsService locationsService, ICarsService carsService)
        {
            this.ordersRepository = ordersRepository;
            this.usersService = usersService;
            this.locationsService = locationsService;
            this.carsService = carsService;

        }

        public IEnumerable<AllOrderInput> GetAllOrdersForUser(string email)
        {
            var user = this.usersService.GetUserByEmail(email);

            var orders = ordersRepository.All().OrderByDescending(x => x.CreatedOn).ToList();

            //var orders = user.Orders.OrderByDescending(x => x.CreatedOn).ToList();

            return new List<AllOrderInput>();
        }

        public async Task<bool> MakeOrder(string email, int carId, string startLocation, string returnLocation, decimal price, DateTime startRent, DateTime endRent)
        {

            var userId = this.usersService.GetUserIdByEmail(email);

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
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();

            return true;
        }

        //public ICollection<OrderInputModel> GetAllOrdersForUser(string email)
        //{
        //    var user = this.usersService.GetUserByEmail(email);

        //    if (user is null)
        //    {
        //        return new List<OrderInputModel>();
        //    }

        //    var orders = user.Orders.OrderByDescending(x => x.CreatedOn).ToList();

        //    return this.List<OrderInputModel>(orders);
        //}

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
    }
}
