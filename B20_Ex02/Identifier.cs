using System;

namespace B20_Ex02
{
    public class Identifier
    {
        public static byte[] StartGame()
        {
            string firstPlayer = InitializePlayer();
            byte gameType = InitializeGameType();

            if (gameType == 2)
            {
                string secondPlayer = InitializePlayer();
            }

            byte[] dimensions = InitializeBoardDimensions();
            return dimensions;
        }

        public static string InitializePlayer()
        {
            string player = GetInputName();
            bool playerValid = IsValidName(player);
            while (!playerValid)
            {
                player = GetInputName();
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

        public static byte[] InitializeBoardDimensions()
        {
            byte byteBoardHeight = 0;
            byte byteBoardWidth = 0;
            bool cellNumberEven = false;
            while (!cellNumberEven)
            {
                string boardHeight = GetBoardHeight();
                byteBoardHeight = IsDimensionValid(boardHeight);
                while (byteBoardHeight == 0)
                {
                    boardHeight = GetBoardHeight();
                    byteBoardHeight = IsDimensionValid(boardHeight);
                }

                string boardWidth = GetBoardWidth();
                byteBoardWidth = IsDimensionValid(boardWidth);
                while (byteBoardWidth == 0)
                {
                    boardWidth = GetBoardHeight();
                    byteBoardWidth = IsDimensionValid(boardWidth);
                }

                cellNumberEven = IsCellNumberEven(byteBoardHeight, byteBoardWidth);
            }

            byte[] dimensions = { byteBoardHeight, byteBoardWidth };
            return dimensions;
        }

        public static string GetInputName()
        {
            Console.WriteLine("Please enter your name");
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
            Console.WriteLine(
                "If you wish to play against the computer - press 1. If you wish to play against a second player - press 2");
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

        public static string GetBoardHeight()
        {
            Console.WriteLine("Please enter board height between 4 to 6");
            string boardHeight = Console.ReadLine();

            return boardHeight;
        }

        public static string GetBoardWidth()
        {
            Console.WriteLine("Please enter board width between 4 to 6");
            string boardWidth = Console.ReadLine();

            return boardWidth;
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
    }
}
