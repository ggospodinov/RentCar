using RentCars.Data.Models.Enums;
using RentCars.Web.ViewModels.Cars;
using RentCars.Web.ViewModels.Locations;
using RentCars.Web.ViewModels.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCars.Web.ViewModels.Orders
{
   public class OrderInputModel
    {
        public string Id { get; set; }

        public CarDetailInputModel Car { get; set; }

        public string ApplicationUserId { get; set; }

       // public UserDto User { get; set; }

        public decimal Price { get; set; }

        public DateTime RentStart { get; set; }

        public DateTime RentEnd { get; set; }

        public OrderStatus Status { get; set; }

        public int PickUpLocationId { get; set; }

        public LocationInputModel PickUpLocation { get; set; }

        public int ReturnLocationId { get; set; }

        public LocationInputModel ReturnLocation { get; set; }

        public int? ReviewId { get; set; }

        public ReviewInputModel Review { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
