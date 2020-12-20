namespace RentCars.Services.Data
{
    using RentCars.Web.ViewModels.Locations;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILocationsService
    {
        IEnumerable<LocationInputModel> GetAllLocation();
        Task GetIdByName(string startLocation);
    }
}
