namespace ChessBoard.Model;

public class SquareState
{
    public static SquareState Empty() => new();

    public int BlackThreats { get; set; } = 0;

    public int WhiteThreats { get; set; } = 0;
}