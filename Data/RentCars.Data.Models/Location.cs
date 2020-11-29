namespace RentCars.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RentCars.Data.Common.Models;

    public class Location : BaseDeletableModel<int>
    {

        [Required]
        public string Name { get; set; }
    }
}
