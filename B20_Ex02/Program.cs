using System;

namespace B20_Ex02
{
    public class Program
    { 
        public static void Main()
        {
            UI ui = new UI();
            int answer = 1; 
            
            while(answer == 1)
            {
                ui.StartGame();
                GameDataMatrix gdm = new GameDataMatrix();
                gdm.SetMatrices();
                DrawBoard br = new DrawBoard();
                DrawBoard.CreateBoard();
                GameLogic.m_GameTurn = 0;

                if(Utils.SecondPlayer == "computer")
                {
                    ComputerPlayer computerPlayer = new ComputerPlayer();
                }

                while(Utils.CharExistsInMatrix(GameDataMatrix.DisplayMatrix, ' '))
                {
                    GameLogic.SetCurrentPlayer();
                    Console.WriteLine(GameLogic.m_CurrentPlayer);

                    for(byte i = 0; i < 2; i++)
                    {
                        string move = GameLogic.GetNextMove(i);
                        GameLogic.PlayerTurn(i, move);
                        byte[] check = UI.MoveToByteArray(move);
                        br.UpdateBoard(check[0], check[1]);
                    }

                    GameLogic.MatchingPair();
                    GameLogic.m_GameTurn++;
                }

                GameLogic.GameResult();
                answer = UI.StartNewGame();
                
                while(answer == -1)
                {
                    answer = UI.StartNewGame();
                } 

                if(answer == 0)
                {
                    Console.WriteLine("Until next time");
                }
            }
        }
    }
}
