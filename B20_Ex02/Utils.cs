using System;
using System.Collections.Generic;

namespace B20_Ex02
{
    public class Utils
    {
        private static string m_FirstPlayer;
        private static string m_SecondPlayer;
        private static byte m_GameType;
        private static byte m_BoardHeight;
        private static byte m_BoardWidth;
        private static Dictionary<char, byte> m_LetterToIndex = new Dictionary<char, byte>()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 },
            { 'E', 4 },
            { 'F', 5 }
        };

        public static string FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }
            
            set
            {
                m_FirstPlayer = value;
            }
        }

        public static string SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }
            
            set
            {
                m_SecondPlayer = value;
            }
        }

        public static byte GameType
        {
            get
            {
                return m_GameType;
            }
            
            set
            {
                m_GameType = value;
            }
        }

        public static byte BoardHeight
        {
            get
            {
                return m_BoardHeight;
            }
            
            set
            {
                m_BoardHeight = value;
            }
        }

        public static byte BoardWidth
        {
            get
            {
                return m_BoardWidth;
            }
            
            set
            {
                m_BoardWidth = value;
            }
        } 

        public static Dictionary<char, byte> LetterToIndex
        {
            get
            {
                return m_LetterToIndex;
            }
        }

        public static bool CharExistsInArray(char[] i_LettersArray, char i_Letter)
        {
            bool charExistsInArray = true;
            
            if(Array.IndexOf(i_LettersArray, i_Letter) == -1)
            {
                return !charExistsInArray;
            }

            return charExistsInArray;
        } 

        public static bool CharExistsInMatrix(char[,] i_LettersMatrix, char i_Letter)
        {
            bool charExistsInMatrix = true;

            for (int i = 0; i < m_BoardHeight; i++)
            {
                for(int j = 0; j < m_BoardWidth; j++)
                {
                    if(i_LettersMatrix[i, j] == i_Letter)
                    {
                        return charExistsInMatrix;
                    }
                }
            }

            return !charExistsInMatrix;
        }

        public static bool cellIsTaken(byte i_RowIndex, byte i_ColIndex)
        {
            bool cellIsTaken = true;
            
            if(GameDataMatrix.DisplayMatrix[i_RowIndex, i_ColIndex] != ' ')
            {
                return cellIsTaken;
            }

            return !cellIsTaken;
        }
    } 
}
