using NUnit.Framework;
using System;
using SystemUnderTestExample.Pages.Login;
using SystemUnderTestExample.Pages.Products;

namespace SystemUnderTestExample.Tests.Products
{
    [TestFixture, Parallelizable]
    class ProductsSortTests : Initialization
    {
        [Test, Parallelizable]
        public void Sort_Products_Numerically()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                ProductsPage.SortItemsBy("Price (low to high)");
                ProductsPage.ConfirmItemsNumericSort(true);

                ProductsPage.SortItemsBy("Price (high to low)");
                ProductsPage.ConfirmItemsNumericSort(false);
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Sort_Products_Alphabetically()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                ProductsPage.SortItemsBy("Name (A to Z)");
                ProductsPage.ConfirmItemsAlaphabeticSort(true);

                ProductsPage.SortItemsBy("Name (Z to A)");
                ProductsPage.ConfirmItemsAlaphabeticSort(false);
            }
            catch (Exception e) { throw e; }
        }
    }
}
