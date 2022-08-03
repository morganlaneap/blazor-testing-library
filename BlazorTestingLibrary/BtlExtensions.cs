using AngleSharp.Dom;
using Bunit;

namespace BlazorTestingLibrary;

public static class BtlExtensions
{
    public static IElement? FindByText(this IRenderedFragment renderedFragment, string text)
    {
        INode? SearchNodes (INodeList nodeList)
        {
            foreach (var node in nodeList)
            {
                if (node.HasChildNodes)
                {
                    var result = SearchNodes(node.ChildNodes);
                    if (result != null) return result;
                }
                if (node.TextContent == text) return node; 
            }
            return null;
        }
        return SearchNodes(renderedFragment.Nodes)?.ParentElement;
    }

    public static IElement[] FindAllByText(this IRenderedFragment renderedFragment, string text)
    {
        var matchedElements = new List<IElement>();
        void SearchNodes (INodeList nodeList)
        {
            foreach (var node in nodeList)
            {
                if (node.HasChildNodes) SearchNodes(node.ChildNodes);
                if (node.TextContent == text && node.ParentElement != null) matchedElements.Add(node.ParentElement); 
            }
        }
        SearchNodes(renderedFragment.Nodes);
        return matchedElements.ToArray();
    }
}
