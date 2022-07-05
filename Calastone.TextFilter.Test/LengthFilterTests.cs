using Calastone.TextFilter.Library.Filters;

namespace Calastone.TextFilter.Test;

[TestFixture]
public class LengthFilterTests
{
    [TestCase("a to is", "")]
    [TestCase("nan dol put ", "nan dol put ")]
    [TestCase("nand dols puts ", "nand dols puts ")]
    [TestCase("a nand to dols is puts ", "nand dols puts ")]
    [TestCase("a nando to dolst is putsh", "nando dolst putsh ")]
    [TestCase("", "")]
    [TestCase("                 ", "")]
    public void VowelInTheMiddleFilter_ApplyFilter_Returns_FilteredText(string input, string expected)
    {
        //Arrange
        var sut = new LengthFilter();

        //Act
        var actual = sut.ApplyFilter(input);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }


}