using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class RunGame
    {
        public static void Run()
        {
            int answer = 1;
            while (answer == 1)
            {
                initializeGame();
                gameRoutine();
                answer = UI.StartNewGame();
                while (answer == -1)
                {
                    answer = UI.StartNewGame();
                }
                if (answer == 0)
                {
                    Console.WriteLine("We hope to see you again!");
                }
            }
        }

        private static void initializeGame()
        {
            UI.StartGame();
            GameDataMatrix gdm = new GameDataMatrix();
            DrawBoard.CreateBoard();
            GameLogic.m_GameTurn = 0;
            if (Utils.SecondPlayer == "computer")
            {
                ComputerPlayer computerPlayer = new ComputerPlayer();
            }
        }

        private static void gameRoutine()
        {
            while (Utils.CharExistsInMatrix(GameDataMatrix.DisplayMatrix, ' '))
            {
                GameLogic.SetCurrentPlayer();
                Console.WriteLine(GameLogic.m_CurrentPlayer);

                for (byte i = 0; i < 2; i++)
                {
                    string move = GameLogic.GetNextMove(i);
                    GameLogic.PlayerTurn(i, move);
                    byte[] check = UI.MoveToByteArray(move);
                    DrawBoard.UpdateBoard(check[0], check[1]);
                }
                GameLogic.MatchingPair();
                GameLogic.m_GameTurn++;
            }
            GameLogic.GameResult();
        }
    }
}

