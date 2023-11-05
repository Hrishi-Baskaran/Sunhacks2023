public abstract class Token
{
    private object input;
    private int coefficient;

    public Token(object input, int coefficient)
    {
        this.input = input;
        this.coefficient = coefficient;
    }

    public object GetInput()
    {
        return this.input;
    }

    public int GetCoefficient()
    {
        return this.coefficient;
    }

    public void SetCoefficient(int coefficient)
    {
        this.coefficient = coefficient;
    }

    public abstract object Differentiate();
}