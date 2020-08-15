using OpenQA.Selenium;

namespace SystemUnderTestExample.POM.Cart
{
    public class CartPOM
    {
        public By CartItems => By.CssSelector("div.cart_item_label");
        public By CartItemNames => By.CssSelector("div.inventory_item_name");
        public By CartItemsPrices => By.CssSelector("div.inventory_item_price");
        public By RemoveFromCartBtns => By.CssSelector("button.cart_button");

        public By ContinueShoppingBtn => By.LinkText("Continue Shopping");
        public By CheckoutBtn => By.CssSelector("a.checkout_button");
    }
}
