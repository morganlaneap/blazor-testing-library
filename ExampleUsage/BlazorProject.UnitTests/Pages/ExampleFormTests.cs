using BlazorProject.Pages;
using BlazorTestingLibrary;
using Bunit;
using FluentAssertions;
using Xunit;

namespace BlazorProject.UnitTests.Pages
{
    public class ExampleFormTests
    {
        [Fact]
        public void SubmittingAValidForm()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<ExampleForm>();

            var forenameInput = component.FindByLabelText("Forename:");
            forenameInput.Change("John");

            var surnameInput = component.FindByLabelText("Surname:");
            surnameInput.Change("Smith");

            var emailInput = component.FindByLabelText("Email Address:");
            emailInput.Change("john.smith@developer.com");

            var submitButton = component.FindByText("Submit");
            submitButton.Click();

            component.VerifyTextExists("Your form is Submitted");
        }
        
        [Fact]
        public void InvalidEmailAddress()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<ExampleForm>();

            var forenameInput = component.FindByLabelText("Forename:");
            forenameInput.Change("John");

            var surnameInput = component.FindByLabelText("Surname:");
            surnameInput.Change("Smith");

            var emailInput = component.FindByLabelText("Email Address:");
            emailInput.Change("invalid email address");

            var submitButton = component.FindByText("Submit");
            submitButton.Click();

            component.VerifyTextExists("The EmailAddress field is not a valid e-mail address.");
        }
        
        [Fact]
        public void RequiredFields()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<ExampleForm>();
            
            var submitButton = component.FindByText("Submit");
            submitButton.Click();

            component.VerifyTextExists("The Forename field is required.");
            component.VerifyTextExists("The Surname field is required.");
            component.VerifyTextExists("The EmailAddress field is required.");
        }
    }
}