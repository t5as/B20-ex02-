using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class GameLogic
    { 
        public static byte m_turn;
        public static string m_currentPlayer;
        public static byte m_firstPlayerScore = 0;
        public static byte m_secondPlayerScore = 0;
        public static bool m_hadSuccess = false;
        public static byte[] m_firstCellPick;
        public static byte[] m_secondCellPick;



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
                    GameLogic.m_hadSuccess = true;
                }
                else
                {
                    m_secondPlayerScore++;
                    GameLogic.m_hadSuccess = true;
                }
                m_turn--;
            }
            else
            {
                deleteLastPlayerChoices();
                if(Utils.secondPlayer == "computer")
                {
                    ComputerPlayer.reInsertValues();
                }
            }
        } 

        public static string guessNextMove( byte i_numberOfGuess)
        {
            if (GameLogic.m_currentPlayer == "computer")
            {
                ComputerPlayer computer = new ComputerPlayer();
                if (i_numberOfGuess == 0)
                {
                    return computer.firstGuess;
                }
                else
                {
                    return computer.secondGuess;
                }
            }
            else
            {
                return UI.GetCurrentMove(GameLogic.m_currentPlayer);
            }
        }


    } 

    
}
