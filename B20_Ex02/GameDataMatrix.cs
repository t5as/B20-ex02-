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
        private int[] m_timesPlacedLetter;
        private Random rand = new Random();

        public GameDataMatrix(byte i_rowsCount, byte i_columnsCount)
        {
            m_rowsCount = i_rowsCount;
            m_columnsCount = i_columnsCount;
            m_dataMatrix = new char[m_rowsCount, m_columnsCount];
            m_randomLetters = new char[(m_rowsCount * m_columnsCount) / 2];
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
            for (byte i = 0; i < m_randomLetters.Length; i++)
            {
                letter = getRandomLetter();
                while (valueExistsInArray(letter))
                {
                    letter = getRandomLetter();
                }

                m_randomLetters[i] = letter;
            }
        } 

        private void setDataMatrix()
        {
            for(byte i = 0; i < m_rowsCount; i++)
            {
                for(byte j = 0; j < m_columnsCount; j++)
                {
                    int randomLetterPlace = rand.Next(0, m_randomLetters.Length - 1);
                    while(m_timesPlacedLetter[randomLetterPlace] == 2)
                    {
                        randomLetterPlace = rand.Next(0, m_randomLetters.Length - 1);
                    }

                    m_dataMatrix[i, j] = m_randomLetters[randomLetterPlace];
                    m_timesPlacedLetter[randomLetterPlace]++;
                }
            }
        }
    }
}
