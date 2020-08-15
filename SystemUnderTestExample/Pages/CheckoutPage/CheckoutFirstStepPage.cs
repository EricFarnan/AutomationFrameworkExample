using AutomationFrameworkExample.Helpers;
using System;
using SystemUnderTestExample.POM.Checkout;

namespace SystemUnderTestExample.Pages.CheckoutPage
{
    public class CheckoutFirstStepPage : BasePage
    {
        private static CheckoutPOM Repo = new CheckoutPOM();

        public static void ConfirmInputValidations()
        {
            VerifyFirstNameInputValidation();
            VerifyLastNameInputValidation();
            VerifyPostalCodeInputValidation();
        }

        private static void VerifyFirstNameInputValidation()
        {
            EnterText(Repo.FirstNameInput, "", true);
            EnterText(Repo.LastNameInput, "Test", true);
            EnterText(Repo.ZipPostalCodeInput, "12345", true);
            ClickWait(Repo.ContinueBtn);

            if (!ValidateText(Repo.InputErrorMsg, "Error: First Name is required"))
                throw new Exception("First name validation was not correct.");
        }

        private static void VerifyLastNameInputValidation()
        {
            Refresh();

            EnterText(Repo.FirstNameInput, "Test", true);
            EnterText(Repo.LastNameInput, "", true);
            EnterText(Repo.ZipPostalCodeInput, "12345", true);
            ClickWait(Repo.ContinueBtn);

            if (!ValidateText(Repo.InputErrorMsg, "Error: Last Name is required"))
                throw new Exception("Last name validation was not correct.");
        }

        private static void VerifyPostalCodeInputValidation()
        {
            Refresh();

            EnterText(Repo.FirstNameInput, "Test", true);
            EnterText(Repo.LastNameInput, "Test2", true);
            EnterText(Repo.ZipPostalCodeInput, "", true);
            ClickWait(Repo.ContinueBtn);

            if (!ValidateText(Repo.InputErrorMsg, "Error: Postal Code is required"))
                throw new Exception("Postal code validation was not correct.");
        }

        public static void EnterPersonalDetails()
        {
            EnterText(Repo.FirstNameInput, "Test", true);
            EnterText(Repo.LastNameInput, "Test2", true);
            EnterText(Repo.ZipPostalCodeInput, "12345", true);
            ClickWait(Repo.ContinueBtn);
        }
    }
}
