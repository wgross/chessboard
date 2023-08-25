namespace ChessBoard.Model.Test;

public class ChessPiecesTest
{
    private readonly ChessBoard board = ChessBoard.CommonSquare();

    [Fact]
    public void Pawn_threatens_forward()
    {
        // ARRANGE
        var black = Pawn.Black(new BoardPosition(1, 1));
        var white = Pawn.White(new BoardPosition(1, 1));

        // ACT
        var result = (
            White: white.GetThreats(this.board),
            Black: black.GetThreats(this.board));

        // ASSERT
        Assert.Equal(2, result.White.Count());
        Assert.Equal(new BoardPosition[] { new(2, 2), new(0, 2) }, result.White);
        Assert.Equal(2, result.Black.Count());
        Assert.Equal(new BoardPosition[] { new(2, 0), new(0, 0) }, result.Black);
    }

    [Fact]
    public void Bishop_threatens()
    {
        // ARRANGE
        var bishop = Bishop.White(new BoardPosition(4, 4));

        // ACT
        var result = bishop.GetThreats(this.board).ToArray();

        // ASSERT
        Assert.Equal(13, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(3,3), new(2,2), new(1,1), new(0,0),new(5,5), new (6,6), new(7,7),
            new(5,3), new(6,2), new(7,1), new(3,5),new(2,6), new(1,7),
        },
        result);
    }

    [Fact]
    public void Rook_threatens()
    {
        // ARRANGE
        var bishop = Rook.White(new BoardPosition(4, 4));

        // ACT
        var result = bishop.GetThreats(this.board).ToArray();

        // ASSERT
        Assert.Equal(14, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(4,0), new(4,1), new(4,2), new(4,3), new(4,5), new(4,6), new(4,7),
            new(0,4), new(1,4), new(2,4), new(3,4), new(5,4), new (6,4), new(7,4),
        },
        result);
    }

    [Fact]
    public void Queen_threatens()
    {
        // ARRANGE
        var queen = Queen.White(new(4, 4));

        // ACT
        var result = queen.GetThreats(board).ToArray();

        // ASSERT
        Assert.Equal(27, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(4, 0), new(4, 1), new(4, 2), new(4, 3), new(4, 5), new(4, 6), new(4, 7),
            new(0, 4), new(1, 4), new(2, 4), new(3, 4), new(5, 4), new(6, 4), new(7, 4),
            new(1, 7), new(2, 6), new(3, 5), new(5, 3), new(6, 2), new(7, 1),
            new(0, 0), new(1, 1), new(2, 2), new(3, 3), new(5, 5), new(6, 6), new(7, 7)
        },
        result);
    }

    [Fact]
    public void King_threatens()
    {
        // ARRANGE
        var king = King.White(new(4, 4));

        // ACT
        var result = king.GetThreats(board).ToArray();

        // ASSERT
        Assert.Equal(8, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(3, 3), new(4, 3), new(5, 3),
            new(3, 4), new(5, 4),
            new(3, 5), new(4, 5), new(5, 5),
        },
        result);
    }

    [Fact]
    public void Knight_threatens()
    {
        // ARRANGE
        var knight = Knight.White(new(4, 4));
        // ACT
        var result = knight.GetThreats(board).ToArray();
        // ASSERT
        Assert.Equal(8, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(3, 2),
            new(5, 2),
            new(2, 3),
            new(6, 3),
            new(2, 5),
            new(6, 5),
            new(3, 6),
            new(5, 6),
        },
        result);
    }

    [Fact]
    public void Knight_threatens_on_edge()
    {
        // ARRANGE
        var knight = Knight.White(new(0, 4));
        // ACT
        var result = knight.GetThreats(board).ToArray();
        // ASSERT
        Assert.Equal(4, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(1, 2),
            new(2, 3),
            new(2, 5),
            new(1, 6),
        },
        result);
    }

    [Fact]
    public void Knight_threatens_on_corner()
    {
        // ARRANGE
        var knight = Knight.White(new(0, 0));
        // ACT
        var result = knight.GetThreats(board).ToArray();
        // ASSERT
        Assert.Equal(2, result.Length);
        Assert.Equal(new BoardPosition[]
        {
            new(2, 1),
            new(1, 2),
        },
        result);
    }
}