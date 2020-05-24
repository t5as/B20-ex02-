using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Program
    { 
        static void Main()
        {
            UI ui = new UI();            
            ui.StartGame();            
            GameDataMatrix gdm = new GameDataMatrix();
            gdm.setMatrices();
            DrawBoard br = new DrawBoard();
            DrawBoard.createBoard();
            GameLogic.m_turn = 0;
            while (Utils.charExistsInMatrix(GameDataMatrix.displayMatrix, ' '))
            {                      
                if((GameLogic.m_turn % 2) == 0)
                {
                    GameLogic.m_currentPlayer = Utils.firstPlayer;
                }
                else
                {
                    GameLogic.m_currentPlayer = Utils.secondPlayer;
                }

                for (int i = 0; i < 2; i++)
                {
                    //System.Threading.Thread.Sleep(2000);
                    //Ex02.ConsoleUtils.Screen.Clear();
                    string move = UI.GetCurrentMove(GameLogic.m_currentPlayer);
                    bool moveValid = UI.IsValidMove(move);
                    while (!moveValid)
                    {
                        move = UI.GetCurrentMove(GameLogic.m_currentPlayer);
                        moveValid = UI.IsValidMove(move);
                    } 
                    if(i == 0)
                    {
                        GameLogic.m_firstCellPick = UI.moveToByteArray(move);
                    }
                    else
                    {
                        GameLogic.m_secondCellPick = UI.moveToByteArray(move);
                    }
                    byte[] check = UI.moveToByteArray(move);
                    br.updateBoard(check[0], check[1]);
                }
                GameLogic.matchingPair();
                GameLogic.m_turn++;
                            
            } 
            if(GameLogic.m_firstPlayerScore > GameLogic.m_secondPlayerScore)
            {
                Console.WriteLine("First player won");
            } 
            else if(GameLogic.m_firstPlayerScore < GameLogic.m_secondPlayerScore)
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
