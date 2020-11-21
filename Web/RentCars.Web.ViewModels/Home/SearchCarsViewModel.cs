namespace RentCars.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchCarsViewModel : IValidatableObject
    {
        private const string PickupError = "Pick Up date is invalid!";
        private const string ReturnError = "Return date is invalid!";

        public SearchCarsViewModel()
        {
            this.Pickup = DateTime.UtcNow;
            this.Return = DateTime.UtcNow.AddDays(1);
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Pick Up Date")]
        public DateTime Pickup { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime Return { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Pick Up Place")]
        public string PickupPlace { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Return Place")]
        public string ReturnPlace { get; set; }

        public ICollection<string> Locations { get; set; } = new HashSet<string>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Pickup.Date >= this.Return.Date || this.Pickup.Date < DateTime.UtcNow.Date)
            {
                yield return new ValidationResult(PickupError);
            }

            if (this.Return.Date < DateTime.UtcNow.Date)
            {
                yield return new ValidationResult(ReturnError);
            }
        }
    }
}
