namespace csharpcore
{
    public class BackStagePasses : Item
    {
        private const int PassDateAdjustment = 0;

        public BackStagePasses() : base ("Backstage passes to a TAFKAL80ETC concert")
        {
        }

        public override void UpdateQuality()
        {
            if (!CanIncreaseQuality())
            {
                return;
            }

            if (SellInDateHasPassed())
            {
                Quality = PassDateAdjustment;
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
