using System;

namespace B20_Ex02
{
    public class UI
    {    
        public static void StartGame()
        {
            Utils.FirstPlayer = initializePlayer("first player");
            Utils.GameType = initializeGameType();

            Utils.SecondPlayer = Utils.GameType == 2 ? initializePlayer("second player") : "computer";         
            initializeBoardDimensions();
        }

        private static string initializePlayer(string i_PlayerNumber)
        {
            string player = getInputName(i_PlayerNumber);
            bool playerValid = IsValidName(player);

            while(!playerValid)
            {
                player = getInputName(i_PlayerNumber);
                playerValid = IsValidName(player);
            }

            return player;
        }

        private static byte initializeGameType()
        {
            string gameType = getGameType();
            byte byteGameType = isValidGameType(gameType);

            while(byteGameType == 0)
            {
                gameType = getGameType();
                byteGameType = isValidGameType(gameType);
            }

            return byteGameType;
        }

        private static void initializeBoardDimensions()
        {
            byte byteBoardHeight = 0;
            byte byteBoardWidth = 0;
            bool cellNumberEven = false;

            while(!cellNumberEven)
            {
                string boardHeight = getBoardDimension("height");
                byteBoardHeight = isDimensionValid(boardHeight);

                while(byteBoardHeight == 0)
                {
                    boardHeight = getBoardDimension("height");
                    byteBoardHeight = isDimensionValid(boardHeight);
                }

                string boardWidth = getBoardDimension("width");
                byteBoardWidth = isDimensionValid(boardWidth);

                while(byteBoardWidth == 0)
                {
                    boardWidth = getBoardDimension("width");
                    byteBoardWidth = isDimensionValid(boardWidth);
                }

                cellNumberEven = isCellNumberEven(byteBoardHeight, byteBoardWidth);
            }

            Utils.BoardHeight = byteBoardHeight;
            Utils.BoardWidth = byteBoardWidth;
        }

        private static string getInputName(string i_PlayerNumber)
        {
            Console.WriteLine(string.Format(@"Please enter {0} name", i_PlayerNumber));
            string strInputName = Console.ReadLine();

            return strInputName;
        }

        public static bool IsValidName(string i_StrInputName)
        {
            const bool v_ValidName = true;

            if(i_StrInputName.Length < 2)
            {
                Console.WriteLine("Invalid name - Name should contain at least two letters");
                return !v_ValidName;
            }

            if(!char.IsLetter(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should contain only English letters");
                return !v_ValidName;
            }

            if(!char.IsUpper(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should start with a capital English letter");
                return !v_ValidName;
            }

            for(int i = 1; i < i_StrInputName.Length; i++)
            {
                if (!char.IsLetter(i_StrInputName[i]))
                {
                    Console.WriteLine("Invalid name - Name should contain only English letters");
                    return !v_ValidName;
                }
                
                if (!char.IsLower(i_StrInputName[i]))
                {
                    Console.WriteLine(
                        "Invalid name - Name should start with a capital English letter, followed by lower English letter");
                    return !v_ValidName;
                }
            }

            return v_ValidName;
        }

        private static string getGameType()
        {
            Console.WriteLine(string.Format(
                @"Hello {0}, 
If you wish to play against the computer - press 1 
If you wish to play against a second player - press 2", 
                Utils.FirstPlayer));
            string gameType = Console.ReadLine();

            return gameType;
        }

        private static byte isValidGameType(string i_GameType)
        {
            if(i_GameType.Length != 1)
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            if(i_GameType != "1" && i_GameType != "2")
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            return byte.Parse(i_GameType);
        }

        private static string getBoardDimension(string i_Dimension)
        {
            Console.WriteLine(string.Format(@"Please enter desired board {0} between 4 to 6", i_Dimension));
            string boardHeight = Console.ReadLine();

            return boardHeight;
        }

        private static byte isDimensionValid(string i_Dimension)
        {
            if(i_Dimension.Length != 1)
            {
                Console.WriteLine("Invalid entry, please try again");
                return 0;
            }

            if(!char.IsDigit(char.Parse(i_Dimension)))
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            byte byteDimension = byte.Parse(i_Dimension);

            if(byteDimension < 4 || byteDimension > 6)
            {
                Console.WriteLine("Invalid entry, please try again");
                return 0;
            }

            return byteDimension;
        }

        private static bool isCellNumberEven(byte i_Height, byte i_Width)
        {
            const bool v_CellNumberEven = true;

            if(((i_Height * i_Width) % 2) != 0)
            {
                Console.WriteLine("The board contains odd number of cells - Please choose height and width again");
                return !v_CellNumberEven;
            }

            return v_CellNumberEven;
        }

        public static string GetCurrentMove(string i_Player)
        {
            Console.WriteLine(string.Format(@"Hello {0}, Enter your next move ", i_Player));
            string currentMove = Console.ReadLine();

            if(currentMove == "Q")
            {
                Environment.Exit(0);
            }

            return currentMove;
        }

        public static bool IsValidMove(string i_Move)
        {
            const bool v_ValidMove = true;
            
            if(i_Move.Length != 2)
            {
                Console.WriteLine("Invalid move length, please try again");
                return !v_ValidMove;
            }

            if(!char.IsLetter(i_Move[0]) || char.IsLower(i_Move[0]) || !char.IsDigit(i_Move[1]))
            {
                Console.WriteLine("Invalid move, please enter a valid board entry");
                return !v_ValidMove;
            }

            byte[] move = MoveToByteArray(i_Move);
            byte column = (byte)(move[1] + 1);
            byte line = (byte)(move[0] + 1);

            if(column < 1 || column > Utils.BoardWidth)
            {
                Console.WriteLine("There is no such column, please enter a valid board entry");
                return !v_ValidMove;
            }

            if(line < 1 || line > Utils.BoardHeight)
            {
                Console.WriteLine("There is no such line, please enter a valid board entry");
                return !v_ValidMove;
            }

            if(Utils.cellIsTaken((byte)(line - 1), (byte)(column - 1)))
            {
                Console.WriteLine("The cell has already been used, please re-enter a board entry");
                return !v_ValidMove;
            }

            return v_ValidMove;
        }

        public static byte[] MoveToByteArray(string i_Move)
        {
            int index = (int)((i_Move[0] % 32) - 1); 
            byte[] move = { (byte)(int.Parse(i_Move[1].ToString()) - 1), (byte)index };
            return move;
        }

        public static int StartNewGame()
        {
            Console.WriteLine("If you wish to start a new game - press 1. else - press 0.");
            string start = Console.ReadLine();
            
            if(start != "1" && start != "0")
            {
                Console.WriteLine("Invalid value. Please try again");
                return -1;
            }

            return int.Parse(start);
        }
    }
}