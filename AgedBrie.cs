namespace csharpcore
{
    public class AgedBrie : Item
    {
        public AgedBrie() : base("Aged Brie")
        {
        }

        public override void UpdateQuality()
        {
            if (CanIncreaseQuality())
            {
                Quality++;
            }
        }
    }
}
