using AutomationFrameworkExample.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using SystemUnderTestExample.POM.Global;
using SystemUnderTestExample.POM.Products;

namespace SystemUnderTestExample.Pages.Products
{
    public class ProductsPage : BasePage
    {
        private static ProductsPOM Repo = new ProductsPOM();
        private static GlobalPOM GlobalRepo = new GlobalPOM();

        #region Sorting
        public static void SortItemsBy(string sortBy)
        {
            SelectDropDown(Repo.SortSelector, sortBy);
            WaitForPageLoad();
        }

        public static void ConfirmItemsAlaphabeticSort(bool isAscending)
        {
            var items = GetTextFromElements(Repo.InventoryItemName);

            if (items.Count < 2)
                return;

            for (int index = 0; index < items.Count - 1; index++)
            {
                string item1 = items[index];
                string item2 = items[index + 1];

                int comparison = string.Compare(item1, item2);

                if (isAscending)
                {
                    // A-Z sort
                    if (comparison != -1 && comparison != 0)
                        throw new Exception($"Alphabetical (A-Z) sort failed.\n" +
                            $"Item #{index} was {items[index]}, item #{index + 1} was {items[index + 1]}");
                }
                else
                {
                    // Z-A sort
                    if (comparison != 1 && comparison != 0)
                        throw new Exception($"Alphabetical (Z-A) sort failed.\n" +
                            $"Item #{index} was {items[index]}, item #{index + 1} was {items[index + 1]}");
                }
            }
        }

        public static void ConfirmItemsNumericSort(bool isAscending)
        {
            var items = GetTextFromElements(Repo.InventoryItemPrice);

            if (items.Count < 2)
                return;

            for (int index = 0; index < items.Count - 1; index++)
            {
                double item1 = double.Parse(items[index].Replace("$", ""));
                double item2 = double.Parse(items[index + 1].Replace("$", ""));

                if (isAscending)
                {
                    if (item1 > item2)
                        throw new Exception($"Numeric ascending sort failed.\n" +
                            $"Item #{index} was {items[index]}, item #{index + 1} was {items[index + 1]}");
                }
                else
                {
                    if (item1 < item2)
                        throw new Exception($"Numeric descending sort failed.\n" +
                            $"Item #{index} was {items[index]}, item #{index + 1} was {items[index + 1]}");
                }
            }
        }
        #endregion

        public static void AddProductToCart(string productName)
        {
            var products = GetElements(Repo.InventoryItemName);

            for (int index = 0; index < products.Count; index++)
            {
                if (products[index].Text == productName)
                {
                    ClickWaitIndexed(Repo.AddToCartBtn, index);
                    break;
                }
            }
        }

        public static void AddProductsToCart(List<object[]> itemsAndPrices)
        {
            var products = GetElements(Repo.InventoryItems);

            foreach (object[] itemAndPrice in itemsAndPrices)
            {
                var itemName = itemAndPrice[0].ToString();
                var itemPrice = itemAndPrice[1].ToString();

                foreach (IWebElement element in products)
                {
                    var actualItemName = element.FindElement(Repo.InventoryItemName).Text;
                    var actualItemPrice = element.FindElement(Repo.InventoryItemPrice).Text;

                    // Find item with matching name and price and add to cart
                    if (actualItemName == itemName &&
                        actualItemPrice.Contains(itemPrice))
                    {
                        ClickWaitElement(element.FindElement(Repo.AddToCartBtn));
                        break;
                    }

                    // If the item was not found
                    if (products.IndexOf(element) == products.Count - 1)
                        throw new Exception($"Item to add to cart was not found. Item: '{itemName}' Price: '{itemPrice}'");
                }
            }
        }

        public static void RemoveProductFromCart(string productName)
        {
            var products = GetElements(Repo.InventoryItemName);

            for (int index = 0; index < products.Count; index++)
            {
                if (products[index].Text == productName)
                {
                    ClickWaitIndexed(Repo.AddToCartBtn, index);
                    break;
                }
            }
        }

        public static void VerifyCartCount(int expectedCount)
        {
            // If there are no items in the cart then the cart item count badge is not visible
            if (expectedCount == 0)
            {
                if (IsElementPresent(GlobalRepo.ShoppingCartItemCount))
                    throw new Exception("Expected item count was 0 but the shopping card item badge was present.");

                return;
            }

            int actualCount = int.Parse(GetTextFromElement(GlobalRepo.ShoppingCartItemCount));

            if (expectedCount != actualCount)
                throw new Exception($"Items in cart count was not correct. Expected {expectedCount} items but cart contained {actualCount}.");
        }
    }
}
