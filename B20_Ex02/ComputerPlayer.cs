using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class ComputerPlayer
    {
        private static List<string> s_AvailableCellsInBoard = new List<string>();
        private static string s_FirstGuess;
        private static string s_SecondGuess;

        public static void StartComputer()
        {
            char currentLetter = 'A'; 

            for(byte i = 0; i < Utils.BoardWidth; i++)
            {
                for(byte j = 1; j <= Utils.BoardHeight; j++)
                {
                    StringBuilder createCellPlace = new StringBuilder();
                    createCellPlace.Append(currentLetter);
                    createCellPlace.Append(j);
                    s_AvailableCellsInBoard.Add(createCellPlace.ToString());
                }

                currentLetter++;
            }
        }  

        public static string FirstGuess
        {
            get
            {
                s_FirstGuess = getRandomCellsPlace();
                Console.WriteLine("Computer first guess: " + s_FirstGuess);
                System.Threading.Thread.Sleep(1500);
                return s_FirstGuess;
            }
        } 

        public static string SecondGuess
        {
            get
            {
                s_SecondGuess = getRandomCellsPlace();
                Console.WriteLine("Computer second guess: " + s_SecondGuess);
                System.Threading.Thread.Sleep(1500);
                return s_SecondGuess;
            }
        } 

        public static void RemoveFromAvailableCellsInBoard(string i_LocationInBoard)
        {
            s_AvailableCellsInBoard.Remove(i_LocationInBoard);
        }

        private static string getRandomCellsPlace()
        {
            Random rand = new Random();
            int nodeIndex = rand.Next(s_AvailableCellsInBoard.Count); 
            string randomLocation = s_AvailableCellsInBoard[nodeIndex];
            s_AvailableCellsInBoard.Remove(randomLocation);
            return randomLocation;
        } 

        public static void ReInsertValues()
        {
            s_AvailableCellsInBoard.Add(s_FirstGuess);
            s_AvailableCellsInBoard.Add(s_SecondGuess);
        }
    }
}
