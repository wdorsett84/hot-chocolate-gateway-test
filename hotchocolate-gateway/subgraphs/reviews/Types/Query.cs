using reviews.data;

namespace reviews.Types;

[QueryType]
public static class Query
{
    public static IQueryable<Author>? GetAuthors(ReviewContext context)
        => context.Authors.OrderBy(t => t.Name);
}
