using GraphQL.Data;
using GraphQL.Data.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL.GraphQL.Description
{
    public class ItemDatatType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("This model is used as item for the to-do list");

            descriptor.Field(x => x.ItemDataList)
                .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the list an item belongs to");
        }
    }

    public class Resolvers
    {
        public IQueryable<ItemData> GetItems(ItemList itemList, [ScopedService] ApiDbContext context)
        {
            return context.Items.Where(x => x.ListId == itemList.Id);
        }
    }
}
