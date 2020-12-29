namespace RentCars.Services.Data
{
    using System.Collections.Generic;

    using RentCars.Web.ViewModels.Locations;

    public interface ILocationsService
    {
        IEnumerable<LocationInputModel> GetAllLocation(string name);

        ICollection<string> GetAllLocationNames();

        int GetIdByName(string name);
    }
}
