using System;
using System.Collections.Generic;
using System.Text;
//delete

namespace B20_Ex02
{
    public class ComputerPlayer
    {
        private static List<string> m_AvailableCellsInBoard = new List<string>();
        private static string m_FirstGuess;
        private static string m_SecondGuess;

        public ComputerPlayer()
        {
            char currentLetter = 'A'; 

            for(byte i = 0; i < Utils.BoardWidth; i++)
            {
                for(byte j = 1; j <= Utils.BoardHeight; j++)
                {
                    StringBuilder createCellPlace = new StringBuilder();
                    createCellPlace.Append(currentLetter);
                    createCellPlace.Append(j);
                    m_AvailableCellsInBoard.Add(createCellPlace.ToString());
                }

                currentLetter++;
            }
        }  

        public static string FirstGuess
        {
            get
            {
                m_FirstGuess = getRandomCellsPlace();
                Console.WriteLine("First: " + m_FirstGuess);
                return m_FirstGuess;
            }
        } 

        public static string SecondGuess
        {
            get
            {
                m_SecondGuess = getRandomCellsPlace();
                Console.WriteLine("Second: " + m_SecondGuess);                
                return m_SecondGuess;
            }
        } 

        public static void RemoveFromAvailableCellsInBoard(string i_LocationInBoard)
        {
            m_AvailableCellsInBoard.Remove(i_LocationInBoard);
        }

        private static string getRandomCellsPlace()
        {
            Random rand = new Random();
            int nodeIndex = rand.Next(m_AvailableCellsInBoard.Count); 
            string randomLocation = m_AvailableCellsInBoard[nodeIndex];
            m_AvailableCellsInBoard.Remove(randomLocation);
            return randomLocation;
        } 

        public static void ReInsertValues()
        {
            m_AvailableCellsInBoard.Add(m_FirstGuess);
            m_AvailableCellsInBoard.Add(m_SecondGuess);
        }
    }
}
