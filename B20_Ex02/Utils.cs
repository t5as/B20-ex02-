﻿using System;
using System.Collections.Generic;

namespace B20_Ex02
{
    public class Utils
    {
        private static readonly Dictionary<char, byte> sr_LetterToIndex = new Dictionary<char, byte>()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 },
            { 'E', 4 },
            { 'F', 5 }
        }; 

        private static string s_FirstPlayer;
        private static string s_SecondPlayer;
        private static byte s_GameType;
        private static byte s_BoardHeight;
        private static byte s_BoardWidth;

        public static string FirstPlayer
        {
            get
            {
                return s_FirstPlayer;
            }
            
            set
            {
                s_FirstPlayer = value;
            }
        }

        public static string SecondPlayer
        {
            get
            {
                return s_SecondPlayer;
            }
            
            set
            {
                s_SecondPlayer = value;
            }
        }

        public static byte GameType
        {
            get
            {
                return s_GameType;
            }
            
            set
            {
                s_GameType = value;
            }
        }

        public static byte BoardHeight
        {
            get
            {
                return s_BoardHeight;
            }
            
            set
            {
                s_BoardHeight = value;
            }
        }

        public static byte BoardWidth
        {
            get
            {
                return s_BoardWidth;
            }
            
            set
            {
                s_BoardWidth = value;
            }
        } 

        public static bool CharExistsInArray(char[] i_LettersArray, char i_Letter)
        {
            const bool v_CharExistsInArray = true;
            
            if(Array.IndexOf(i_LettersArray, i_Letter) == -1)
            {
                return !v_CharExistsInArray;
            }

            return v_CharExistsInArray;
        } 

        public static bool CharExistsInMatrix(char[,] i_LettersMatrix, char i_Letter)
        {
            const bool v_CharExistsInMatrix = true;

            for (int i = 0; i < s_BoardHeight; i++)
            {
                for(int j = 0; j < s_BoardWidth; j++)
                {
                    if(i_LettersMatrix[i, j] == i_Letter)
                    {
                        return v_CharExistsInMatrix;
                    }
                }
            }

            return !v_CharExistsInMatrix;
        }

        public static bool cellIsTaken(byte i_RowIndex, byte i_ColIndex)
        {
            const bool v_CellIsTaken = true;
            
            if(GameDataMatrix.DisplayMatrix[i_RowIndex, i_ColIndex] != ' ')
            {
                return v_CellIsTaken;
            }

            return !v_CellIsTaken;
        }
    } 
}