using GraphQL.Data;
using GraphQL.Data.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL.GraphQL
{
    public class Query
    {

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList([ScopedService] ApiDbContext context)
        {
            return context.ItemLists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetData([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}
