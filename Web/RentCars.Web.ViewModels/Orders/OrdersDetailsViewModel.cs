namespace RentCars.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrdersDetailsViewModel
    {
        public IEnumerable<OrderDetailsInputModel> Cars { get; set; }
    }
}
