﻿namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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

        public int GetIdByName(string name)
        {
            var location = this.locationsRepository.All().OrderBy(x => x.Id).FirstOrDefault(x => x.Name == name);

            if (location is null)
            {
                return 0;
            }

            return location.Id;
        }
    }
}
