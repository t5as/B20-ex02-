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
            int answer = 1; 
            while(answer == 1)
            {
                ui.StartGame();
                GameDataMatrix gdm = new GameDataMatrix();
                gdm.setMatrices();
                DrawBoard br = new DrawBoard();
                DrawBoard.createBoard();
                GameLogic.m_turn = 0;
                if (Utils.secondPlayer == "computer")
                {
                    ComputerPlayer computerPlayer = new ComputerPlayer();
                }
                while (Utils.charExistsInMatrix(GameDataMatrix.displayMatrix, ' '))
                {
                    if ((GameLogic.m_turn % 2) == 0)
                    {
                        GameLogic.m_currentPlayer = Utils.firstPlayer;
                    }
                    else
                    {
                        GameLogic.m_currentPlayer = Utils.secondPlayer;
                    }
                    Console.WriteLine(GameLogic.m_currentPlayer);

                    for (byte i = 0; i < 2; i++)
                    {                                               
                        string move = GameLogic.guessNextMove(i);
                        bool moveValid = UI.IsValidMove(move);
                        while (!moveValid)
                        {
                            move = GameLogic.guessNextMove(i);
                            moveValid = UI.IsValidMove(move);
                        }

                        if (i == 0)
                        {
                            if (GameLogic.m_currentPlayer == Utils.firstPlayer && Utils.secondPlayer == "computer")
                            {
                                GameLogic.m_currentPlayerFirstMove = move;
                            }
                            GameLogic.m_firstCellPick = UI.moveToByteArray(move);
                        }
                        else
                        {
                            if (GameLogic.m_currentPlayer == Utils.firstPlayer && Utils.secondPlayer == "computer")
                            {
                                GameLogic.m_currentPlayerSecondMove = move;
                            }
                            GameLogic.m_secondCellPick = UI.moveToByteArray(move);
                        }
                        byte[] check = UI.moveToByteArray(move);
                        br.updateBoard(check[0], check[1]);
                    }
                    GameLogic.matchingPair();
                    GameLogic.m_turn++;

                }
                if (GameLogic.m_firstPlayerScore > GameLogic.m_secondPlayerScore)
                {
                    Console.WriteLine("First player won");
                }
                else if (GameLogic.m_firstPlayerScore < GameLogic.m_secondPlayerScore)
                {
                    Console.WriteLine("Second player won");
                }
                else
                {
                    Console.WriteLine("Draw");
                }

                answer = UI.startNewGame(); 
                while(answer == -1)
                {
                    answer = UI.startNewGame();
                } 
                if(answer == 0)
                {
                    Console.WriteLine("Until next time");
                }
            }
            
        }
    }
}
