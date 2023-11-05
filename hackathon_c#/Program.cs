using System;
using System.Linq;
using org.mariuszgromada.math.mxparser;

public class Program
{
    static Random random = new Random();
    public static void Main(string[] args)
    {
        /*
        THIS IS FOR TESTING IT'S OKAY TO DELETE THIS
        License.iConfirmCommercialUse("tkherti");
        Token output = Generator("x");
        Console.WriteLine(output);
        string input = Console.ReadLine();
        Console.WriteLine(Test(output.Differentiate().ToString(),input));
        */
    }

    public static bool Test(string stringOne, string stringTwo)
    {
        Argument x = new Argument("x=3");
        Expression expression = new Expression(stringOne + "-" + "(" + stringTwo + ")", x);
        bool test1 = Math.Abs(expression.calculate()) < 0.01;
        x = new Argument("x=5");
        expression = new Expression(stringOne + "-" + "(" + stringTwo + ")", x);
        bool test2 = Math.Abs(expression.calculate()) < 0.01;
        x = new Argument("x=1289");
        expression = new Expression(stringOne + "-" + "(" + stringTwo + ")", x);
        bool test3 = Math.Abs(expression.calculate()) < 0.01;

        return (test1 && test2 && test3);
        
        
    }
    
    public static Token Generator(object input)
    {
        int coefficient = random.Next(1, 10);
        int tokenTypeSeed = random.Next(5);
        Token output;

        if (tokenTypeSeed < 3)
        {
            int exponent = random.Next(1, 10);
            output = new ExponentToken(input, coefficient, exponent);
        }
        else
        {
            int functionTypeSeed = random.Next(3);
            switch (functionTypeSeed)
            {
                case 0:
                    output = new FunctionToken(input, coefficient, "sin");
                    break;
                case 1:
                    output = new FunctionToken(input, coefficient, "cos");
                    break;
                default:
                    output = new FunctionToken(input, coefficient, "ln");
                    break;
            }
        }

        return output;
    }

}
