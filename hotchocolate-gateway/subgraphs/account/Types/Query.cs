using account.data;

namespace account.Types;

[QueryType]
public static class Query
{
    public static IQueryable<User>? GetUsers(AccountContext context)
        => context.Users.OrderBy(t => t.Name);
}
