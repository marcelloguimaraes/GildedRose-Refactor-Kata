namespace csharpcore
{
    public class BackStagePasses : Item
    {
        public BackStagePasses() : base ("Backstage passes to a TAFKAL80ETC concert")
        {
        }

        public override void UpdateQuality()
        {
            if (!CanIncreaseQuality())
            {
                return;
            }

            if (SellIn < 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                Quality += 3;
            }
            else
            {
                Quality += 2;
            }
        }
    }
}
