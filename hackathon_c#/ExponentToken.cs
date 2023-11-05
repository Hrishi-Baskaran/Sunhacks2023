public class ExponentToken : Token
{
    private int exponent;

    public ExponentToken(object input, int coefficient, int exponent)
        : base(input, coefficient)
    {
        this.exponent = exponent;
    }

    public override object Differentiate()
    {
        if (base.GetInput() is string)
        {
            return new ExponentToken(base.GetInput(), base.GetCoefficient() * this.exponent, this.exponent - 1);
        }
        else
        {
            PowerRule output = new PowerRule();
            output.AddToken(new ExponentToken(base.GetInput(), base.GetCoefficient() * this.exponent, this.exponent - 1));
            output.AddToken((Token)((Token)base.GetInput()).Differentiate());
            return output;
        }
    }

    public override string ToString()
    {
        if (base.GetCoefficient() == 0)
        {
            return "0";
        }

        string output = "(";

        if (base.GetCoefficient() > 1)
        {
            output += base.GetCoefficient() + "*(";
        }

        output += base.GetInput().ToString() + "^(" + this.exponent + ")";

        if (base.GetCoefficient() > 1)
        {
            output += ")";
        }

        output += ")";

        return output;
    }
}
