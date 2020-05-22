using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class BoardLogic 
    {
        private byte m_boardHeight;
        private byte m_boardWidth; 

        public BoardLogic(byte i_boardHeight, byte i_boardWidth)
        {
            m_boardHeight = i_boardHeight;
            m_boardWidth = i_boardWidth;
        } 

        public void CreateBoard()
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
                        boardRecords.Append(string.Format("   {0}   |", ""));
                        boardBorders.Append("========");
                    }
                    
                   
                }
                Console.WriteLine(boardRecords);
                Console.WriteLine(boardBorders);
            }
        }
    }
}
