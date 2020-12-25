namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;
    using RentCars.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }
    }
}
