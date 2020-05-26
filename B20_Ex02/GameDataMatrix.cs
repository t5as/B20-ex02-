using System;

namespace B20_Ex02
{
    public class GameDataMatrix
    {
        private static char[,] s_DataMatrix;
        private static char[,] s_DisplayMatrix;
        private readonly byte r_RowsCount;
        private readonly byte r_ColumnsCount;
        private readonly char[] r_RandomLetters;
        private readonly Random r_Random = new Random();

        public GameDataMatrix()
        {
            r_RowsCount = Utils.BoardHeight;
            r_ColumnsCount = Utils.BoardWidth;
            s_DataMatrix = new char[r_RowsCount, r_ColumnsCount];
            s_DisplayMatrix = new char[r_RowsCount, r_ColumnsCount];
            r_RandomLetters = new char[(r_RowsCount * r_ColumnsCount)];
            SetMatrices();
        }  

        public static char[,] DataMatrix
        {
            get
            {
                return s_DataMatrix;
            }
        } 

        public static char[,] DisplayMatrix
        {
            get
            {
                return s_DisplayMatrix;
            }
        } 

        public static void SetDisplayMatrix(byte i_RowIndex, byte i_ColIndex, char i_Value)
        {
            s_DisplayMatrix[i_RowIndex, i_ColIndex] = i_Value;
        }

        private char getRandomLetter()
        {
            const string v_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexChoice = r_Random.Next(0, v_Letters.Length - 1);
            return v_Letters[indexChoice];
        } 
        
        private void setRandomLettersArray()
        {
           for(byte i = 0; i < r_RandomLetters.Length / 2; i++)
           {
                char letter = getRandomLetter();

                while(Utils.CharExistsInArray(r_RandomLetters, letter))
                {
                    letter = getRandomLetter();
                }

                r_RandomLetters[2 * i] = letter;
                r_RandomLetters[(2 * i) + 1] = letter;                
           }
        }

        private void shuffleLettersArray()
        {
            int numberOfElements = r_RandomLetters.Length; 

            while(numberOfElements > 1)
            {
                int indexInArray = r_Random.Next(numberOfElements);
                numberOfElements -= 1;
                char arrayElementHolder = r_RandomLetters[numberOfElements];
                r_RandomLetters[numberOfElements] = r_RandomLetters[indexInArray];
                r_RandomLetters[indexInArray] = arrayElementHolder;
            }
        }

        public void SetMatrices()
        {
            setRandomLettersArray();
            shuffleLettersArray();
            byte indexOfLettersArray = 0;   
            
            for(byte i = 0; i < r_RowsCount; i++)
            {
                for(byte j = 0; j < r_ColumnsCount; j++)
                {
                    s_DataMatrix[i, j] = r_RandomLetters[indexOfLettersArray];                   
                    s_DisplayMatrix[i, j] = ' ';
                    indexOfLettersArray++;
                }
            }
        }
    }
}
