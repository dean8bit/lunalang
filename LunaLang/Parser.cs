namespace LunaLang;

public class Parser
{
    private Lexer Lexer { get; set; }
    private Token CurToken { get; set; }
    private Token PeekToken { get; set; }

    public Parser(Lexer lexer)
    {
        Lexer = lexer;
        NextToken();
        NextToken();
    }

    public void NextToken()
    {
        CurToken = PeekToken;
        PeekToken = Lexer.NextToken();
    }

    public Program ParseProgram() {
        return new Program();
    }
}