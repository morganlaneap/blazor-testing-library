using BlazorProject.Pages;
using BlazorTestingLibrary;
using Bunit;
using FluentAssertions;
using Xunit;

namespace BlazorProject.UnitTests.Pages;

public class ElementTests
{
    [Fact]
    public void FindByTextWorks()
    {
        using var context = new TestContext();
        var component = context.RenderComponent<Elements>();
        component.VerifyTextExists("This is some text");
    }
    
    [Fact]
    public void FindByPartialTextWorks()
    {
        using var context = new TestContext();
        var component = context.RenderComponent<Elements>();
        component.VerifyPartialTextExists("some text");
    }
    
    [Fact]
    public void FindByLabelTextWorks()
    {
        using var context = new TestContext();
        var component = context.RenderComponent<Elements>();
        component.VerifyTextExists("Test input label");
    }
}