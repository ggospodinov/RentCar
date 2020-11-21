using RentCars.Data.Models;
using RentCars.Data.Models.Enums;
using RentCars.Web.ViewModels.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCars.Web.ViewModels.Cars
{
   public class CarDetailInputModel
    {
        public CarDetailInputModel()
        {
            this.Reviews = new HashSet<ReviewInputModel>();
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public GearType GearType { get; set; }

        public decimal PricePerDay { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<ReviewInputModel> Reviews { get; set; }
    }
}
