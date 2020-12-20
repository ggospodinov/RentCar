using System;
using System.Collections.Generic;
using System.Text;

namespace RentCars.Web.ViewModels.Locations
{
   public class LocationListViewModel
    {
      public IEnumerable<LocationInputModel> Locations { get; set; }
    }
}
