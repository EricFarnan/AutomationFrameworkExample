using NUnit.Framework;
using System;
using SystemUnderTestExample.Pages.Login;
using SystemUnderTestExample.Pages.Products;

namespace SystemUnderTestExample.Tests.Products
{
    [TestFixture, Parallelizable]
    class ProductsTests : Initialization
    {
        [Test, Parallelizable]
        public void Add_And_Remove_Products_From_Cart()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                ProductsPage.VerifyCartCount(0);

                ProductsPage.AddProductToCart("Sauce Labs Fleece Jacket");
                ProductsPage.AddProductToCart("Sauce Labs Bike Light");
                ProductsPage.VerifyCartCount(2);

                ProductsPage.RemoveProductFromCart("Sauce Labs Fleece Jacket");
                ProductsPage.RemoveProductFromCart("Sauce Labs Bike Light");
                ProductsPage.VerifyCartCount(0);
            }
            catch (Exception e) { throw e; }
        }
    }
}
