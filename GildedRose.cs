using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItem()
        {
            foreach (var item in Items)
            {
                item.UpdateSellIn();
                item.UpdateQuality();
            }
        }
    }
}
