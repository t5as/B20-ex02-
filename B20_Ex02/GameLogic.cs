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
                }
                else
                {
                    m_secondPlayerScore++;
                }
                m_turn--;
            }
            else
            {
                deleteLastPlayerChoices();
            }
        }


    } 

    
}
