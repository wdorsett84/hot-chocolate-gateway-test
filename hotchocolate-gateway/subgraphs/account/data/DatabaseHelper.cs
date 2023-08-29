namespace account.data;

public static class DatabaseHelper
{
    public static async Task SeedDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AccountContext>();
        if (await context.Database.EnsureCreatedAsync())
        {
            var ada = new User
            {
                Id = 1,
                Name = "Ada Lovelace",
                Username = "@ada",
                Birthdate = "1815-12-10"
            };

            var alan = new User
            {
                Id = 2,
                Name = "Alan Turing",
                Username = "@alan",
                Birthdate = "1912-06-23"
            };

            await context.Users.AddRangeAsync(ada, alan);
            await context.SaveChangesAsync();
        }
    }
}
