namespace SushiWorld.Console.Models
{
    public class PurchaseableItem
    {
        public PurchaseableItem(string itemCode, string name, double price)
        {
            ItemCode = itemCode;
            Name = name;
            Price = price;
        }

        public string ItemCode { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
