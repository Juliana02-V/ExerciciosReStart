using CalculatorApp;namespace CalculadoraApp;public class CalculatorTests
{    [Fact]    public void Sum()
    {

        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Sum(1, 2);


        //Assert
        Assert.Equal(3, result);
    }
    [Fact]
    public void Div()
    {
        // Arrange
        var calculator = new Calculator();
        // Act
        var result = calculator.Div(10, 23);
        //Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Div(10, 0));
    }

    [Fact]
    public void Mult()
    {
        // Arrange
        var calculator = new Calculator();
        // Act
        var result = calculator.Mult(10, 2);
        //Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void Sub()
    {
        // Arrange
        var calculator = new Calculator();
        // Act
        var result = calculator.Sub(10, 2);
        //Assert
        Assert.Equal(8, result);
    }

}