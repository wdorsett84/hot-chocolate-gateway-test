using Microsoft.EntityFrameworkCore;

namespace account.data;

public class AccountContext : DbContext
{
    public AccountContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}