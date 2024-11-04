using System.Collections.Generic;

namespace LunaLang
{
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
        public List<IStatement> Statements = new List<IStatement>();

        public string TokenLiteral()
        {
            if (Statements.Count > 0)
            {
                return Statements[0].TokenLiteral();
            }
            else
            {
                return "";
            }
        }
    }

    public class Ast
    {
    }

    public class LetStatement : IStatement
    {
        public Token Token { get; set; }
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public void StatementNode()
        {

        }

        public string TokenLiteral()
        {
            return Token.Literal;
        }
    }

    public class Identifier : IExpression
    {
        public Token Token { get; set; }
        public string Value { get; set; }

        public void ExpressionNode()
        {

        }

        public string TokenLiteral()
        {
            return Token.Literal;
        }
    }
}