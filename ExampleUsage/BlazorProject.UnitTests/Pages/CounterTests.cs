using BlazorProject.Pages;
using BlazorTestingLibrary;
using Bunit;
using FluentAssertions;
using Xunit;

namespace BlazorProject.UnitTests.Pages
{
    public class CounterTests
    {
        [Fact]
        public void ShouldIncrementValueOnClick()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<Counter>();

            component.FindByText("Increase count").Click();
            component.VerifyTextExists("Current count: 1");
        }
        
        [Fact]
        public void ShouldHaveCorrectClassBasedOnEvenOrOdd()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<Counter>();

            var incrementButton = component.FindByText("Increase count");
            
            // Set to 1
            incrementButton.Click();
            var counterElement = component.FindByText("Current count: 1");
            counterElement.ShouldHaveClass("is-odd");
            
            // Set to 2
            incrementButton.Click();
            counterElement = component.FindByText("Current count: 2");
            counterElement.ShouldHaveClass("is-even");
        }
        
        [Fact]
        public void CanIncrementMultipleTimes()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<Counter>();

            for (var i = 0; i < 5; i++)
            {
                component.FindByText("Increase count").Click();
            }

            component.VerifyTextExists("Current count: 5");
        }
        
        [Fact]
        public void ResetButtonShouldResetTheCounter()
        {
            using var context = new TestContext();
            var component = context.RenderComponent<Counter>();

            for (var i = 0; i < 5; i++)
            {
                component.FindByText("Increase count").Click();
            }

            component.FindByText("Reset count").Click();
            
            component.VerifyTextExists("Current count: 0");
        }
    }
}