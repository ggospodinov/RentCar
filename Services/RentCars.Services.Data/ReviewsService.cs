namespace RentCars.Services.Data
{
    using RentCars.Data.Common.Repositories;
    using RentCars.Data.Models;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewRepository;
        private readonly IRepository<Order> orderRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewRepository, IRepository<Order> orderRepository)
        {
            this.reviewRepository = reviewRepository;
            this.orderRepository = orderRepository;
        }
    }
}
