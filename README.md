# BlazorTestingLibrary
A (better?) React-like testing approach for Blazor apps. This is still a work in progress but it's useable :)

## Quickstart Example
```
using BlazorTestingLibrary;
using Bunit;
using FluentAssertions;
using Xunit;

...

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
```

## Search Methods
### FindByText
Searches for a given text string in the DOM and returns the first element that contains it.
Throws if there is more than one element found or nothing is found.

### FindByPartialText
Searches for a given partial text string in the DOM and returns the first element that contains it.
Throws if there is more than one element found or nothing is found.

### FindAllByText
Searches for a given text string in the DOM and returns all instances of elements that contain it. 
Throws if nothing is found.

### FindById
Searches for an element with a given id.
Throws if there is more than one element found or nothing is found.

### FindByLabelText
Searches for an input with a particular label attached to it via `for` attribute.
Throws if there is more than one element found or nothing is found.

## Verify Methods
### ShouldHaveClass
Asserts that a given element has a class.

### ShouldHaveId
Asserts that a given element has an id.

### VerifyTextExists
Asserts that a given text exists in the DOM.

### VerifyPartialTextExists
Asserts that a given partial text exists in the DOM.

### VerifyElementWithIdExists
Asserts that an element with a given ID exists in the DOM.

### VerifyTextDoesNotExist
Asserts that a given text does not exist in the DOM.

### VerifyPartialTextDoesNotExist
Asserts that a given partial text does not exist in the DOM.

### VerifyElementWithIdDoesNotExist
Asserts that an element with a given ID does not exist in the DOM.

## Waiting for a condition (WaitFor)
Sometimes you may need to wait for something to happen, which you can do with
`WaitFor(Action action, int timeout = 5000)`. This will perform an action 
until it doesn't throw or the timeout is met. A `ActionTimedOutException` will be thrown
if the timeout is reached.

## Libraries Used
- FluentAssertions
- BUnit
- RichardSzalay.MockHttp

## Footnotes
This library currently only targets `net6.0`.