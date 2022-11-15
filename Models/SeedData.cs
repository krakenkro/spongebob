using Microsoft.EntityFrameworkCore;

namespace SpongeBob.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>());// Подкл к бд
            if (context.Homes.Any())
            {
                return;
            }
            if (context.Friends.Any())
            {
                return;
            }


            context.Homes.AddRange(
                new Home
                {
                    HomeType = "Ананас",
                },
                new Home
                {
                    HomeType = "Черепаха",
                },
                new Home
                {
                    HomeType = "Купол",
                });
            context.Friends.AddRange(
                new SpongeBobFriends
                {
                    FirstName = "SpongeBob",
                    LastName = "SquarePants",
                    Job = "Повар",
                    JobPlace = "Красти Краб",
                    SkinCollor = "желтый",
                    HomeId = 1,
                },
                new SpongeBobFriends
                {
                    FirstName = "Патрик",
                    LastName = "Стар",
                    Job = "нету",
                    JobPlace = "нету",
                    SkinCollor = "Розовый",
                    HomeId = 2,
                },
                new SpongeBobFriends
                {
                    FirstName = "Сэнди",
                    LastName = "Чикс",
                    Job = "Ученый",
                    JobPlace = "Техаса",
                    SkinCollor = "Коричневый",
                    HomeId = 3,
                });

            context.SaveChanges(); // Сохр в бд

        }
    }
}
