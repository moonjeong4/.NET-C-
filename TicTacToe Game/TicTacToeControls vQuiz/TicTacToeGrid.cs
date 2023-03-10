namespace TicTacToe;


public delegate void PlayerMove(
        TicTacToeGrid sender,
        Player player,
        int x, int y
    );
public delegate void GameOver(
        TicTacToeGrid sender,
        TileState winningPlayer
    );

public enum Player { X, O };

public partial class TicTacToeGrid : UserControl
{

    private TableLayoutPanel? panel;
    private Player currentPlayer;

    private TicTacToeButton[,] gridButtons;

    private int dimensions = 3;

    public Color Player1Colour { get; set; } = Color.RebeccaPurple;
    public Color Player2Colour { get; set; } = Color.Salmon;


    private List<(Player player, int x, int y)> moveHistory;


    public int Dimensions
    {
        get => dimensions;
        set
        {
            if (value >= 1 && value != dimensions)
            {
                dimensions = value;
                Reset();
            }

        }
    }

    public Player CurrentPlayer { get => currentPlayer; }
    public List<(Player player, int x, int y)> MoveHistory { get => moveHistory; }
    public int MoveCount { get => moveHistory.Count; }

    public event PlayerMove? OnPlayerMove;
    public event GameOver? OnGameOver;


    public TicTacToeGrid()
    {
        currentPlayer = Player.X;
        gridButtons = new TicTacToeButton[dimensions, dimensions];
        InitializeComponent();
        InitGrid();


    }

    public TicTacToeGrid(int dimensions) : this()
    {
        this.dimensions = dimensions;
    }

    public void Reset()
    {
        currentPlayer = Player.X;
        InitGrid();
    }

    #region statechecks
    public bool IsDraw()
    {
        bool draw = true;

        for (int j = 0; j < dimensions; j++)
        {
            for (int i = 0; i < dimensions; i++)
            {
                if (gridButtons[i, j].State == TileState.None)
                {
                    return false;
                }
            }
        }

        return draw;
    }



    private TileState CheckRowWinner(int row)
    {
        TileState win = gridButtons[0, row].State;
        if (win == TileState.None)
        {
            return TileState.None;
        }

        for (int i = 1; i < dimensions; i++)
        {
            if (gridButtons[i, row].State != win)
            {
                return TileState.None;
            }
        }
        return win;
    }
    private TileState CheckColumnWinner(int col)
    {
        TileState win = gridButtons[col, 0].State;
        if (win == TileState.None)
        {
            return TileState.None;
        }

        for (int i = 1; i < dimensions; i++)
        {
            if (gridButtons[col, i].State != win)
            {
                return TileState.None;
            }
        }
        return win;
    }

    private TileState CheckDescDiagonalWinner()
    {
        TileState win = gridButtons[0, 0].State;
        if (win == TileState.None)
        {
            return TileState.None;
        }

        for (int i = 1; i < dimensions; i++)
        {
            if (gridButtons[i, i].State != win)
            {
                return TileState.None;
            }
        }
        return win;
    }
    private TileState CheckAscDiagonalWinner()
    {
        TileState win = gridButtons[0, dimensions - 1].State;
        if (win == TileState.None)
        {
            return TileState.None;
        }

        for (int i = 1; i < dimensions; i++)
        {
            if (gridButtons[i, dimensions - 1 - i].State != win)
            {
                return TileState.None;
            }
        }
        return win;
    }

    private TileState CheckWinner()
    {
        // check winner in rows
        for (int j = 0; j < dimensions; j++)
        {
            TileState win;
            if ((win = CheckRowWinner(j)) != TileState.None)
            {
                return win;
            }
        }

        for (int i = 0; i < dimensions; i++)
        {
            TileState win;
            if ((win = CheckColumnWinner(i)) != TileState.None)
            {
                return win;
            }
        }

        TileState winD;
        if ((winD = CheckDescDiagonalWinner()) != TileState.None)
        {
            return winD;
        }

        if ((winD = CheckAscDiagonalWinner()) != TileState.None)
        {
            return winD;
        }


        return TileState.None;

    }

    #endregion

    public void InitGrid()
    {
        SuspendLayout();
        moveHistory = new();
        Controls.Clear();
        panel = new()
        {
            Dock = DockStyle.Fill,
            ColumnCount = dimensions,
            RowCount = dimensions,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };

        for (int i = 0; i < dimensions; i++)
        {
            panel.ColumnStyles.Add(new ColumnStyle(
                    SizeType.Percent, 100f / dimensions
                ));
        }
        for (int i = 0; i < dimensions; i++)
        {
            panel.RowStyles.Add(new RowStyle(
                    SizeType.Percent, 100f / dimensions
                ));
        }

        gridButtons = new TicTacToeButton[dimensions, dimensions];

        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {
                TicTacToeButton b = new(j, i) { FlatStyle = FlatStyle.Flat };
                gridButtons[j, i] = b;
                panel.Controls.Add(b);

                b.Click += (s, e) =>
                {
                    if (s != null && s.GetType() == typeof(TicTacToeButton))
                    {

                        TicTacToeButton b = (TicTacToeButton)s;

                        if (b.State == TileState.None)
                        {

                            if (currentPlayer == Player.X)
                            {
                                b.State = TileState.X;
                                currentPlayer = Player.O;
                                b.ForeColor = Player1Colour;

                            }
                            else
                            {
                                b.State = TileState.O;
                                currentPlayer = Player.X;
                                b.ForeColor = Player2Colour;
                            }

                            var winner = CheckWinner();

                            bool gameOver = false;
                            if (winner != TileState.None)
                            {
                                gameOver = true;
                            }
                            else if (IsDraw())
                            {
                                gameOver = true;
                            }

                            moveHistory.Add(
                                (
                                    currentPlayer == Player.X ? Player.O : Player.X,
                                    b.X,
                                    b.Y)
                                );

                            OnPlayerMove?.Invoke(
                                this,
                                currentPlayer == Player.X ? Player.O : Player.X,
                                b.X, b.Y
                            );


                            if (gameOver)
                            {
                                OnGameOver?.Invoke(this, winner);
                            }

                        }


                    }
                };
            }
        }
        Controls.Add(panel);
        ResumeLayout(true);
    }


}
