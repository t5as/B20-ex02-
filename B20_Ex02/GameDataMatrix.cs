using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class GameDataMatrix
    {
        private byte m_rowsCount;
        private byte m_columnsCount;
        private char[,] m_dataMatrix;
        private char[] m_randomLetters;
        private Random rand = new Random();

        public GameDataMatrix(byte i_rowsCount, byte i_columnsCount)
        {
            m_rowsCount = i_rowsCount;
            m_columnsCount = i_columnsCount;
            m_dataMatrix = new char[m_rowsCount, m_columnsCount];
            m_randomLetters = new char[(m_rowsCount * m_columnsCount)];
        }  

        public char[,] getDataMatrix
        {
            get
            {
                return m_dataMatrix;
            }
        }

        private char getRandomLetter()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int indexChoice = rand.Next(0, letters.Length - 1);
            return letters[indexChoice];
        } 
        
        private bool valueExistsInArray(char i_value)
        {
            if(Array.IndexOf(m_randomLetters, i_value) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void setRandomLettersArray()
        {
            char letter;
            for (byte i = 0; i < m_randomLetters.Length / 2; i++)
            {
                letter = getRandomLetter();
                while (valueExistsInArray(letter))
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

        public void setDataMatrix()
        {
            setRandomLettersArray();
            shuffleLettersArray();
            byte indexOfLettersArray = 0;            
            for (byte i = 0; i < m_rowsCount; i++)
            {
                for(byte j = 0; j < m_columnsCount; j++)
                {
                    m_dataMatrix[i, j] = m_randomLetters[indexOfLettersArray];
                    indexOfLettersArray++;
                }
            }
        }
    }
}
