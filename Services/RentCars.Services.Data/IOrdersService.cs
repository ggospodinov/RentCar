namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RentCars.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        IEnumerable<OrderPreviewInputModel> OrderPreviewGetId(string id);

        Task<bool> MakeOrder(string email, int carId, string startLocation, string returnLocation, decimal price, DateTime startRent, DateTime endRent);

        bool UserFinishedOrders(string name);

        IEnumerable<MyOrdersViewModel> All();

        IEnumerable<OrderDetailsInputModel> GetOrderById(string id);
    }
}
