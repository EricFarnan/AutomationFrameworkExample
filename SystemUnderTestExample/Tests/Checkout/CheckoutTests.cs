using NUnit.Framework;
using System;
using SystemUnderTestExample.Pages.Cart;
using SystemUnderTestExample.Pages.CheckoutPage;
using SystemUnderTestExample.Pages.Login;
using SystemUnderTestExample.Pages.Products;

namespace SystemUnderTestExample.Tests.Checkout
{
    [TestFixture, Parallelizable]
    public class CheckoutTests : Initialization
    {
        [Test, Parallelizable]
        public void Confirm_Checkout_Validations()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                CartPage.NavigateToCheckout();
                CheckoutFirstStepPage.ConfirmInputValidations();
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Validate_Checkout_Calculations()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                ProductsPage.AddProductToCart("Sauce Labs Fleece Jacket");
                ProductsPage.AddProductToCart("Sauce Labs Bike Light");

                CartPage.NavigateToCheckout();               
                CheckoutFirstStepPage.EnterPersonalDetails();
                CheckoutOverviewPage.VerifyCheckoutMath();
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Checkout_With_Item()
        {
            try
            {
                LoginPage.LoginAsStandardUser();

                ProductsPage.AddProductToCart("Sauce Labs Bike Light");

                CartPage.NavigateToCheckout();
                CheckoutFirstStepPage.EnterPersonalDetails();
                CheckoutOverviewPage.Checkout();
            }
            catch (Exception e) { throw e; }
        }
    }
}
