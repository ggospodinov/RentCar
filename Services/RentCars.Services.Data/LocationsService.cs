using RentCars.Data.Common.Repositories;
using RentCars.Data.Models;
using RentCars.Web.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Services.Data
{




    public class LocationsService : ILocationsService

    {
        private readonly IDeletableEntityRepository<Location> locationsRepository;

        public LocationsService(IDeletableEntityRepository<Location> locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        public IEnumerable<LocationInputModel> GetAllLocation()
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

       
        Task ILocationsService.GetIdByName(string startLocation)
        {
            throw new NotImplementedException();
        }
    }
    }

