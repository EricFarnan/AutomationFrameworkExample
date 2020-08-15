using AutomationFrameworkExample.Helpers;
using System;
using System.Linq;
using SystemUnderTestExample.POM.Checkout;

namespace SystemUnderTestExample.Pages.CheckoutPage
{
    public class CheckoutOverviewPage : BasePage
    {
        private static CheckoutPOM Repo = new CheckoutPOM();

        public static void VerifyCheckoutMath()
        {
            // Get the item prices into a list and remove the $
            var itemPrices = GetTextFromElements(Repo.ItemPrice);
            itemPrices = itemPrices.Select(s => s.Replace("$", "")).ToList();

            // Parse the item prices into double values and generate the subtotal
            double subtotal = 0.00;
            foreach (string price in itemPrices)
                subtotal += double.Parse(price);

            subtotal = Math.Round(subtotal, 2);

            // Calculate tax value based on 8% tax rate
            double tax = 0.00;
            tax = Math.Round(subtotal * 0.08, 2);

            // Calculate the total
            double total = Math.Round(subtotal + tax, 2);

            // Validate fields
            string actualSubtotal = GetTextFromElement(Repo.CheckoutSubtotal);
            string actualTax = GetTextFromElement(Repo.CheckoutTax);
            string actualTotal = GetTextFromElement(Repo.CheckoutTotal);

            if (actualSubtotal != $"Item total: ${subtotal.ToString("0.00")}")
                throw new Exception($"Checkout subtotal expected 'Item total: ${subtotal.ToString("0.00")}' but was '{actualSubtotal}'.");

            if (actualTax != $"Tax: ${tax.ToString("0.00")}")
                throw new Exception($"Checkout tax expected 'Tax: ${tax.ToString("0.00")}' but was '{actualTax}'.");

            if (actualTotal != $"Total: ${total.ToString("0.00")}")
                throw new Exception($"Checkout total expected 'Total: ${total.ToString("0.00")}' but was '{actualTotal}'.");
        }

        public static void Checkout()
        {
            ClickWait(Repo.FinishBtn);

            if (!ValidateText(Repo.CheckoutComplete, "THANK YOU FOR YOUR ORDER"))
                throw new Exception("Checkout complete message was not correct.");
        }
    }
}
