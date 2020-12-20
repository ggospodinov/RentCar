using RentCars.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Services.Data
{
  public interface IOrdersService
    {
        IEnumerable<OrderPreviewInputModel> OrderPreviewGetId(string id);

        IEnumerable<AllOrderInput> GetAllOrdersForUser(string email);

        Task<bool> MakeOrder(string email, int carId, string startLocation, string returnLocation, decimal price, DateTime startRent, DateTime endRent);
    }
}
