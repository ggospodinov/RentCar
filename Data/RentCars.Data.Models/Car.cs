namespace RentCars.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RentCars.Data.Common.Models;
    using RentCars.Data.Models.Enums;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Reviews = new HashSet<Review>();
            this.RentDays = new HashSet<CarRentDays>();
            this.InUse = true;
        }

        public bool InUse { get; set; }

        [Required]
        [MinLength(5)]
        public string Model { get; set; }

        [Required]
        [MinLength(150)]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        [Required]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CarRentDays> RentDays { get; set; }
    }
}
