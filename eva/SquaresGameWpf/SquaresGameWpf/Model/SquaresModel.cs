using SquaresGameWpf.EventArguments;
using SquaresGameWpf.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGameWpf.Model
{

    public class SquaresModel
    {
        //Private members

        private IDataAccess dataAccess;
        private FieldState[,] board;
        private int size;
        private int onPlayer;
        private int playerBluePoints;
        private int playerRedPoints;

        //Getters
        public int getSize() { return size; }
        public int getPlayerToMove() { return onPlayer; }
        public int getPlayerBluePoints() { return playerBluePoints; }
        public int getPlayerRedPoints() { return playerRedPoints; }
        public FieldState[,] getBoard() { return board; }



        //Events

        public event EventHandler<GameStartedEventArgs> GameStarted;
        public event EventHandler<FieldChangedEventArgs> FieldChanged;
        public event EventHandler<GameOverEventArgs> GameOver;
        public event EventHandler<StatusStripChangedEventArgs> StatusStripChanged;

        //Constructor
        public SquaresModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            onPlayer = RandomGenerator();
            playerBluePoints = 0;
            playerRedPoints = 0;

        }

        //Randomgenerator method (return with 0 or 1)
        public int RandomGenerator()
        {
            Random q = new Random();
            int generated = q.Next(0, 2);
            return generated;
        }

        //Method to start a new game
        public void StartNewGame(int size)
        {
            this.size = size;
            board = new FieldState[size, size];
            playerBluePoints = 0;
            playerRedPoints = 0;
            onPlayer = RandomGenerator();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i + 1) % 2 == 1 && (j + 1) % 2 == 1) { board[i, j] = FieldState.Point; }
                    else if ((i + 1) % 2 == 1 && (j + 1) % 2 == 0 || (i + 1) % 2 == 0 && (j + 1) % 2 == 1) { board[i, j] = FieldState.Empty; }
                    else { board[i, j] = FieldState.Grey; }
                }
            }

            if (GameStarted is not null)
            {
                //Sending event to the View

                GameStarted(this, new GameStartedEventArgs(size, board));
                setStatusStripText();
            }
        }

        //Method to change a field
        public void fieldClicked(int row, int column)
        {

            int madePoint = 0;

            //Elso sor
            if (row == 0)
            {
                //Ha kek jatekos lepett
                if (onPlayer == 0)
                {
                    board[row, column] = FieldState.LeftRightBlue;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row + 1, column - 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty && board[row + 2, column] != FieldState.Empty)
                    {
                        board[row + 1, column] = FieldState.FullBlue;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row + 1, column, board[row + 1, column]));
                        }

                    }
                }

                //Ha piros jatekos lepett
                else
                {
                    board[row, column] = FieldState.LeftRightRed;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row + 1, column - 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty && board[row + 2, column] != FieldState.Empty)
                    {
                        board[row + 1, column] = FieldState.FullRed;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row + 1, column, board[row + 1, column]));
                        }

                    }
                }
            }

            //Utolso sor
            else if (row == size - 1)
            {
                //Ha kek jatekos lepett
                if (onPlayer == 0)
                {
                    board[row, column] = FieldState.LeftRightBlue;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row - 1, column - 1] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty && board[row - 2, column] != FieldState.Empty)
                    {
                        board[row - 1, column] = FieldState.FullBlue;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row - 1, column, board[row - 1, column]));
                        }

                    }
                }

                //Ha piros jatekos lepett
                else
                {
                    board[row, column] = FieldState.LeftRightRed;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row - 1, column - 1] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty && board[row - 2, column] != FieldState.Empty)
                    {
                        board[row - 1, column] = FieldState.FullRed;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row - 1, column, board[row - 1, column]));
                        }

                    }
                }
            }

            //Elso oszlop
            else if (column == 0)
            {
                //Ha kek jatekos lepett
                if (onPlayer == 0)
                {
                    board[row, column] = FieldState.UpDownBlue;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }


                    if (board[row - 1, column + 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty && board[row, column + 2] != FieldState.Empty)
                    {
                        board[row, column + 1] = FieldState.FullBlue;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column + 1, board[row, column + 1]));
                        }

                    }
                }

                //Ha piros jatekos lepett
                else
                {
                    board[row, column] = FieldState.UpDownRed;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row - 1, column + 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty && board[row, column + 2] != FieldState.Empty)
                    {
                        board[row, column + 1] = FieldState.FullRed;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column + 1, board[row, column + 1]));
                        }

                    }
                }
            }

            //Utolso oszlop
            else if (column == size - 1)
            {
                //Ha kek jatekos lepett
                if (onPlayer == 0)
                {
                    board[row, column] = FieldState.UpDownBlue;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row - 1, column - 1] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty && board[row, column - 2] != FieldState.Empty)
                    {
                        board[row, column - 1] = FieldState.FullBlue;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column - 1, board[row, column - 1]));
                        }

                    }

                }

                //Ha piros jatekos lepett
                else
                {
                    board[row, column] = FieldState.UpDownRed;
                    if (FieldChanged is not null)
                    {
                        FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                    }

                    if (board[row - 1, column - 1] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty && board[row, column - 2] != FieldState.Empty)
                    {
                        board[row, column - 1] = FieldState.FullRed;
                        madePoint++;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column - 1, board[row, column - 1]));
                        }

                    }
                }
            }

            //Nem a palya szele
            else
            {
                //Ha paratlan az oszlopindex (vizszintes vonalat huznak)
                if (column % 2 == 1)
                {
                    //Ha kek jatekos lepett
                    if (onPlayer == 0)
                    {
                        board[row, column] = FieldState.LeftRightBlue;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                        }

                        //Lefele vizsgalat
                        if (board[row - 2, column] != FieldState.Empty && board[row - 1, column - 1] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty)
                        {
                            board[row - 1, column] = FieldState.FullBlue;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row - 1, column, board[row - 1, column]));
                            }

                        }

                        //Felfele vizsgalat
                        if (board[row + 2, column] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty)
                        {
                            board[row + 1, column] = FieldState.FullBlue;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row + 1, column, board[row + 1, column]));
                            }

                        }

                    }

                    //Ha piros jatekos lepett
                    else
                    {
                        board[row, column] = FieldState.LeftRightRed;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                        }

                        //Lefele vizsgalat
                        if (board[row - 2, column] != FieldState.Empty && board[row - 1, column - 1] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty)
                        {
                            board[row - 1, column] = FieldState.FullRed;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row - 1, column, board[row - 1, column]));
                            }

                        }

                        //Felfele vizsgalat
                        if (board[row + 2, column] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty)
                        {
                            board[row + 1, column] = FieldState.FullRed;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row + 1, column, board[row + 1, column]));
                            }

                        }
                    }
                }

                //Ha paros az oszlopindex (fuggoleges vonalat huznak)
                else
                {
                    //Ha kek jatekos lepett
                    if (onPlayer == 0)
                    {
                        board[row, column] = FieldState.UpDownBlue;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                        }


                        //Balra vizsgalat
                        if (board[row, column - 2] != FieldState.Empty && board[row - 1, column - 1] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty)
                        {
                            board[row, column - 1] = FieldState.FullBlue;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row, column - 1, board[row, column - 1]));
                            }

                        }

                        //Jobbra vizsgalat
                        if (board[row, column + 2] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty)
                        {
                            board[row, column + 1] = FieldState.FullBlue;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row, column + 1, board[row, column + 1]));
                            }

                        }

                    }

                    //Ha piros jatekos lepett
                    else
                    {
                        board[row, column] = FieldState.UpDownRed;
                        if (FieldChanged is not null)
                        {
                            FieldChanged(this, new FieldChangedEventArgs(row, column, board[row, column]));
                        }


                        //Balra vizsgalat
                        if (board[row, column - 2] != FieldState.Empty && board[row - 1, column - 1] != FieldState.Empty && board[row + 1, column - 1] != FieldState.Empty)
                        {
                            board[row, column - 1] = FieldState.FullRed;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row, column - 1, board[row, column - 1]));

                            }
                        }

                        //Jobbra vizsgalat
                        if (board[row, column + 2] != FieldState.Empty && board[row - 1, column + 1] != FieldState.Empty && board[row + 1, column + 1] != FieldState.Empty)
                        {
                            board[row, column + 1] = FieldState.FullRed;
                            madePoint++;
                            if (FieldChanged is not null)
                            {
                                FieldChanged(this, new FieldChangedEventArgs(row, column + 1, board[row, column + 1]));
                            }
                        }
                    }

                }

            }


            if (madePoint == 0)
            {
                onPlayer = (onPlayer + 1) % 2;

            }
            else
            {
                if (onPlayer == 0) { playerBluePoints += madePoint; }
                else { playerRedPoints += madePoint; }

            }

            setStatusStripText();
            checkGameOver();
        }

        //Method to load older game from file 
        public void loadGame(string path)
        {
            GameStatus gameStatus = dataAccess.LoadGame(path);
            FieldState[,] tableWithFieldStates = new FieldState[gameStatus.Size, gameStatus.Size];

            for (int i = 0; i < gameStatus.Size; i++)
            {
                for (int j = 0; j < gameStatus.Size; j++)
                {
                    tableWithFieldStates[i, j] = (FieldState)gameStatus.Table[i * gameStatus.Size + j];
                }

            }

            //Modell adattagok megvaltoztatasa
            board = tableWithFieldStates;
            size = gameStatus.Size;
            playerBluePoints = gameStatus.PlayerBlue;
            playerRedPoints = gameStatus.PlayerRed;
            onPlayer = gameStatus.playerToMove;

            //Change the view

            if (GameStarted is not null)
            {
                GameStarted(this, new GameStartedEventArgs(gameStatus.Size, tableWithFieldStates));
            }
            if (StatusStripChanged is not null)
            {
                StatusStripChanged(this, new StatusStripChangedEventArgs(gameStatus.PlayerBlue, gameStatus.PlayerRed, gameStatus.playerToMove));
            }
        }

        //Method to save the game to file
        public void saveGame(string path)
        {
            List<int> table = new List<int>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    table.Add((int)board[i, j]);
                }
            }
            dataAccess.SaveGame(path, size, table, playerBluePoints, playerRedPoints, onPlayer);
        }

        //Method to refresh the points and the player have to move next
        public void setStatusStripText()
        {
            if (StatusStripChanged is not null)
            {
                StatusStripChanged(this, new StatusStripChangedEventArgs(playerBluePoints, playerRedPoints, onPlayer));

            }
        }

        // Method to check if the game is over
        public void checkGameOver()
        {
            bool allSquaresColorized = true;

            for (int i = 0; i < size && allSquaresColorized; i++)
            {
                for (int j = 0; j < size && allSquaresColorized; j++)
                {
                    if (i % 2 == 1 && j % 2 == 1)
                    {
                        allSquaresColorized = allSquaresColorized && board[i, j] != FieldState.Grey;
                    }
                }
            }

            if (allSquaresColorized && GameOver is not null)
            {
                GameOver(this, new GameOverEventArgs(playerBluePoints, playerRedPoints));
            }
        }
    }
}