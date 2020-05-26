using System;

namespace B20_Ex02
{
    public class GameLogic
    { 
        public static byte m_GameTurn;
        public static string m_CurrentPlayer;
        public static string m_CurrentPlayerFirstMove;
        public static string m_CurrentPlayerSecondMove;
        public static byte m_FirstPlayerScore = 0;
        public static byte m_SecondPlayerScore = 0;
        public static byte[] m_FirstCellPick;
        public static byte[] m_SecondCellPick;

        public static void SetCurrentPlayer()
        {
            m_CurrentPlayer = m_GameTurn % 2 == 0 ? Utils.FirstPlayer : Utils.SecondPlayer;         
        }

        public static void DeleteLastPlayerChoices()
        {
            System.Threading.Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            GameDataMatrix.SetDisplayMatrix(m_FirstCellPick[0], m_FirstCellPick[1], ' ');
            GameDataMatrix.SetDisplayMatrix(m_SecondCellPick[0], m_SecondCellPick[1], ' ');
            DrawBoard.CreateBoard();
        }
        
        public static void MatchingPair()
        {
            if(GameDataMatrix.DataMatrix[m_FirstCellPick[0], m_FirstCellPick[1]] == GameDataMatrix.DataMatrix[m_SecondCellPick[0], m_SecondCellPick[1]])
            {
                if(m_CurrentPlayer == Utils.FirstPlayer)
                {
                    m_FirstPlayerScore++;                   
                    if(Utils.SecondPlayer == "computer")
                    {
                        ComputerPlayer.RemoveFromAvailableCellsInBoard(m_CurrentPlayerFirstMove);
                        ComputerPlayer.RemoveFromAvailableCellsInBoard(m_CurrentPlayerSecondMove);
                    }
                }
                else
                {
                    m_SecondPlayerScore++;                    
                }

                m_GameTurn--;
            }
            else
            {
                DeleteLastPlayerChoices();
                if(Utils.SecondPlayer == "computer" && GameLogic.m_CurrentPlayer == "computer")
                {      
                    ComputerPlayer.ReInsertValues();
                }
            }
        } 

        public static string GuessNextMove(byte i_NumberOfGuess)
        {
            if (GameLogic.m_CurrentPlayer == "computer")
            {                
                return i_NumberOfGuess == 0 ? ComputerPlayer.FirstGuess : ComputerPlayer.SecondGuess;             
            }
            else
            {
                return UI.GetCurrentMove(GameLogic.m_CurrentPlayer);
            }
        } 

        public static string GetNextMove(byte i_ChoiceNumber)
        {
            string move = GameLogic.GuessNextMove(i_ChoiceNumber);
            bool moveValid = UI.IsValidMove(move);

            while (!moveValid)
            {
                move = GameLogic.GuessNextMove(i_ChoiceNumber);
                moveValid = UI.IsValidMove(move);
            }

            return move;
        } 
        
        public static void PlayerTurn(byte i_Turn, string i_Move)
        {
            if (i_Turn == 0)
            {
                if (GameLogic.m_CurrentPlayer == Utils.FirstPlayer && Utils.SecondPlayer == "computer")
                {
                    GameLogic.m_CurrentPlayerFirstMove = i_Move;
                }

                GameLogic.m_FirstCellPick = UI.MoveToByteArray(i_Move);
            }
            else
            {
                if (GameLogic.m_CurrentPlayer == Utils.FirstPlayer && Utils.SecondPlayer == "computer")
                {
                    GameLogic.m_CurrentPlayerSecondMove = i_Move;
                }

                GameLogic.m_SecondCellPick = UI.MoveToByteArray(i_Move);
            }            
        }

        public static void GameResult()
        {
            if (m_FirstPlayerScore > m_SecondPlayerScore)
            {
                Console.WriteLine(string.Format(@"{0} player won: {1} - {2}", Utils.FirstPlayer, m_FirstPlayerScore, m_SecondPlayerScore));
            }
            else if (m_FirstPlayerScore < m_SecondPlayerScore)
            {
                Console.WriteLine(string.Format(@"{0} player won: {1} - {2}", Utils.SecondPlayer, m_FirstPlayerScore, m_SecondPlayerScore));
            }
            else
            {
                Console.WriteLine(string.Format(@"Draw, no winner: {0} - {1}", m_FirstPlayerScore, m_SecondPlayerScore));
            }
        }
    }
}