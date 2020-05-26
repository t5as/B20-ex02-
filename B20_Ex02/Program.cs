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
                GameLogic.m_gameTurn = 0;
                if (Utils.secondPlayer == "computer")
                {
                    ComputerPlayer computerPlayer = new ComputerPlayer();
                }
                while (Utils.charExistsInMatrix(GameDataMatrix.displayMatrix, ' '))
                {
                    GameLogic.setCurrentPlayer();
                    Console.WriteLine(GameLogic.m_currentPlayer);

                    for (byte i = 0; i < 2; i++)
                    {
                        string move = GameLogic.getNextMove(i);
                        GameLogic.playerTurn(i, move);
                        byte[] check = UI.moveToByteArray(move);
                        br.updateBoard(check[0], check[1]);
                    }

                    GameLogic.matchingPair();
                    GameLogic.m_gameTurn++;

                }
                GameLogic.gameResult();
                answer = UI.startNewGame(); 
                while (answer == -1)
                {
                    answer = UI.startNewGame();
                } 
                if (answer == 0)
                {
                    Console.WriteLine("Until next time");
                }
            }
            
        }
    }
}
