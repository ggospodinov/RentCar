namespace RentCars.Services
{
    using Microsoft.AspNetCore.Identity;
    using RentCars.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return this.userManager.FindByNameAsync(email).GetAwaiter().GetResult();
        }

        public string GetUserIdByEmail(string email)
        {
            var user = this.userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            return user.Id;
        }
    }
}
