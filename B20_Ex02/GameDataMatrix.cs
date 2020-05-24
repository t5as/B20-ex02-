using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class GameDataMatrix
    {
        private byte m_rowsCount;
        private byte m_columnsCount;
        private static char[,] m_dataMatrix;
        private static char[,] m_displayMatrix;
        private char[] m_randomLetters;
        private Random rand = new Random();

        public GameDataMatrix()
        {
            m_rowsCount = Utils.boardHeight;
            m_columnsCount = Utils.boardWidth;
            m_dataMatrix = new char[m_rowsCount, m_columnsCount];
            m_displayMatrix = new char[m_rowsCount, m_columnsCount];
            m_randomLetters = new char[(m_rowsCount * m_columnsCount)];
        }  

        public static char[,] dataMatrix
        {
            get
            {
                return m_dataMatrix;
            }
        } 

        public static char[,] displayMatrix
        {
            get
            {
                return m_displayMatrix;
            }
        } 

        public static void setDisplayMatrix(byte i_rowIndex, byte i_colIndex, char i_value)
        {
            m_displayMatrix[i_rowIndex, i_colIndex] = i_value;
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
            for (byte i = 0; i < m_randomLetters.Length / 2; i++)
            {
                letter = getRandomLetter();
                while (Utils.charExistsInArray(m_randomLetters,letter))
                {
                    letter = getRandomLetter();
                }

                m_randomLetters[2 * i] = letter;
                m_randomLetters[2 * i + 1] = letter;                
            }
        }

        private void shuffleLettersArray()
        {
            int numberOfElements = m_randomLetters.Length; 
            while (numberOfElements > 1)
            {
                int indexInArray = rand.Next(numberOfElements);
                numberOfElements -= 1;
                char arrayElementHolder = m_randomLetters[numberOfElements];
                m_randomLetters[numberOfElements] = m_randomLetters[indexInArray];
                m_randomLetters[indexInArray] = arrayElementHolder;

            }
        }

        public void setMatrices()
        {
            setRandomLettersArray();
            shuffleLettersArray();
            byte indexOfLettersArray = 0;            
            for (byte i = 0; i < m_rowsCount; i++)
            {
                for(byte j = 0; j < m_columnsCount; j++)
                {
                    m_dataMatrix[i, j] = m_randomLetters[indexOfLettersArray];                   
                    m_displayMatrix[i, j] = ' ';
                    indexOfLettersArray++;
                }
            }
        }
    }
}
