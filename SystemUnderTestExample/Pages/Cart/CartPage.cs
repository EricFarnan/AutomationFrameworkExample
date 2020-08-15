using AutomationFrameworkExample.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SystemUnderTestExample.POM.Cart;
using SystemUnderTestExample.POM.Global;

namespace SystemUnderTestExample.Pages.Cart
{
    public class CartPage : BasePage
    {
        private static CartPOM Repo = new CartPOM();
        private static GlobalPOM GlobalRepo = new GlobalPOM();
        
        public static void NavigateToCart() => ClickWait(GlobalRepo.ShoppingCartLink);

        public static void NavigateToCheckout()
        {
            NavigateToCart();
            ClickWait(Repo.CheckoutBtn);
        }

        public static void ConfirmItemsInCart(List<object[]> itemsAndPrices)
        {
            var products = GetElements(Repo.CartItems);

            foreach (object[] itemAndPrice in itemsAndPrices)
            {
                var itemName = itemAndPrice[0].ToString();
                var itemPrice = itemAndPrice[1].ToString();

                foreach (IWebElement element in products)
                {
                    var actualItemName = element.FindElement(Repo.CartItemNames).Text;
                    var actualItemPrice = element.FindElement(Repo.CartItemsPrices).Text;

                    // Find item with matching name and price and confirm in cart
                    if (actualItemName == itemName &&
                        actualItemPrice.Contains(itemPrice))
                        break;
                    
                    // If the item was not found
                    if (products.IndexOf(element) == products.Count - 1)
                        throw new Exception($"Item in cart was not found. Item: '{itemName}' Price: '{itemPrice}'");
                }
            }
        }

        public static void RemoveAllItemsFromCart()
        {
            while (IsElementPresent(Repo.RemoveFromCartBtns))
                ClickWait(Repo.RemoveFromCartBtns);
        }

        public static void ConfirmNoItemsInCart()
        {
            if (IsElementPresent(Repo.CartItems))
                throw new Exception("Items were still present in the cart when expecting none.");
        }
    }
}
