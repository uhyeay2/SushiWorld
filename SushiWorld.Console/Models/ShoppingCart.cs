namespace SushiWorld.Console.Models
{
    public class ShoppingCart
    {
        private readonly List<ShoppingCartItem> _items;

        public ShoppingCart()
        {
            _items = new();
        }

        public List<ShoppingCartItem> Items => _items;

        /// <summary>
        /// Add the item provided to the List of ShoppingCartItems using the count provided. 
        /// Return the number of items added to the List.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Add(PurchaseableItem item, int count)
        {
            if(item == null || count <= 0)
            {
                return 0;
            }

            var itemInCart = _items.FirstOrDefault(i => i.HasSameItemCode(item));

            if(itemInCart == null)
            {
                _items.Add(new ShoppingCartItem(item, count));
            }
            else
            {
                itemInCart.Count += count;
            }

            return count;
        }

    }
}
