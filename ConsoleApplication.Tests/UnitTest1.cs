using Projects;

namespace ConsoleApplication.Tests;

public class UnitTest1
{
    [Fact]
    public void IsLeapYear_1984_ReturnsTrue()
    {
        // Arrange
        var ageInSeconds = new AgeInSeconds();

        // Act
        bool result = ageInSeconds.IsLeapYear(1984);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLeapYear_1900_ReturnsFalse()
    {
        // Arrange
        var ageInSeconds = new AgeInSeconds();

        // Act
        bool result = ageInSeconds.IsLeapYear(1900);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLeapYear_2000_ReturnsTrue()
    {
        // Arrange
        var ageInSeconds = new AgeInSeconds();

        // Act
        bool result = ageInSeconds.IsLeapYear(2000);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLeapYear_1993_ReturnsFalse()
    {
        // Arrange
        var ageInSeconds = new AgeInSeconds();

        // Act
        bool result = ageInSeconds.IsLeapYear(1993);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RemainingDaysInYearSinceBirth_01121990()
    {
        //Arrange
        var ageInSeconds = new AgeInSeconds();

        //Act
        int result = ageInSeconds.RemainingDaysInYearSinceBirth(12, 1, 1990);

        //Asert
        Assert.Equal(30, result);
    }

    [Fact]
    public void RemainingDaysInYearSinceBirth_27072000()
    {
        //Arrange
        var ageInSeconds = new AgeInSeconds();

        //Act
        int result = ageInSeconds.RemainingDaysInYearSinceBirth(7, 27, 2000);

        //Asert
        Assert.Equal(157, result);
    }

    [Fact]
    public void RemainingDaysInYearSinceBirth_01021984()
    {
        //Arrange
        var ageInSeconds = new AgeInSeconds();

        //Act
        int result = ageInSeconds.RemainingDaysInYearSinceBirth(2, 1, 1984);

        //Asert
        Assert.Equal(334, result);
    }

    [Fact]
    public void CalculateDaysSinceBirth_1983()
    {
        //Arrange
        var ageInSeconds = new AgeInSeconds();

        //Act
        int result = ageInSeconds.CalculateDaysSinceBirth(1983);

        //Asert
        Assert.Equal(15341, result);
    }
}
