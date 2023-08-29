using Microsoft.EntityFrameworkCore;
using reviews.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<ReviewContext>(
        o => o.UseSqlite("Data Source=data/review.db"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ReviewContext>()
    .AddTypes();

var app = builder.Build();

await DatabaseHelper.SeedDatabaseAsync(app);

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
