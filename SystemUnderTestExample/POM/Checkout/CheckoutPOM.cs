using OpenQA.Selenium;

namespace SystemUnderTestExample.POM.Checkout
{
    public class CheckoutPOM
    {
        #region Step 1
        public By CancelBtn => By.CssSelector("a.cart_cancel_link");
        public By ContinueBtn => By.CssSelector("input.cart_button");

        public By FirstNameInput => By.CssSelector("input#first-name");
        public By LastNameInput => By.CssSelector("input#last-name");
        public By ZipPostalCodeInput => By.CssSelector("input#postal-code");
        public By InputErrorMsg => By.CssSelector("h3[data-test=\"error\"]");
        #endregion

        #region Overview
        public By ItemName => By.CssSelector(".inventory_item_name");
        public By ItemPrice => By.CssSelector(".inventory_item_price");
        public By CheckoutSubtotal => By.CssSelector(".summary_subtotal_label");
        public By CheckoutTax => By.CssSelector(".summary_tax_label");
        public By CheckoutTotal => By.CssSelector(".summary_total_label");
        public By FinishBtn => By.CssSelector("a.btn_action.cart_button");

        public By CheckoutComplete => By.CssSelector("h2.complete-header");
        #endregion
    }
}
