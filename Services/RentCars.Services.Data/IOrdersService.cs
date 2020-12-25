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

        IEnumerable<AllOrderInput> GetAllOrdersForUser(string email);

        // Task CreateAsync(OrderInputViewModel input, string email, string pickUpPlace, string returnPlace);
        bool UserFinishedOrders(string name);
    }
}
