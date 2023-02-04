using SushiWorld.Console.Models;

namespace SushiWorld.Console.Tests.Models
{
    public class ShoppingCartTests
    {
        #region Add

        [Fact]
        public void Add_Given_NullItem_Should_ReturnZero()
        {
            var shoppingCart = new ShoppingCart();

            var result = shoppingCart.Add(item: null!, count: 25);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-10)]
        public void Add_Given_CountIsZeroOrLess_Should_ReturnZero(int countToAdd)
        {
            var shoppingCart = new ShoppingCart();
            var itemToAdd = new PurchaseableItem("itemCode", "itemName", price: 0);

            var result = shoppingCart.Add(itemToAdd, countToAdd);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_Given_CartDoesNotContainItem_Should_InsertNewItem()
        {
            var shoppingCart = new ShoppingCart();
            var itemToAdd = new PurchaseableItem("itemCode", "itemName", price: 0);

            shoppingCart.Add(itemToAdd, count: 1);

            var itemWasAdded = shoppingCart.Items.First().HasSameItemCode(itemToAdd);

            Assert.True(itemWasAdded);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void Add_Given_NewItemIsInserted_Should_InsertCountProvided(int countToAdd)
        {
            var shoppingCart = new ShoppingCart();
            var itemToAdd = new PurchaseableItem("itemCode", "itemName", price: 0);

            shoppingCart.Add(itemToAdd, countToAdd);

            var countOfItems = shoppingCart.Items.First().Count;

            Assert.True(countOfItems == countToAdd);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void Add_Given_ItemIsInserted_Should_ReturnCountOfItemsAdded(int countToAdd)
        {
            var shoppingCart = new ShoppingCart();
            var itemToAdd = new PurchaseableItem("itemCode", "itemName", price: 0);

            var result = shoppingCart.Add(itemToAdd, countToAdd);

            Assert.Equal(countToAdd, result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        [InlineData(10, 53)]
        public void Add_Given_ItemAlreadyExists_Should_IncreaseCount(int countToAddFirst, int countToAddSecond)
        {
            var shoppingCart = new ShoppingCart();
            var itemToAdd = new PurchaseableItem("itemCode", "itemName", price: 0);
            var countExpected = countToAddFirst + countToAddSecond;

            shoppingCart.Add(itemToAdd, countToAddFirst);
            shoppingCart.Add(itemToAdd, countToAddSecond);

            var countOfItems = shoppingCart.Items.First().Count;

            Assert.Equal(countExpected, countOfItems);
        }

        #endregion

    }
}
