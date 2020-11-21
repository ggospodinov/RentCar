namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RentCars.Data.Models;
    using RentCars.Web.ViewModels.Cars;

  public interface ICarsService
    {
        Task<bool> AddCar(ListCarInputModel input);

        IEnumerable<CarDetailInputModel> GetAll(int page, int itemsPerRege = 6);

        Task<bool> EditCar(Car car);

        Task<bool> DeleteCar(int id);

        ICollection<ListCarInputModel> GetAvailableCars(DateTime start, DateTime end, string location);

        ICollection<ListCarInputModel> GetAllCars(string orderBy);

        Task<bool> RentCar(DateTime start, DateTime end, int cardId);

        Task<CarDetailInputModel> FindCar(int id);

        Task<CarDetailInputModel> FindCarForEdit(int id);

        Task<string> GetCarModelById(int id);

        Task<bool> IsAlreadyRented(DateTime start, DateTime end, int cardId);
    }
}
