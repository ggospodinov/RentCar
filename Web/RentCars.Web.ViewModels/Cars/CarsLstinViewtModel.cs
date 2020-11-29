namespace RentCars.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarsLstinViewtModel : PagingViewModel
    {
        public IEnumerable<CarDetailInputModel> Cars { get; set; }

    }
}
