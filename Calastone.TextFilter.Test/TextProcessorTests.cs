using Calastone.TextFilter.Library;
using Calastone.TextFilter.Library.Filters;

namespace Calastone.TextFilter.Test;

[TestFixture]
public class TextProcessorTests
{

    [TestCase("a to is", "")]
    [TestCase("nan dol put ", "")]
    [TestCase("nand dols puts ", "")]
    [TestCase("a nand to dols is puts ", "")]
    [TestCase("a nando to dolst is putsh", "nando dolst putsh \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFilters_VowelsInTheMiddleFilter(string input, string expected)
    {
        //Arrange
        var filter = new VowelInTheMiddleFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFilters(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is", "")]
    [TestCase("nan dol put ", "nan dol put \r\n")]
    [TestCase("nand dols puts ", "nand dols puts \r\n")]
    [TestCase("a nand to dols is puts ", "nand dols puts \r\n")]
    [TestCase("a nando to dolst is putsh", "nando dolst putsh \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFilters_LengthFilter(string input, string expected)
    {
        //Arrange
        var filter = new LengthFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFilters(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is", "a is \r\n")]
    [TestCase("nan dol put ", "nan dol \r\n")]
    [TestCase("nand dols puts ", "nand dols \r\n")]
    [TestCase("a nand to dols is puts ", "a nand dols is \r\n")]
    [TestCase("a nando to dolst is putsh", "a nando is \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFilters_ContainsLetterFilter(string input, string expected)
    {
        //Arrange
        var filter = new ContainsLetterFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFilters(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is\nAlice\n \n", "")]
    [TestCase("nan dol put ", "")]
    [TestCase("nand dols puts ", "")]
    [TestCase("a nand to dols is puts ", "")]
    [TestCase("a nando to dolst is putsh", "nando \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFilters_AllFilters(string input, string expected)
    {
        //Arrange
        var vowelInTheMiddlefilter = new VowelInTheMiddleFilter();
        var lengthfilter = new LengthFilter();
        var containsLetterfilter = new ContainsLetterFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFilters(vowelInTheMiddlefilter, lengthfilter, containsLetterfilter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is", "")]
    [TestCase("nan dol put ", "")]
    [TestCase("nand dols puts ", "")]
    [TestCase("a nand to dols is puts ", "")]
    [TestCase("a nando to dolst is putsh", "nando dolst putsh \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFiltersInParallel_VowelsInTheMiddleFilter(string input, string expected)
    {
        //Arrange
        var filter = new VowelInTheMiddleFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFiltersInParallel(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is", "")]
    [TestCase("nan dol put ", "nan dol put \r\n")]
    [TestCase("nand dols puts ", "nand dols puts \r\n")]
    [TestCase("a nand to dols is puts ", "nand dols puts \r\n")]
    [TestCase("a nando to dolst is putsh", "nando dolst putsh \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFiltersInParallel_LengthFilter(string input, string expected)
    {
        //Arrange
        var filter = new LengthFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFiltersInParallel(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is", "a is \r\n")]
    [TestCase("nan dol put ", "nan dol \r\n")]
    [TestCase("nand dols puts ", "nand dols \r\n")]
    [TestCase("a nand to dols is puts ", "a nand dols is \r\n")]
    [TestCase("a nando to dolst is putsh", "a nando is \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFiltersInParallel_ContainsLetterFilter(string input, string expected)
    {
        //Arrange
        var filter = new ContainsLetterFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFiltersInParallel(filter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("a to is\nAlice\n \n", "")]
    [TestCase("nan dol put ", "")]
    [TestCase("nand dols puts ", "")]
    [TestCase("a nand to dols is puts ", "")]
    [TestCase("a nando to dolst is putsh", "nando \r\n")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void TextProcessor_ApplyTextFiltersInParallel_AllFilters(string input, string expected)
    {
        //Arrange
        var vowelInTheMiddlefilter = new VowelInTheMiddleFilter();
        var lengthfilter = new LengthFilter();
        var containsLetterfilter = new ContainsLetterFilter();
        var sut = new TextProcessor(input);

        //Act
        sut.ApplyTextFiltersInParallel(vowelInTheMiddlefilter, lengthfilter, containsLetterfilter);
        var actual = sut.Output;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}