namespace csharpcore
{
    public class Conjured : Item
    {
        public Conjured() : base("Conjured")
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
