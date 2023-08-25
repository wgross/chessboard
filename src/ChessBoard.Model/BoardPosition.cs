namespace ChessBoard.Model;

public record struct BoardPosition(int X, int Y)
{
    public string AsChessCoordinate => $"{this.XAsChessColumn}{this.YAsChessRow}";
    private string YAsChessRow => $"{1 + this.Y}";
    private string XAsChessColumn => $"{(char)('a' + this.X)}";
}