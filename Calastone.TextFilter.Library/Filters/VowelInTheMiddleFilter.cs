using System.Text;
using Calastone.TextFilter.Library.Filters.Interfaces;

namespace Calastone.TextFilter.Library.Filters;

public class VowelInTheMiddleFilter : ITextFilter
{
    private const string VOWELS = "aeiou";

    private string GetMiddleOfWord(string word)
    {
        return word.IsEvenLength()
            ? word.Substring((word.Length / 2) - 1, 2)
            : word.Substring((word.Length / 2), 1);
    }

    public string ApplyFilter(string text)
    {
        var textBuilder = new StringBuilder();
        if (!(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)))
        {
            foreach (var word in text.SplitByWords())
            {
                var middle = GetMiddleOfWord(word);

                if (!VOWELS.Any(vowel => middle.ToLower().Contains(vowel)))
                {
                    textBuilder.Append(word + " ");
                }
            }
        }


        return textBuilder.ToString();
    }
}