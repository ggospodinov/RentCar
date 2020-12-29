namespace RentCars.Web.ViewModels.Orders
{
    using System;

    using RentCars.Data.Models.Enums;
    using RentCars.Web.ViewModels.Cars;

    public class OrderDetailsInputModel : CarDetailInputModel
    {
        public string CarModel { get; set; }

        public GearType CarGearType { get; set; }

        public string Email { get; set; }

        public decimal Price { get; set; }

        public DateTime RentStart { get; set; }

        public DateTime RentEnd { get; set; }

        public OrderStatus Status { get; set; }

        public string PickUpLocation { get; set; }

        public string ReturnLocation { get; set; }

        public int? ReviewId { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}
