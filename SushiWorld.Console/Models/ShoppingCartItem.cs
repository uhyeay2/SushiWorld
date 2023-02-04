namespace SushiWorld.Console.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(PurchaseableItem item, int count)
        {
            Item = item;
            Count = count;
        }

        public PurchaseableItem Item { get; set; }

        public int Count { get; set; }

        public bool HasSameItemCode(PurchaseableItem item)
        {
            return Item.ItemCode == item.ItemCode;
        }

    }
}
