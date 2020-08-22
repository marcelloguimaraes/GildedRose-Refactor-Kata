using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
{
    public class GildedRoseFact
    {
        [Fact]
        public void UpdateQuality_Given_Sell_By_Date_Has_Not_Passed_Quality_Should_Decrease_In_One()
        {
            var items = new List<Item>()
            {
                new Item { Name = "foo", SellIn = 10, Quality = 10 },
                new Item { Name = "bar", SellIn = 5, Quality = 10 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].Quality);
            Assert.Equal(9, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_Given_Sell_By_Date_Has_Passed_Quality_Should_Decrease_Twice_As_Fast()
        {
            var items = new List<Item>()
            {
                new Item { Name = "foo", SellIn = -5, Quality = 10 },
                new Item { Name = "bar", SellIn = -1, Quality = 15 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
            Assert.Equal(13, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_Item_Quality_Should_Not_Be_Negative()
        {
            var items = new List<Item>()
            {
                new Item { Name = "foo", SellIn = 5, Quality = 0 },
                new Item { Name = "bar", SellIn = 5, Quality = 0 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();
            Assert.True(items.All(x => x.Quality >= 0));
        }

        [Fact]
        public void UpdateQuality_Given_Aged_Brie_Cheese_Item_Should_Increase_Quality_By_One_As_It_Ages()
        {
            var items = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 },
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Item_Quality_Should_Not_Exceed_Fifty()
        {
            var items = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Given_Sulfuras_Item_Should_Not_Decrease_Quality()
        {
            var items = new List<Item>()
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Given_Sulfuras_Item_Should_Not_Decrease_SellIn()
        {
            var items = new List<Item>()
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 50 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(5, items[0].SellIn);
        }

        [Theory]
        [InlineData(12, 10)]
        [InlineData(13, 5)]
        [InlineData(0, -5)]
        public void UpdateQuality_Given_BackStage_Passes_Item_Should_Increase_Quality_As_It_Ages(int expectedQuantity, int sellIn)
        {
            var items = new List<Item>()
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(expectedQuantity, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Given_Conjured_Item_Should_Decrease_Quality_Twice_As_Fast()
        {
            var items = new List<Item>()
            {
                new Item { Name = "Conjured", SellIn = 5, Quality = 10 }
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
        }
    }
}