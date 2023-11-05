using System.Collections.Generic;

public class PowerRule
{
    private List<Token> tokensList = new List<Token>();

    public void AddToken(Token token)
    {
        tokensList.Add(token);
    }

    public void AddToken(PowerRule expression)
    {
        foreach (Token token in expression.GetTokens())
        {
            this.AddToken(token);
        }
    }

    public List<Token> GetTokens()
    {
        return this.tokensList;
    }

    public override string ToString()
    {
        string output = "(";

        foreach (Token token in this.tokensList)
        {
            output += "(" + token.ToString() + ")" + "*";
        }

        if (output.Length > 1)
        {
            output = output.Substring(0, output.Length - 1);
        }

        output += ")";

        return output;
    }
}
