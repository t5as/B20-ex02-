using System;

namespace B20_Ex02
{
    public class UI
    {
       public UI()
        {
        }

        public void StartGame()
        {
            Utils.firstPlayer = InitializePlayer("first player");
            Utils.gameType = InitializeGameType();

            if (Utils.gameType == 2)
            {
                Utils.secondPlayer = InitializePlayer("second player");
            }
            else
            {
                Utils.secondPlayer = "Computer";
            }

            InitializeBoardDimensions();
            int turn = 0;
            string currentPlayer;
            while(turn < 10)
            {
                if((turn % 2) == 0)
                {
                    currentPlayer = Utils.firstPlayer;
                }
                else
                {
                    currentPlayer = Utils.secondPlayer;
                }
                
                for (int i = 0; i < 2; i++)
                {
                    string move = GetCurrentMove(currentPlayer);
                    bool moveValid = IsValidMove(move);
                    while (!moveValid)
                    {
                        move = GetCurrentMove(currentPlayer);
                        moveValid = IsValidMove(move);
                    }
                }

                turn++;
            }
        }

        public static string InitializePlayer(string io_playerNumber)
        {
            string player = GetInputName(io_playerNumber);
            bool playerValid = IsValidName(player);
            while (!playerValid)
            {
                player = GetInputName(io_playerNumber);
                playerValid = IsValidName(player);
            }

            return player;
        }

        public static byte InitializeGameType()
        {
            string gameType = GetGameType();
            byte byteGameType = IsValidGameType(gameType);
            while (byteGameType == 0)
            {
                gameType = GetGameType();
                byteGameType = IsValidGameType(gameType);
            }

            return byteGameType;
        }

        public static void InitializeBoardDimensions()
        {
            byte byteBoardHeight = 0;
            byte byteBoardWidth = 0;
            bool cellNumberEven = false;
            while (!cellNumberEven)
            {
                string boardHeight = GetBoardDimension("height");
                byteBoardHeight = IsDimensionValid(boardHeight);
                while (byteBoardHeight == 0)
                {
                    boardHeight = GetBoardDimension("height");
                    byteBoardHeight = IsDimensionValid(boardHeight);
                }

                string boardWidth = GetBoardDimension("width");
                byteBoardWidth = IsDimensionValid(boardWidth);
                while (byteBoardWidth == 0)
                {
                    boardWidth = GetBoardDimension("width");
                    byteBoardWidth = IsDimensionValid(boardWidth);
                }

                cellNumberEven = IsCellNumberEven(byteBoardHeight, byteBoardWidth);
            }

            Utils.boardHeight = byteBoardHeight;
            Utils.boardWidth = byteBoardWidth;
        }

        public static string GetInputName(string io_playerNumber)
        {
            Console.WriteLine(string.Format(@"Please enter {0} name", io_playerNumber));
            string strInputName = Console.ReadLine();

            return strInputName;
        }

        public static bool IsValidName(string i_StrInputName)
        {
            bool validName = true;

            if (i_StrInputName.Length < 2)
            {
                Console.WriteLine("Invalid name - Name should contain at least two letters");
                return !validName;
            }

            if (!char.IsLetter(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should contain only English letters");
                return !validName;
            }

            if (!char.IsUpper(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should start in a capital English letter");
                return !validName;
            }

            for (int i = 1; i < i_StrInputName.Length; i++)
            {
                if (!char.IsLetter(i_StrInputName[i]))
                {
                    Console.WriteLine("Invalid name - Name should contain only English letters");
                    return !validName;
                }
                
                if (!char.IsLower(i_StrInputName[i]))
                {
                    Console.WriteLine(
                        "Invalid name - Name should start in a capital English letter, followed by lower English letter");
                    return !validName;
                }
            }

            return validName;
        }

        public static string GetGameType()
        {
            Console.WriteLine(string.Format(@"Hello {0}, 
If you wish to play against the computer - press 1 
If you wish to play against a second player - press 2", Utils.firstPlayer));
            string gameType = Console.ReadLine();

            return gameType;
        }

        public static byte IsValidGameType(string i_GameType)
        {
            if (i_GameType.Length != 1)
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            if (i_GameType != "1" && i_GameType != "2")
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            return byte.Parse(i_GameType);
        }

        public static string GetBoardDimension(string io_dimension)
        {
            Console.WriteLine(string.Format(@"Please enter desired board {0} between 4 to 6", io_dimension));
            string boardHeight = Console.ReadLine();

            return boardHeight;
        }

        public static byte IsDimensionValid(string i_Dimension)
        {
            if (i_Dimension.Length != 1)
            {
                Console.WriteLine("Invalid entry, please try again");
                return 0;
            }

            if (!char.IsDigit(char.Parse(i_Dimension)))
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            byte byteDimension = byte.Parse(i_Dimension);

            if (byteDimension < 4 || byteDimension > 6)
            {
                Console.WriteLine("Invalid entry, please try again");
                return 0;
            }

            return byteDimension;
        }

        public static bool IsCellNumberEven(byte i_Height, byte i_Width)
        {
            bool cellNumberEven = true;

            if (((i_Height * i_Width) % 2) != 0)
            {
                Console.WriteLine("The board contains odd number of cells - Please choose height and width again");
                return !cellNumberEven;
            }

            return cellNumberEven;
        }

        public static string GetCurrentMove(string i_player)
        {
            Console.WriteLine(string.Format(@"Hello {0}, 
Enter your next move ", i_player));
            string currentMove = Console.ReadLine();

            return currentMove;
        }

        public static bool IsValidMove(string i_move)
        {
            bool validMove = true;
            
            if (i_move.Length != 2)
            {
                Console.WriteLine("Invalid move length, please try again");
                return !validMove;
            }

            if (!char.IsLetter(i_move[0]))
            {
                Console.WriteLine("There is no such column, please enter a valid board location");
                return !validMove;
            }

            if (!char.IsDigit(i_move[1]))
            {
                Console.WriteLine("There is no such line, please enter a valid board location");
                return !validMove;
            }

            int[] move = moveToInt(i_move);
            int column = move[0] + 1;
            int line = move[1] + 1;

            if (column < 1 || column > Utils.boardWidth)
            {
                Console.WriteLine("There is no such column, please enter a valid board location");
                return !validMove;
            }

            if (line < 1 || line > Utils.boardHeight)
            {
                Console.WriteLine("There is no such line, please enter a valid board location");
                return !validMove;
            }

            return validMove;
        }

        public static int[] moveToInt(string i_move)
        {
            int[] move = { Utils.letterToIndex[i_move[0]], (int.Parse(i_move[1].ToString()) - 1)};
            return move;
        }
    }
}
