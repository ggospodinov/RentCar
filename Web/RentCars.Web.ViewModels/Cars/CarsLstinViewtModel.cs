using System;
using System.Collections.Generic;
using System.Text;

namespace RentCars.Web.ViewModels.Cars
{
   public class CarsLstinViewtModel
    {
        public IEnumerable<CarDetailInputModel> Cars { get; set; }

        public int PageNumber { get; set; }
    }
}
