using System.Runtime.Serialization;

namespace csharpcore
{
    public class Item
    {
        protected const int MaxQualityValue = 50;
        protected const int NormalQualityAdjustment = 1;
        private const int PassDateQualityAdjustment = 2;

        public string Name { get; private set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public virtual void UpdateQuality()
        {
            if (IsNegativeQuality()) return;

            if (SellInDateHasPassed())
            {
                Quality -= PassDateQualityAdjustment;
                return;
            }

            Quality -= NormalQualityAdjustment;
        }

        protected bool SellInDateHasPassed()
        {
            return SellIn < 0;
        }

        protected bool IsNegativeQuality()
        {
            return Quality <= 0;
        }

        public virtual void UpdateSellIn()
        {
            SellIn--;
        }

        protected bool CanIncreaseQuality()
        {
            return Quality < MaxQualityValue;
        }
    }
}
