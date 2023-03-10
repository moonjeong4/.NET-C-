namespace TicTacToe;

public enum TileState { None, X, O };
public class TicTacToeButton : Button
{
    public int X
    {
        get;
    }
    public int Y
    {
        get;
    }

    private TileState state = TileState.None;

    public TileState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            if (state == TileState.None)
            {
                Text = "";
            }
            else
            {
                Text = state.ToString();
            }
        }
    }

    public TicTacToeButton(int x, int y)
    {
        X = x;
        Y = y;
        Dock = DockStyle.Fill;

        Resize += (s, ea) =>
        {
            Font = new Font("Bauhaus 93", Height * 0.45f);
        };
    }
}
