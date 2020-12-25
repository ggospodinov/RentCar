namespace RentCars.Services
{
    using RentCars.Data.Models;

    public interface IUsersService
    {
        string GetUserIdByEmail(string email);

        ApplicationUser GetUserByEmail(string email);
    }
}
