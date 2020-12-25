namespace RentCars.Web.ViewModels.Reviews
{
    public class ReviewListInputModel : ReviewInputModel
    {
        public int Id { get; set; }

        public string CarModel { get; set; }

        public string User { get; set; }
    }
}
