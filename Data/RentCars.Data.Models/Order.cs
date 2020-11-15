﻿namespace RentCars.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RentCars.Data.Models.Enums;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString().GetHashCode().ToString("x");
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime RentStart { get; set; }

        [Required]
        public DateTime RentEnd { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public int PickUpLocationId { get; set; }

        public virtual Location PickUpLocation { get; set; }

        [Required]
        public int ReturnLocationId { get; set; }

        public virtual Location ReturnLocation { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
