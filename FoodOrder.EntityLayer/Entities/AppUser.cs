using Microsoft.AspNetCore.Identity;

namespace FoodOrder.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
