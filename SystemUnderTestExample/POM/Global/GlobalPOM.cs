using OpenQA.Selenium;

namespace SystemUnderTestExample.POM.Global
{
    class GlobalPOM
    {
        public By MenuBtn => By.CssSelector("div.bm-burger-button");
        public By MenuAllItems => By.CssSelector("#inventory_sidebar_link");
        public By MenuLogout => By.CssSelector("#logout_sidebar_link");

        public By ShoppingCartLink => By.CssSelector("a.shopping_cart_link");
        public By ShoppingCartItemCount => By.CssSelector("span.shopping_cart_badge");
    }
}
