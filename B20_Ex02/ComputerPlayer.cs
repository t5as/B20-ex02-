using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class ComputerPlayer
    {
        private static List<string> m_availableCellsInBoard = new List<string>();
        private static string m_firstGuess;
        private static string m_secondGuess;

        public ComputerPlayer()
        {
            char currentLetter = 'A'; 
            for(byte i = 0; i < Utils.boardWidth; i++)
            {
                for(byte j = 1; j <= Utils.boardHeight; j++)
                {
                    StringBuilder createCellPlace = new StringBuilder();
                    createCellPlace.Append(currentLetter);
                    createCellPlace.Append(j);
                    m_availableCellsInBoard.Add(createCellPlace.ToString());
                }
                currentLetter++;
            }
        }  

        public string firstGuess
        {
            get
            {
                m_firstGuess = getRandomCellsPlace();
                Console.WriteLine("First: " + m_firstGuess);
                return m_firstGuess;
            }
        } 

        public string secondGuess
        {
            get
            {
                m_secondGuess = getRandomCellsPlace();
                Console.WriteLine("Second: " + m_secondGuess);
                return m_secondGuess;
            }
        } 

        public static void removeFromAvailableCellsInBoard(string i_locationInBoard)
        {
            m_availableCellsInBoard.Remove(i_locationInBoard);
        }

        private string getRandomCellsPlace()
        {
            Random rand = new Random();
            int nodeIndex = rand.Next(m_availableCellsInBoard.Count); 
            string randomLocation = m_availableCellsInBoard[nodeIndex];
            m_availableCellsInBoard.Remove(randomLocation);
            return randomLocation;
        } 

        public static void reInsertValues()
        {
            m_availableCellsInBoard.Add(m_firstGuess);
            m_availableCellsInBoard.Add(m_secondGuess);
        } 


    }
}
