using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class GameLogic
    { 
        public static byte m_gameTurn;
        public static string m_currentPlayer;
        public static string m_currentPlayerFirstMove;
        public static string m_currentPlayerSecondMove;
        public static byte m_firstPlayerScore = 0;
        public static byte m_secondPlayerScore = 0;
        public static bool m_hadSuccess = false;
        public static byte[] m_firstCellPick;
        public static byte[] m_secondCellPick;



        public static void setCurrentPlayer()
        {
            if (m_gameTurn % 2 == 0)
            {
               m_currentPlayer = Utils.firstPlayer;
            }
            else
            {
                m_currentPlayer = Utils.secondPlayer;
            }
        }

        public static void deleteLastPlayerChoices()
        {
            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            GameDataMatrix.setDisplayMatrix(m_firstCellPick[0], m_firstCellPick[1], ' ');
            GameDataMatrix.setDisplayMatrix(m_secondCellPick[0], m_secondCellPick[1], ' ');
            DrawBoard.createBoard();
        }
        
        public static void matchingPair()
        {
            if(GameDataMatrix.dataMatrix[m_firstCellPick[0], m_firstCellPick[1]] == GameDataMatrix.dataMatrix[m_secondCellPick[0], m_secondCellPick[1]])
            {
                if(m_currentPlayer == Utils.firstPlayer)
                {
                    m_firstPlayerScore++;                   
                    if(Utils.secondPlayer == "computer")
                    {
                        ComputerPlayer.removeFromAvailableCellsInBoard(m_currentPlayerFirstMove);
                        ComputerPlayer.removeFromAvailableCellsInBoard(m_currentPlayerSecondMove);
                    }
                }
                else
                {
                    m_secondPlayerScore++;                    
                }
                m_gameTurn--;
            }
            else
            {
                deleteLastPlayerChoices();
                if(Utils.secondPlayer == "computer" && GameLogic.m_currentPlayer == "computer")
                {      
                    ComputerPlayer.reInsertValues();
                }
            }
        } 

        public static string guessNextMove( byte i_numberOfGuess)
        {
            if (GameLogic.m_currentPlayer == "computer")
            {                
                if (i_numberOfGuess == 0)
                {
                    return ComputerPlayer.firstGuess;
                }
                else
                {
                    return ComputerPlayer.secondGuess;
                }
            }
            else
            {
                return UI.GetCurrentMove(GameLogic.m_currentPlayer);
            }
        } 

        public static string getNextMove(byte i_choiceNumber)
        {
            string move = GameLogic.guessNextMove(i_choiceNumber);
            bool moveValid = UI.IsValidMove(move);
            while (!moveValid)
            {
                move = GameLogic.guessNextMove(i_choiceNumber);
                moveValid = UI.IsValidMove(move);
            }
            return move;
        } 

        public static void gameResult()
        {
            if (m_firstPlayerScore > m_secondPlayerScore)
            {
                Console.WriteLine("First player won");
            }
            else if (m_firstPlayerScore < m_secondPlayerScore)
            {
                Console.WriteLine("Second player won");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }


    } 

    
}
