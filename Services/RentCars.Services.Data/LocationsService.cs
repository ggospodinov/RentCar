namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;
    using RentCars.Web.ViewModels.Locations;

    public class LocationsService : ILocationsService
    {
        private readonly IDeletableEntityRepository<Location> locationsRepository;

        public LocationsService(IDeletableEntityRepository<Location> locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        public IEnumerable<LocationInputModel> GetAllLocation(string name)
        {
            var locations = this.locationsRepository.AllAsNoTracking().
                 OrderBy(x => x.Name).
                Select(x => new LocationInputModel
                {
                    Name = x.Name,
                })
               .ToList();

            return locations;
        }

        public ICollection<string> GetAllLocationNames()
        {
            return this.locationsRepository.AllAsNoTracking().
                 Select(x => x.Name).
                 ToList();
        }

        //public string GetIdByName(string name)
        //{

        //    return this.locationsRepository.AllAsNoTracking().
        //         .FirstOrDefault(x => x.Name == name)
               
        //}
    }
}
