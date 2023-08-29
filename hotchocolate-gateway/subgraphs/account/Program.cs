using account.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<AccountContext>(
        o => o.UseSqlite("Data Source=data/account.db"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<AccountContext>()
    .AddTypes();

var app = builder.Build();

await DatabaseHelper.SeedDatabaseAsync(app);

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
