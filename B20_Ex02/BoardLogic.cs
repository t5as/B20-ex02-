using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class BoardLogic 
    {
        public BoardLogic(byte i_boardHeight, byte i_boardWidth)
        {
            m_boardHeight = i_boardHeight;
            m_boardWidth = i_boardWidth;
        } 

        public void createBoard()
        {
            char columnLetter = 'A';
            for (byte i = 0; i <= m_boardHeight; i++)
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
                for (byte j = 1; j <= m_boardWidth; j++)
                {
                    if (i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;
                        boardBorders.Append("========");
                    }
                    else
                    {
                        boardRecords.Append(string.Format("   {0}   |", string.Empty));
                        boardBorders.Append("========");
                    }
                }

                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            } 
        }

        public void updateBoard(char i_rowIndexLetter, byte i_colIndex)
        {
            int rowIndexLetter = m_letterToIndex[i_rowIndexLetter];
            i_colIndex -= 1;
            char columnLetter = 'A';
            for (byte i = 0; i <= m_boardHeight; i++)
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
                for (byte j = 1; j <= m_boardWidth; j++)
                {
                    if (i == 0)
                    {
                        boardRecords.Append(string.Format("   {0}    ", columnLetter));
                        columnLetter++;
                        boardBorders.Append("========");
                    }
                    else
                    {
                        boardRecords.Append(string.Format("   {0}   |", string.Empty));
                        boardBorders.Append("========");
                    }
                }

                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            }
        }
    }
}
