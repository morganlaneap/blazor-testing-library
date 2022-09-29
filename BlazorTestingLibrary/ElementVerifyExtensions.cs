using AngleSharp.Dom;
using Bunit;
using FluentAssertions;

namespace BlazorTestingLibrary;

public static class ElementVerifyExtensions
{
    public static void ShouldHaveClass(this IElement element, string className)
        => element.ClassList.Should().Contain(className);
    
    public static void ShouldHaveId(this IElement element, string id) 
        => element.Id.Should().Be(id);

    public static void VerifyTextExists(this IRenderedFragment renderedFragment, string text)
    {
        Action act = () => renderedFragment.FindByText(text);
        act.Should().NotThrow();
    }
    
    public static void VerifyTextDoesNotExist(this IRenderedFragment renderedFragment, string text)
    {
        Action act = () => renderedFragment.FindByText(text);
        act.Should().Throw<Exception>();
    }
    
    public static void VerifyPartialTextExists(this IRenderedFragment renderedFragment, string text)
    {
        Action act = () => renderedFragment.FindByPartialText(text);
        act.Should().NotThrow();
    }
    
    public static void VerifyPartialTextDoesNotExist(this IRenderedFragment renderedFragment, string text)
    {
        Action act = () => renderedFragment.FindByPartialText(text);
        act.Should().Throw<Exception>();
    }
    
    public static void VerifyElementWithIdExists(this IRenderedFragment renderedFragment, string id)
    {
        Action act = () => renderedFragment.FindById(id);
        act.Should().NotThrow();
    }
    
    public static void VerifyElementWithIdDoesNotExist(this IRenderedFragment renderedFragment, string id)
    {
        Action act = () => renderedFragment.FindById(id);
        act.Should().Throw<Exception>();
    }
}