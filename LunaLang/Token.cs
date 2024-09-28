namespace LunaLang;

public static class TokenList
{
    public const string ILLEGAL = "ILLEGAL";
    public const string EOF = "EOF";
    public const string IDENT = "IDENT";
    public const string INT = "INT";
    public const string ASSIGN = "=";
    public const string PLUS = "+";
    public const string MINUS = "-";
    public const string BANG = "!";
    public const string ASTERISK = "*";
    public const string SLASH = "/";
    public const string LT = "<";
    public const string GT = ">";
    public const string EQ = "==";
    public const string NEQ = "!=";
    public const string COMMA = ",";
    public const string SEMICOLON = ";";
    public const string LPAREN = "(";
    public const string RPAREN = ")";
    public const string LBRACE = "{";
    public const string RBRACE = "}";
    public const string FUNCTION = "FUNCTION";
    public const string VAR = "VAR";
    public const string TRUE = "TRUE";
    public const string FALSE = "FALSE";
    public const string IF = "IF";
    public const string ELSE = "ELSE";
    public const string RETURN = "RETURN";

    public static readonly Dictionary<string, string> Keywords = new() {
        { "function", TokenList.FUNCTION },
        { "var", TokenList.VAR },
        { "true", TokenList.TRUE },
        { "false", TokenList.FALSE },
        { "if", TokenList.IF },
        { "else", TokenList.ELSE },
        { "return", TokenList.RETURN }
        };

    public static string LookupIdent(string ident)
    {
        if (TokenList.Keywords.ContainsKey(ident))
        {
            return TokenList.Keywords[ident];
        }
        return TokenList.IDENT;
    }
}

public class Token
{
    public string Type { get; set; }
    public string Literal { get; set; }

    public Token(string type, string literal)
    {
        Type = type;
        Literal = literal;
    }

    public Token(string type, char literal)
    {
        Type = type;
        Literal = literal.ToString();
    }
}

