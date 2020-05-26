using System;

namespace B20_Ex02
{
    public class RunGame
    {
        public static void Run()
        {
            int restartGame = 1;

            while(restartGame == 1)
            {
                initializeGame();
                gameRoutine();
                restartGame = UI.StartNewGame();

                while(restartGame == -1)
                {
                    restartGame = UI.StartNewGame();
                }

                if (restartGame == 0)
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
                ComputerPlayer.StartComputer();
            }
        }

        private static void gameRoutine()
        {
            while(Utils.CharExistsInMatrix(GameDataMatrix.DisplayMatrix, ' '))
            {
                GameLogic.SetCurrentPlayer();

                for(byte i = 0; i < 2; i++)
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