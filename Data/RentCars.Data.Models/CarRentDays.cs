namespace RentCars.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RentCars.Data.Common.Models;

    public class CarRentDays : BaseDeletableModel<int>
    {
        [Required]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        public DateTime RentDate { get; set; }
    }
}
