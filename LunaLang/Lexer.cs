namespace LunaLang;

public class Lexer
{
    public string Input { get; }
    public int Position { get; private set; }
    public int ReadPosition { get; private set; }
    public char Ch { get; private set; }

    public Lexer(string input)
    {
        Input = input;
        ReadChar();
    }

    private void ReadChar()
    {
        Ch = ReadPosition >= Input.Length ? '\0' : Input[ReadPosition];
        Position = ReadPosition++;
    }

    public Token NextToken()
    {
        Token tok;
        SkipWhitespace();
        tok = Ch switch
        {
            '\0' => new Token(TokenList.EOF, ""),
            ';' => new Token(TokenList.SEMICOLON, Ch),
            '(' => new Token(TokenList.LPAREN, Ch),
            ')' => new Token(TokenList.RPAREN, Ch),
            ',' => new Token(TokenList.COMMA, Ch),
            '+' => new Token(TokenList.PLUS, Ch),
            '-' => new Token(TokenList.MINUS, Ch),
            '/' => new Token(TokenList.SLASH, Ch),
            '*' => new Token(TokenList.ASTERISK, Ch),
            '<' => new Token(TokenList.LT, Ch),
            '>' => new Token(TokenList.GT, Ch),
            '{' => new Token(TokenList.LBRACE, Ch),
            '}' => new Token(TokenList.RBRACE, Ch),
            '=' => PeekChar() == '=' ? new Token(TokenList.EQ, $"{Ch}{ReadCharAndReturn()}") : new Token(TokenList.ASSIGN, Ch),
            '!' => PeekChar() == '=' ? new Token(TokenList.NEQ, $"{Ch}{ReadCharAndReturn()}") : new Token(TokenList.BANG, Ch),
            _ => IsLetter(Ch) ? new Token(TokenList.LookupIdent(ReadIdentifier()), ReadIdentifier()) :
                 IsDigit(Ch) ? new Token(TokenList.INT, ReadNumber()) :
                 new Token(TokenList.ILLEGAL, Ch.ToString())
        };
        ReadChar();
        return tok;
    }

    private char ReadCharAndReturn()
    {
        ReadChar();
        return Ch;
    }

    public char PeekChar() => ReadPosition >= Input.Length ? '\0' : Input[ReadPosition];

    public string ReadNumber()
    {
        var pos = Position;
        while (IsDigit(Ch)) ReadChar();
        return Input.Substring(pos, Position - pos);
    }

    public bool IsDigit(char ch) => char.IsDigit(ch);

    public void SkipWhitespace()
    {
        while (char.IsWhiteSpace(Ch)) ReadChar();
    }

    public string ReadIdentifier()
    {
        var pos = Position;
        while (IsLetter(Ch)) ReadChar();
        return Input.Substring(pos, Position - pos);
    }

    public bool IsLetter(char ch) => char.IsLetter(ch) || ch == '_';
}
