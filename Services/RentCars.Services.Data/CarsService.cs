namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;
    using RentCars.Web.ViewModels.Cars;





    public class CarsService : ICarsService
    {

        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IMapper mapper;

        public CarsService(IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;

        }

        public Task<bool> AddCar(ListCarInputModel input)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> AddCar(ListCarInputModel input)
        //{
        //    var car = new Car
        //    {
        //        Id = input.Id,
        //        Model = input.Model,
        //        Description = input.Description,
        //        Image = input.Image,
        //        InUse = true
        //    };

        //    await this.carsRepository.AddAsync(car);
        //    await this.carsRepository.SaveChangesAsync();
        //    return true;

        //}



        public Task<bool> DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<CarDetailInputModel> FindCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarDetailInputModel> FindCarForEdit(int id)
        {
            throw new NotImplementedException();
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

                 }).ToList();

            return cars;


        }

        public ICollection<ListCarInputModel> GetAllCars(string orderBy)
        {
            throw new NotImplementedException();
        }

        public ICollection<ListCarInputModel> GetAvailableCars(DateTime start, DateTime end, string location)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCarModelById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAlreadyRented(DateTime start, DateTime end, int cardId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RentCar(DateTime start, DateTime end, int cardId)
        {
            throw new NotImplementedException();
        }

        //    public ICollection<ListCarInputModel> GetAllCars(string orderBy)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ICollection<ListCarInputModel> GetAvailableCars(DateTime start, DateTime end, string location)
        //    {
        //        var dates = new List<DateTime>();
        //        for (var dt = start; dt <= end; dt = dt.AddDays(1))
        //        {
        //            dates.Add(dt);
        //        }

        //        var cars = this.carsRepository.All().
        //            Where(l => l.Location.Name == location).
        //            Where(x => x.RentDays.Any(d => dates.Contains(d.RentDate)) == false).
        //            Select(x => new ListCarInputModel
        //            {
        //                Id = x.Id,
        //                Image = x.Image,
        //                Description = x.Description,
        //                GearType = x.GearType,
        //                Location = x.Location.Name,
        //                PricePerDay = x.PricePerDay,
        //                Model = x.Model,
        //                Year = x.Year,
        //                Days = dates.Count(),
        //                StartRent = start,
        //                End = end,
        //            }).
        //            ToList();

        //        return cars;
        //    }

        //    public Task<string> GetCarModelById(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> IsAlreadyRented(DateTime start, DateTime end, int cardId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> RentCar(DateTime start, DateTime end, int cardId)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
