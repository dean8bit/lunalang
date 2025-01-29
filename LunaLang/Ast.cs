namespace LunaLang;

public interface INode
{
    string TokenLiteral();
}

public interface IStatement : INode
{
    void StatementNode();
}

public interface IExpression : INode
{
    void ExpressionNode();
}

public class Program
{
    public List<IStatement> Statements { get; set; } = new();

    public string TokenLiteral() => Statements.Count > 0 ? Statements[0].TokenLiteral() : string.Empty;
}

public class Ast
{
}

public class LetStatement : IStatement
{
    public Token Token { get; set; }
    public Identifier Name { get; set; }
    public IExpression Value { get; set; }

    public void StatementNode() { }

    public string TokenLiteral() => Token.Literal;
}

public class Identifier : IExpression
{
    public Token Token { get; set; }
    public string Value { get; set; }

    public void ExpressionNode() { }

    public string TokenLiteral() => Token.Literal;
}
