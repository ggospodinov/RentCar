namespace RentCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

  public interface ILocationsService
    {
        ICollection<string> GetAllLcocationNames();
    }
}
