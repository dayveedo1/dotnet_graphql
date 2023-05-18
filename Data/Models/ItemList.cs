using System.Collections.Generic;

namespace GraphQL.Data.Models
{
    public class ItemList
    {
        public ItemList()
        {
            ItemDataList = new HashSet<ItemData>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemData> ItemDataList { get; set; }
    }
}
