namespace ChessBoard.Model;

public record Bishop(BoardPosition Position) : IChessPiece
{
    public static Bishop White(BoardPosition position) => new Bishop(position);

    public static Bishop Black(BoardPosition position) => new Bishop(position);


    public IEnumerable<BoardPosition> GetThreats(ChessBoard board)
    {
        var current = this.Position;
        while (current.X > 0 && current.Y > 0)
        {
            current = current with
            {
                X = current.X - 1,
                Y = current.Y - 1,
            };

            yield return current;
        }

        current = this.Position;
        while (current.X < board.Dimensions.Width - 1 && current.Y <= board.Dimensions.Height - 1)
        {
            current = current with
            {
                X = current.X + 1,
                Y = current.Y + 1,
            };

            yield return current;
        }

        current = this.Position;
        while (current.X < board.Dimensions.Width - 1 && current.Y > 0)
        {
            current = current with
            {
                X = current.X + 1,
                Y = current.Y - 1,
            };

            yield return current;
        }

        current = this.Position;
        while (current.X > 0 && current.Y < board.Dimensions.Height - 1)
        {
            current = current with
            {
                X = current.X - 1,
                Y = current.Y + 1,
            };

            yield return current;
        }
    }
}