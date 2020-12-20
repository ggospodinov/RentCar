namespace RentCars.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;

    using RentCars.Data.Models;
    using RentCars.Data.Models.Enums;
    using RentCars.Services.Mapping;
    using RentCars.Web.ViewModels.Locations;
    using RentCars.Web.ViewModels.Reviews;

    public class ListCarInputModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public GearType GearType { get; set; }

        public decimal PricePerDay { get; set; }

        public string Location { get; set; }

        public DateTime StartRent { get; set; }
        public DateTime End { get; set; }
        public int Days { get; set; }

  
        public virtual ICollection<ReviewInputModel> Reviews { get; set; }


        public virtual ICollection<CarRentDays> RentDays { get; set; }

       

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    throw new NotImplementedException();

        //    //configuration.CreateMap<Car, ListCarInputModel>()
        //    //     .ForMember(x => x.Image, opt =>
        //    //         opt.MapFrom(x =>
        //    //             x.Image.FirstOrDefault().RemoteImageUrl != null ?
        //    //             x.Image.FirstOrDefault().RemoteImageUrl :
        //    //             "/images/recipes/" + x.Image.FirstOrDefault().Id + "." + x.Image.FirstOrDefault().Extension));
        //}
    }
}
