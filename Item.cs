using System.Runtime.Serialization;

namespace csharpcore
{
    public class Item
    {
        protected const int MaxQualityValue = 50;

        public string Name { get; private set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public virtual void UpdateQuality()
        {
            if (IsNegativeQuality())
            {
                return;
            }

            Quality -= 1;

            if (SellIn < 0)
            {
                Quality -= 1;
            }
        }

        public bool IsNegativeQuality()
        {
            return Quality <= 0;
        }

        public virtual void UpdateSellIn()
        {
            SellIn--;
        }

        public bool CanIncreaseQuality()
        {
            return Quality < MaxQualityValue;
        }
    }
}
