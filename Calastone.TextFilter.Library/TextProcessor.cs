using System.Text;
using Calastone.TextFilter.Library.Filters.Interfaces;

namespace Calastone.TextFilter.Library
{
    public class TextProcessor
    {
        public TextProcessor(string text)
        {
            Lines = text.Split(new[] {Environment.NewLine},StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries ).ToList();
        }

        
        public IEnumerable<string> Lines { get; }

        public string Output { get; private set; }

        public void ApplyTextFilters(params ITextFilter[] textFilters)
        {
            var outputBuilder = new StringBuilder();
            foreach (var line in Lines)
            {
                var filteredLine = textFilters.Aggregate(line, (current, filter) => filter.ApplyFilter(current));
                if (!string.IsNullOrEmpty(filteredLine)) outputBuilder.AppendLine(filteredLine);
            }

            Output = outputBuilder.ToString();
        }

        public void ApplyTextFiltersInParallel(params ITextFilter[] textFilters)
        {
            var outputBuilder = new StringBuilder();

            var filteredLines = Lines
                .AsParallel()
                .AsOrdered()
                .Select(l => textFilters.Aggregate(l, (current, filter) => filter.ApplyFilter(current)));
            
            foreach (var filteredLine in filteredLines.Where(l => !string.IsNullOrEmpty(l)))
            {
                outputBuilder.AppendLine(filteredLine);
            }

            Output = outputBuilder.ToString();
        }
    }
}