using PlatformServices.Models;

namespace PlatformServices.Data;

public static class PrepDb
{
    //here i have 2 functions 1-private 2-public

    // prepare the migration

    // In this version, using ensures that servicesScope is automatically
    // disposed of when the code execution leaves the using block.
    // This guarantees that any resources
    // (such as the DbContext or other services) are
    // properly cleaned up once they are no longer needed.
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var servicesScope = app.ApplicationServices.CreateScope();
        var context = servicesScope.ServiceProvider.GetService<AppDbContext>();
        SeedData(context);
    }

    private static void SeedData(AppDbContext context)
    {
        // here i have some code to seed the database
        if (!context.platforms.Any())
        {
            Console.WriteLine("-->Seeding Data...");
            context.platforms.AddRange(
                new Platform()
                {
                    Name = "Platform1",
                    Publisher = "Publisher1",
                    Cost = "Free",
                },
                new Platform()
                {
                    Name = "Platform2",
                    Publisher = "Publisher2",
                    Cost = "Free",
                },
                new Platform()
                {
                    Name = "Platform3",
                    Publisher = "Publisher3",
                    Cost = "Free",
                },
                new Platform()
                {
                    Name = "Platform4",
                    Publisher = "Publisher4",
                    Cost = "Free",
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("-->We already have data");
        }
    }
}
