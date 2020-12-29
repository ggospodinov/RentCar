namespace RentCars.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class AllOrderInputViewModel
    {
       public IEnumerable<MyOrdersViewModel> Orders { get; set; }
    }
}
