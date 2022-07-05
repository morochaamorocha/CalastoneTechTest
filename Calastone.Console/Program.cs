// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Calastone.TextFilter.Library;
using Calastone.TextFilter.Library.Filters;

var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestText.txt");
if (File.Exists(filePath))
{
    var fileContent = File.ReadAllText(filePath);
    var textProcessor = new TextProcessor(fileContent);

    var stopwatch = Stopwatch.StartNew();
    textProcessor.ApplyTextFilters(new VowelInTheMiddleFilter(), new LengthFilter(), new ContainsLetterFilter());
    stopwatch.Stop();
    Console.WriteLine("Elapse time for non-parallel: " + stopwatch.ElapsedMilliseconds);
    Console.WriteLine(textProcessor.Output);

    stopwatch.Restart();
    textProcessor.ApplyTextFiltersInParallel(new VowelInTheMiddleFilter(), new LengthFilter(),
        new ContainsLetterFilter());
    stopwatch.Stop();
    Console.WriteLine("Elapse time for parallel: " + stopwatch.ElapsedMilliseconds);
    Console.WriteLine(textProcessor.Output);
}