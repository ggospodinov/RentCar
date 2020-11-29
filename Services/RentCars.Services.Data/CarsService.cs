namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;
    using RentCars.Services.Mapping;
    using RentCars.Web.ViewModels.Cars;
    using RentCars.Web.ViewModels.Locations;

    public class CarsService : ICarsService
    {

        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<Location> locationRepository;

        public CarsService(IDeletableEntityRepository<Car> carsRepository, IDeletableEntityRepository<Location> locationRepository)
        {
            this.carsRepository = carsRepository;
            this.locationRepository = locationRepository;
        }

        public IEnumerable<CarDetailInputModel> GetAll(int page, int itemsPerRege = 6)
        {
            var cars = this.carsRepository.AllAsNoTracking()
                  .OrderBy(x => x.Id)
                  .Skip((page - 1) * itemsPerRege)
                  .Take(itemsPerRege)
                  .Select(x => new CarDetailInputModel
                  {

                      Id = x.Id,
                      Description = x.Description,
                      Model = x.Model,
                      PricePerDay = x.PricePerDay,
                      Image = x.Image,
                      Year = x.Year,
                      GearType = x.GearType,
                      Speed = x.Speed,
                  }).ToList();

            return cars;
        }

        public int GetCount()
        {
            return this.carsRepository.All().Count();
        }

        public IEnumerable<ListCarInputModel> GetAvailableCars(DateTime start, DateTime end, string location)
        {
            var dates = new List<DateTime>();
            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }


            var cars = this.carsRepository.AllAsNoTracking().
                OrderBy(x=>x.LocationId).
                //Where(l => l.Location.Name == location).
                Where(x => x.RentDays.Any(d => dates.Contains(d.RentDate)) == false).
                Select(x => new ListCarInputModel
                {
                    Id = x.Id,
                    Image = x.Image,
                    Description = x.Description,
                    GearType = x.GearType,
                    PricePerDay = x.PricePerDay,
                    Model = x.Model,
                    Location = x.Location.Name,
                    Year = x.Year,
                    Days = dates.Count(),
                    StartRent = start,
                    End = end,
                }).
                ToList();

            return cars;
        }

        public IEnumerable<LocationInputModel> GetLocation(string name)
        {
            var location = this.locationRepository.AllAsNoTracking()
                .Where(x => x.Name == name)
                 .Select(x => new LocationInputModel
                 {
                     Name = x.Name,
                 })
                 .ToList();


            return location;

        }

        public IEnumerable<CarDetailInputModel> GetCarModelById(int id)
        {
            var cars = this.carsRepository.AllAsNoTracking()
                .OrderBy(x => x.Id)
                .Select(x => new CarDetailInputModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Model = x.Model,
                    Image = x.Image,
                    GearType = x.GearType,

                }).ToList();

            return cars;

        }




    }
}

