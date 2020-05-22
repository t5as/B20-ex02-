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
            char[,] mat = gdm.getDataMatrix; 
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.WriteLine(mat[i, j]);
                }
            }
        }
    }
}
