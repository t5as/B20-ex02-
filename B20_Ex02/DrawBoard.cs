using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class DrawBoard
    {
        public void createBoard()
        {
            char columnLetter = 'A';
            for (byte i = 0; i <= Utils.boardHeight; i++)
            {
                string rowNumber;
                if (i == 0)
                {
                    rowNumber = string.Format("       ", i);
                }
                else
                {
                    rowNumber = string.Format("  {0}   |", i);
                }

                StringBuilder boardRecords = new StringBuilder(rowNumber);
                StringBuilder boardBorders = new StringBuilder("      ");
                for (byte j = 1; j < Utils.boardWidth; j++)
                {
                    if (i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;
                        boardBorders.Append("========");
                    }
                    else
                    {
                        string cell = string.Format("   {0}   |", GameDataMatrix.dataMatrix[i - 1, j]);
                        boardRecords.Append(cell);
                        boardBorders.Append("========");
                    }
                }

                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            } 
        }

        public void updateBoard(byte i_rowIndexLetter, byte i_colIndexLetter)
        {
            char columnLetter = 'A';
            for (byte i = 0; i <= Utils.boardHeight; i++)
            {
                string rowNumber;
                if (i == 0)
                {
                    rowNumber = string.Format("       ", i);
                }
                else
                {
                    rowNumber = string.Format("  {0}   |", i);
                }

                StringBuilder boardRecords = new StringBuilder(rowNumber);
                StringBuilder boardBorders = new StringBuilder("      ");
                for (byte j = 1; j < Utils.boardWidth; j++)
                {
                    if (i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;
                        boardBorders.Append("========");
                    }
                    else if(i - 1 == i_rowIndexLetter && j == i_colIndexLetter){
                        GameDataMatrix.setDisplayMatrix((byte)(i - 1), j, GameDataMatrix.dataMatrix[i - 1, j]);
                        string cell = string.Format("   {0}   |", GameDataMatrix.displayMatrix[i - 1, j]);
                        boardRecords.Append(cell);
                        boardBorders.Append("========");
                    }
                    else
                    {
                        string cell = string.Format("   {0}   |", GameDataMatrix.displayMatrix[i - 1, j]);
                        boardRecords.Append(cell);
                        boardBorders.Append("========");
                    }
                }

                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            }
        }
    }
}
