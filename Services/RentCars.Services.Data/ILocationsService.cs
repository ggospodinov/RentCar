namespace RentCars.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RentCars.Web.ViewModels.Locations;

    public interface ILocationsService
    {
        IEnumerable<LocationInputModel> GetAllLocation(string name);

        ICollection<string> GetAllLocationNames();

        // Task GetIdByName(string startLocation);

        ///*string GetIdByName(string name)*/;
    }
}
