using RentCars.Data.Common.Repositories;
using RentCars.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentCars.Services.Data
{
    public class LocationsService : ILocationsService

    {
        private readonly IDeletableEntityRepository<Location> locationRepository;

        public LocationsService(IDeletableEntityRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public ICollection<string> GetAllLcocationNames()
        {
            return this.locationRepository.AllAsNoTracking()
                .Select(x => x.Name).
                ToList();
        }

        
    }
}
