namespace csharpcore
{
    public class Conjured : Item
    {
        public Conjured() : base("Conjured mana cake")
        {
        }

        public override void UpdateQuality()
        {
            if (IsNegativeQuality())
            {
                return;
            }

            Quality -= 2;
        }
    }
}
