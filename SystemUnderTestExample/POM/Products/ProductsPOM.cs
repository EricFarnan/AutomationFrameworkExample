using OpenQA.Selenium;

namespace SystemUnderTestExample.POM.Products
{
    public class ProductsPOM
    {
        public By SortSelector => By.CssSelector("select.product_sort_container");

        public By InventoryItems => By.CssSelector("div.inventory_item");
        public By InventoryItemName => By.CssSelector("div.inventory_item_name");
        public By InventoryItemPrice => By.CssSelector("div.inventory_item_price");
        public By AddToCartBtn => By.CssSelector("button.btn_inventory");
        public By RemoveFromCartBtn => By.CssSelector("button.btn_secondary.btn_inventory");
    }
}
