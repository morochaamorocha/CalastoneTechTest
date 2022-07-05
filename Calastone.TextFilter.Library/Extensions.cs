namespace Calastone.TextFilter.Library;

public static class Extensions
{
    public static bool IsEvenLength(this string input)
    {
        return input.Length % 2 == 0;
    }

    public static IEnumerable<string> SplitByWords(this string text)
    {
        var punctuation = text.Where(char.IsPunctuation ).Distinct().ToArray();
        return text.Trim().Split().Select(x => x.Trim(punctuation));
    }
}