using LunaLang;

namespace LunaLang.Tests;

[TestClass]
public class LexerTests
{

    public class TokenTest
    {

        public string ExpectedType { get; internal set; }
        public string ExpectedLiteral { get; internal set; }

        public TokenTest(string expectedType, string expectedLiteral)
        {
            ExpectedType = expectedType;
            ExpectedLiteral = expectedLiteral;
        }
    }


    public void RunTokenTest(TokenTest[] tokenTests, string input)
    {
        var lexer = new Lexer(input);
        for (int i = 0; i < tokenTests.Length; i++)
        {
            var test = tokenTests[i];
            var tok = lexer.NextToken();

            if (tok.Type != test.ExpectedType) Assert.Fail($"test - string wrong, expected {test.ExpectedType.ToString()} got {tok.Type.ToString()}");
            if (tok.Literal != test.ExpectedLiteral) Assert.Fail($"test - string wrong, expected {test.ExpectedLiteral.ToString()} got {tok.Literal.ToString()}");
        }
    }

    [TestMethod]
    public void TestNextToken()
    {
        var input = @"var five = 5;
                    var ten = 10;
                    var add = function(x, y) {
                    x + y;
                    };
                    var result = add(five, ten);
                    !-/*5;
                    5 < 10 > 5;
                    if (5 < 10) {
                    return true;
                    } else {
                    return false;
                    }
                    10 == 10;
                    10 != 10;
                    ";
        var tests = new TokenTest[] {
            new(TokenList.VAR, "var"),
            new(TokenList.IDENT, "five"),
            new(TokenList.ASSIGN, "="),
            new(TokenList.INT, "5"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.VAR, "var"),
            new(TokenList.IDENT, "ten"),
            new(TokenList.ASSIGN, "="),
            new(TokenList.INT, "10"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.VAR, "var"),
            new(TokenList.IDENT, "add"),
            new(TokenList.ASSIGN, "="),
            new(TokenList.FUNCTION, "function"),
            new(TokenList.LPAREN, "("),
            new(TokenList.IDENT, "x"),
            new(TokenList.COMMA, ","),
            new(TokenList.IDENT, "y"),
            new(TokenList.RPAREN, ")"),
            new(TokenList.LBRACE, "{"),
            new(TokenList.IDENT, "x"),
            new(TokenList.PLUS, "+"),
            new(TokenList.IDENT, "y"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.RBRACE, "}"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.VAR, "var"),
            new(TokenList.IDENT, "result"),
            new(TokenList.ASSIGN, "="),
            new(TokenList.IDENT, "add"),
            new(TokenList.LPAREN, "("),
            new(TokenList.IDENT, "five"),
            new(TokenList.COMMA, ","),
            new(TokenList.IDENT, "ten"),
            new(TokenList.RPAREN, ")"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.BANG, "!"),
            new(TokenList.MINUS, "-"),
            new(TokenList.SLASH, "/"),
            new(TokenList.ASTERISK, "*"),
            new(TokenList.INT, "5"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.INT, "5"),
            new(TokenList.LT, "<"),
            new(TokenList.INT, "10"),
            new(TokenList.GT, ">"),
            new(TokenList.INT, "5"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.IF, "if"),
            new(TokenList.LPAREN, "("),
            new(TokenList.INT, "5"),
            new(TokenList.LT, "<"),
            new(TokenList.INT, "10"),
            new(TokenList.RPAREN, ")"),
            new(TokenList.LBRACE, "{"),
            new(TokenList.RETURN, "return"),
            new(TokenList.TRUE, "true"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.RBRACE, "}"),
            new(TokenList.ELSE, "else"),
            new(TokenList.LBRACE, "{"),
            new(TokenList.RETURN, "return"),
            new(TokenList.FALSE, "false"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.RBRACE, "}"),
            new(TokenList.INT, "10"),
            new(TokenList.EQ, "=="),
            new(TokenList.INT, "10"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.INT, "10"),
            new(TokenList.NEQ, "!="),
            new(TokenList.INT, "10"),
            new(TokenList.SEMICOLON, ";"),
            new(TokenList.EOF, ""),
        };

        RunTokenTest(tests, input);
    }
}