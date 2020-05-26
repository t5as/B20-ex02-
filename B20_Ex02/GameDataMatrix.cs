using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class GameDataMatrix
    {
        private static char[,] m_DataMatrix;
        private static char[,] m_DisplayMatrix;
        private byte m_RowsCount;
        private byte m_ColumnsCount;
        private char[] m_RandomLetters;
        private Random rand = new Random();

        public GameDataMatrix()
        {
            m_RowsCount = Utils.BoardHeight;
            m_ColumnsCount = Utils.BoardWidth;
            m_DataMatrix = new char[m_RowsCount, m_ColumnsCount];
            m_DisplayMatrix = new char[m_RowsCount, m_ColumnsCount];
            m_RandomLetters = new char[(m_RowsCount * m_ColumnsCount)];
        }  

        public static char[,] DataMatrix
        {
            get
            {
                return m_DataMatrix;
            }
        } 

        public static char[,] DisplayMatrix
        {
            get
            {
                return m_DisplayMatrix;
            }
        } 

        public static void SetDisplayMatrix(byte i_RowIndex, byte i_ColIndex, char i_Value)
        {
            m_DisplayMatrix[i_RowIndex, i_ColIndex] = i_Value;
        }

        private char getRandomLetter()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexChoice = rand.Next(0, letters.Length - 1);
            return letters[indexChoice];
        } 
        
        private void setRandomLettersArray()
        {
            char letter;

            for(byte i = 0; i < m_RandomLetters.Length / 2; i++)
            {
                letter = getRandomLetter();

                while(Utils.CharExistsInArray(m_RandomLetters, letter))
                {
                    letter = getRandomLetter();
                }

                m_RandomLetters[2 * i] = letter;
                m_RandomLetters[(2 * i) + 1] = letter;                
            }
        }

        private void shuffleLettersArray()
        {
            int numberOfElements = m_RandomLetters.Length; 

            while(numberOfElements > 1)
            {
                int indexInArray = rand.Next(numberOfElements);
                numberOfElements -= 1;
                char arrayElementHolder = m_RandomLetters[numberOfElements];
                m_RandomLetters[numberOfElements] = m_RandomLetters[indexInArray];
                m_RandomLetters[indexInArray] = arrayElementHolder;
            }
        }

        public void SetMatrices()
        {
            setRandomLettersArray();
            shuffleLettersArray();
            byte indexOfLettersArray = 0;   
            
            for(byte i = 0; i < m_RowsCount; i++)
            {
                for(byte j = 0; j < m_ColumnsCount; j++)
                {
                    m_DataMatrix[i, j] = m_RandomLetters[indexOfLettersArray];                   
                    m_DisplayMatrix[i, j] = ' ';
                    indexOfLettersArray++;
                }
            }
        }
    }
}
