using System.Text;
using Calastone.TextFilter.Library.Filters.Interfaces;

namespace Calastone.TextFilter.Library.Filters;

public class ContainsLetterFilter : ITextFilter
{
    private readonly char _letterFilter;

    public ContainsLetterFilter(char letterFilter = 't')
    {
        _letterFilter = letterFilter;
    }

    public string ApplyFilter(string text)
    {
        var textBuilder = new StringBuilder();
        if (!(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)))
        {
            foreach (var word in text.SplitByWords())
            {
                if (!word.Contains(_letterFilter))
                {
                    textBuilder.Append(word + " ");
                }
            }
        }

        return textBuilder.ToString();
    }
}