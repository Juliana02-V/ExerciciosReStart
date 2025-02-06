
namespace CalculatorApp;

public class Calculator
{

    public int Sum(int num1, int num2) => num1 + num2;

    public int Div(int num1, int num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException();

        }
        else
        {
            return num1 / num2;
        }
    }

    public int Mult(int num1, int num2)
    {
        return num1 * num2;
    }

    public int Sub(int num1, int num2)
    {
        return num1 - num2;
    }
}

