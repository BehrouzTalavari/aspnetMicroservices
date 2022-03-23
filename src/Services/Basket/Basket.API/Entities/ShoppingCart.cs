namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public List<ShoppingCardItem> Items{ get; set; } = new List<ShoppingCardItem>();
        
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(x => x.Quantity * x.Price);
            }
        }
    }
}
