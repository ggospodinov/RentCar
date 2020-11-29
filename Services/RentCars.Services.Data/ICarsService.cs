namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RentCars.Web.ViewModels.Cars;
    using RentCars.Web.ViewModels.Locations;

    public interface ICarsService
    {
        int GetCount();

        IEnumerable<CarDetailInputModel> GetAll(int page, int itemsPerRege = 6);

        IEnumerable<ListCarInputModel> GetAvailableCars(DateTime start, DateTime end, string location);

        IEnumerable<LocationInputModel> GetLocation( string name);

        IEnumerable<CarDetailInputModel> GetCarModelById(int id);

        


    }
}
