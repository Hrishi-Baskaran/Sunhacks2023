public class FunctionToken : Token
{
    private string type;

    public FunctionToken(object input, int coefficient, string type)
        : base(input, coefficient)
    {
        this.type = type;
    }

    public override string ToString()
    {
        string output = "";
        if (base.GetCoefficient() > 1)
        {
            output += base.GetCoefficient() + "*";
        }
        output += type + "(" + base.GetInput().ToString() + ")";
        return output;
    }

    public override object Differentiate()
    {
        if (base.GetInput() is string)
        {
            return this.type switch
            {
                "sin" => new FunctionToken(base.GetInput(), base.GetCoefficient(), "cos"),
                "cos" => new FunctionToken(base.GetInput(), -1 * base.GetCoefficient(), "sin"),
                _ => new ExponentToken(base.GetInput(), base.GetCoefficient(), -1),
            };
        }
        else
        {
            PowerRule output = new PowerRule();
            switch (this.type)
            {
                case "sin":
                    output.AddToken(new FunctionToken(base.GetInput(), base.GetCoefficient(), "cos"));
                    break;
                case "cos":
                    output.AddToken(new FunctionToken(base.GetInput(), -1 * base.GetCoefficient(), "sin"));
                    break;
                case "ln":
                    output.AddToken(new ExponentToken(base.GetInput(), base.GetCoefficient(), -1));
                    break;
            }
            output.AddToken((Token)((Token)base.GetInput()).Differentiate());
            return output;
        }
    }
}
