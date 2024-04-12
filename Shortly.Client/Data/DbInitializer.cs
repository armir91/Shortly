using Shortly.Data;

namespace Shortly.Client.Data
{
    public static class DbInitializer
    {
        public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!dbContext.Users.Any())
                {
                    dbContext.Users.AddRange(new Shortly.Data.Models.User()
                    {
                        FullName = "Armir Keta",
                        Email = "armir.keta@gmail.com"
                    });

                    dbContext.SaveChanges();
                }

                if (!dbContext.Urls.Any())
                {
                    dbContext.Urls.AddRange(new Shortly.Data.Models.Url()
                    {
                        OriginalLink = "https://dotnethow.net",
                        ShortLink = "dnh",
                        NrOfClicks = 20,
                        DateCreated = DateTime.Now,

                        UserId = dbContext.Users.First().Id
                    });

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
