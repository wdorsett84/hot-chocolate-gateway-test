namespace reviews.data;

public static class DatabaseHelper
{
    public static async Task SeedDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ReviewContext>();
        if (await context.Database.EnsureCreatedAsync())
        {
            var ada = new Author
            {
                Id = 1,
                Name = "Ada Lovelace"
            };

            var alan = new Author
            {
                Id = 2,
                Name = "Alan Turing"
            };

            await context.Authors.AddRangeAsync(ada, alan);

            await context.Reviews.AddRangeAsync(
                new Review
                {
                    Id = 1,
                    Body = "Love it!",
                    Stars = 5,
                    ProductId = 1,
                    Author = ada
                },
                new Review
                {
                    Id = 2,
                    Body = "Too expensive.",
                    Stars = 1,
                    ProductId = 2,
                    Author = alan
                },
                new Review
                {
                    Id = 3,
                    Body = "Could be better.",
                    Stars = 3,
                    ProductId = 3,
                    Author = ada,
                },
                new Review
                {
                    Id = 4,
                    Body = "Prefer something else.",
                    Stars = 3,
                    ProductId = 2,
                    Author = alan
                });
            await context.SaveChangesAsync();
        }
    }
}
