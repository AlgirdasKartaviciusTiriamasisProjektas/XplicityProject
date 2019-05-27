using EShopAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EShopAPI.Configurations
{
    public static class DbHelper
    {
        public static void Initialize(EShopDbContext context)
        {
            context.Database.Migrate();

            //Seed data here if necessary
        }
    }
}
