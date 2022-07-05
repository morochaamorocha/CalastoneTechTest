using System.Text;
using Calastone.TextFilter.Library.Filters.Interfaces;

namespace Calastone.TextFilter.Library.Filters;

public class LengthFilter : ITextFilter
{
    private readonly int _minLength;

    public LengthFilter(int minLength = 3)
    {
        _minLength = minLength;
    }

    public string ApplyFilter(string text)
    {
        var textBuilder = new StringBuilder();
        if (!(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)))
        {
            foreach (var word in text.SplitByWords())
            {
                if (!(word.Length < _minLength))
                {
                    textBuilder.Append(word + " ");
                }
            }
        }
        

        return textBuilder.ToString();
    }
}