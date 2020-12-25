namespace RentCars.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RentCars.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {
        public Location()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string Name { get; set; }
    }
}
