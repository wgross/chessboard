namespace ChessBoard.Model;

public record Queen(BoardPosition Position) : IChessPiece
{
    public static Queen White(BoardPosition position) => new Queen(position);
    public static Queen Black(BoardPosition position) => new Queen(position);

    public IEnumerable<BoardPosition> GetThreats(ChessBoard board)
        => board.GetColumn(through: this.Position)
        .Concat(board.GetRow(through: this.Position))
        .Concat(board.GetDiagonalRight(through: this.Position))
        .Concat(board.GetDiagonalLeft(through: this.Position))
        .Where(p => p != this.Position);
}