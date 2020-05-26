using System;
using System.Text;

namespace B20_Ex02
{
    public class DrawBoard
    {
        public static void CreateBoard()
        {
            char columnLetter = 'A';

            for(byte i = 0; i <= Utils.BoardHeight; i++)
            {
                string rowNumber = i == 0 ? string.Format("       ", i) : string.Format("  {0}   |", i);               
                StringBuilder boardRecords = new StringBuilder(rowNumber);
                StringBuilder boardBorders = new StringBuilder("      ");

                for(byte j = 0; j < Utils.BoardWidth; j++)
                {
                    if(i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;
                    }
                    else
                    {
                        string cell = string.Format("   {0}   |", GameDataMatrix.DisplayMatrix[i - 1, j]);
                        boardRecords.Append(cell);
                    }

                    boardBorders.Append("========");
                }

                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            } 
        }

        public static void UpdateBoard(byte i_RowIndexLetter, byte i_ColIndexLetter)
        {
            char columnLetter = 'A';

            for(byte i = 0; i <= Utils.BoardHeight; i++)
            {
                string rowNumber = i == 0 ? string.Format("       ", i) : string.Format("  {0}   |", i);             
                StringBuilder boardRecords = new StringBuilder(rowNumber);
                StringBuilder boardBorders = new StringBuilder("      ");

                for(byte j = 0; j < Utils.BoardWidth; j++)
                {
                    if(i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;                        
                    }
                    else if(i == i_RowIndexLetter + 1 && j == i_ColIndexLetter) 
                    {
                        GameDataMatrix.SetDisplayMatrix((byte)(i - 1), j, GameDataMatrix.DataMatrix[i - 1, j]);
                        string cell = string.Format("   {0}   |", GameDataMatrix.DisplayMatrix[i - 1, j]);
                        boardRecords.Append(cell);                        
                    }
                    else
                    {
                        string cell = string.Format("   {0}   |", GameDataMatrix.DisplayMatrix[i - 1, j]);
                        boardRecords.Append(cell);                        
                    }

                    boardBorders.Append("========");
                }
                
                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            }
        }
    }
}
