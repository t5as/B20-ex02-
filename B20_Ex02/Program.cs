using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Program
    { 
        static void Main()
        {
            byte[] boardDimensions = Identifier.StartGame();
            BoardLogic br = new BoardLogic(boardDimensions[0], boardDimensions[1]);
            br.createBoard();
            
            GameDataMatrix gdm = new GameDataMatrix(boardDimensions[0], boardDimensions[1]);
            gdm.setDataMatrix();
            char[,] mat = gdm.getDataMatrix;           
            for(int i = 0; i < boardDimensions[0]; i++)
            {
                for(int j = 0; j < boardDimensions[1]; j++)
                {
                    Console.Write(mat[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
