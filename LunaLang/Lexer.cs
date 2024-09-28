namespace LunaLang;

public class Lexer
{
    public string Input { get; private set; }
    public int Position { get; private set; }
    public int ReadPosition { get; private set; }
    public Char Ch { get; private set; }

    public Lexer(string input)
    {
        Input = input;
        ReadChar();
    }

    private void ReadChar()
    {
        if (ReadPosition >= Input.Length)
        {
            Ch = Convert.ToChar(0);
        }
        else
        {
            Ch = Input.Substring(ReadPosition, 1).ToCharArray().FirstOrDefault();
        }
        Position = ReadPosition;
        ReadPosition++;
    }

    public Token NextToken()
    {
        Token tok;
        SkipWhitespace();
        if (Convert.ToByte(Ch) == 0)
        {
            tok = new Token(TokenList.EOF, "");
        }
        else
        {
            switch (Ch)
            {
                case ';':
                    tok = new Token(TokenList.SEMICOLON, Ch);
                    break;
                case '(':
                    tok = new Token(TokenList.LPAREN, Ch);
                    break;
                case ')':
                    tok = new Token(TokenList.RPAREN, Ch);
                    break;
                case ',':
                    tok = new Token(TokenList.COMMA, Ch);
                    break;
                case '+':
                    tok = new Token(TokenList.PLUS, Ch);
                    break;
                case '-':
                    tok = new Token(TokenList.MINUS, Ch);
                    break;
                case '/':
                    tok = new Token(TokenList.SLASH, Ch);
                    break;
                case '*':
                    tok = new Token(TokenList.ASTERISK, Ch);
                    break;
                case '<':
                    tok = new Token(TokenList.LT, Ch);
                    break;
                case '>':
                    tok = new Token(TokenList.GT, Ch);
                    break;
                case '{':
                    tok = new Token(TokenList.LBRACE, Ch);
                    break;
                case '}':
                    tok = new Token(TokenList.RBRACE, Ch);
                    break;
                case '=':
                    if (PeekChar() == '=')
                    {
                        var ch = Ch;
                        ReadChar();
                        tok = new Token(TokenList.EQ, ch.ToString() + Ch.ToString());
                    }
                    else
                    {
                        tok = new Token(TokenList.ASSIGN, Ch);
                    }
                    break;
                case '!':
                    if (PeekChar() == '=')
                    {
                        var ch = Ch;
                        ReadChar();
                        tok = new Token(TokenList.NEQ, ch.ToString() + Ch.ToString());
                    }
                    else
                    {
                        tok = new Token(TokenList.BANG, Ch);
                    }
                    break;
                default:
                    if (IsLetter(Ch))
                    {
                        tok = new Token(TokenList.ILLEGAL, "");
                        tok.Literal = ReadIdentifier();
                        tok.Type = TokenList.LookupIdent(tok.Literal);
                        return tok;
                    }
                    else if (IsDigit(Ch))
                    {
                        tok = new Token(TokenList.INT, ReadNumber());
                        return tok;
                    }
                    else
                    {
                        tok = new Token(TokenList.ILLEGAL, Ch.ToString());
                    }
                    break;
            }
        }
        ReadChar();
        return tok;
    }

    public char PeekChar()
    {
        if (ReadPosition == Input.Length)
        {
            return Convert.ToChar(0);
        }
        else
        {
            return Input[ReadPosition];
        }
    }

    public string ReadNumber()
    {
        var pos = Position;
        while (IsDigit(Ch))
        {
            ReadChar();
        }
        return Input.Substring(pos, Position - pos);
    }

    public bool IsDigit(char ch)
    {
        return '0' <= ch && ch <= '9';
    }

    public void SkipWhitespace()
    {
        while (Ch == ' ' || Ch == '\t' || Ch == '\r' || Ch == '\n')
        {
            ReadChar();
        }
    }

    public string ReadIdentifier()
    {
        var pos = Position;
        while (IsLetter(Ch))
        {
            ReadChar();
        }
        return Input.Substring(pos, Position - pos);
    }

    public bool IsLetter(char ch)
    {
        return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z' || ch == '_';
    }
}