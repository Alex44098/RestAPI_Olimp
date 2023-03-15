/*Инициализация базы данных*/
using Database.DbContextes;

namespace Database
{
    public class DbInitializer
    {
        public static void Initialize(MainDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
