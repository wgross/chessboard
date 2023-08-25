namespace ChessBoard.Model.Test;

public class ChessBoardTest
{
    [Fact]
    public void Create_square_board()
    {
        // ACT
        var result = ChessBoard.CommonSquare();

        // ASSERT
        Assert.Equal(new(8, 8), result.Dimensions);
    }
}