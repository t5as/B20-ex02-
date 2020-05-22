using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Program
    { 
        static void Main()
        {
            BoardLogic br = new BoardLogic(4, 5);
            br.createBoard();
            Identifier.shalom();
            GameDataMatrix gdm = new GameDataMatrix(4, 5);
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
