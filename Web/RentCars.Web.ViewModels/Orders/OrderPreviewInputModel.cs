namespace RentCars.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderPreviewInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        [Required]
        public DateTime RentStart { get; set; }

        [Required]
        public DateTime RentEnd { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string PickUpPlace { get; set; }

        [Required]
        public string ReturnPlace { get; set; }

        //public string DiscountCode { get; set; } = GlobalConstants.DefaultVoucherCode;

        public int DiscountPercent { get; set; }

        public decimal PriceWithoutDiscount => this.PricePerDay * this.Days;

        public decimal DiscountSum => ((decimal)this.DiscountPercent / 100) * this.PriceWithoutDiscount;

        public decimal TotalPrice => this.PriceWithoutDiscount - this.DiscountSum;
    }
}
