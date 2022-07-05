using Calastone.TextFilter.Library.Filters;

namespace Calastone.TextFilter.Test;

[TestFixture]
public class ContainsLetterFilterTests
{
    [TestCase("a to is", "a is ")]
    [TestCase("nan dol put ", "nan dol ")]
    [TestCase("nand dols puts ", "nand dols ")]
    [TestCase("a nand to dols is puts ", "a nand dols is ")]
    [TestCase("a nando to dolst is putsh", "a nando is ")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void VowelInTheMiddleFilter_ApplyFilter_Returns_FilteredText(string input, string expected)
    {
        //Arrange
        var sut = new ContainsLetterFilter();

        //Act
        var actual = sut.ApplyFilter(input);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}