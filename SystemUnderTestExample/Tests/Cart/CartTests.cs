using NUnit.Framework;
using System;
using System.Collections.Generic;
using SystemUnderTestExample.Pages.Cart;
using SystemUnderTestExample.Pages.Login;
using SystemUnderTestExample.Pages.Products;

namespace SystemUnderTestExample.Tests.Cart
{
    [TestFixture, Parallelizable]
    class CartTests : Initialization
    {
        [Test, Parallelizable]
        public void Confirm_Cart_Items_Match()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                List<object[]> itemsAndPrices= new List<object[]>()
                {
                    new object[] { "Test.allTheThings() T-Shirt (Red)", "15.99"},
                    new object[] { "Sauce Labs Bolt T-Shirt", "15.99"}
                };

                ProductsPage.AddProductsToCart(itemsAndPrices);

                CartPage.NavigateToCart();
                CartPage.ConfirmItemsInCart(itemsAndPrices);
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Remove_Items_From_Cart()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                List<object[]> itemsAndPrices = new List<object[]>()
                {
                    new object[] { "Test.allTheThings() T-Shirt (Red)", "15.99"},
                    new object[] { "Sauce Labs Bolt T-Shirt", "15.99"}
                };

                ProductsPage.AddProductsToCart(itemsAndPrices);

                CartPage.NavigateToCart();
                CartPage.RemoveAllItemsFromCart();
                CartPage.ConfirmNoItemsInCart();
            }
            catch (Exception e) { throw e; }
        }
    }
}
