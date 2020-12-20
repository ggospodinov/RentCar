namespace RentCars.Web.ViewModels.Orders
{
    using System;
    using RentCars.Data.Models.Enums;

    public class AllOrderInput
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set;}

        public decimal Price { get; set; }

        public DateTime RentStart { get; set; }

        public DateTime RentEnd { get; set; }

        public OrderStatus Status { get; set; }

        public int PickUpLocationId { get; set; }

        

        public int ReturnLocationId { get; set; }



    }
}
