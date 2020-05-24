using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Program
    { 
        static void Main()
        {
            UI ui = new UI();
            ui.StartGame();
            BoardLogic br = new BoardLogic();
            br.createBoard();
            
            GameDataMatrix gdm = new GameDataMatrix(Utils.boardHeight, Utils.boardWidth);
            gdm.setDataMatrix();
            char[,] mat = gdm.getDataMatrix;           
            for(int i = 0; i < Utils.boardHeight; i++)
            {
                for(int j = 0; j < Utils.boardWidth; j++)
                {
                    Console.Write(mat[i, j]);
                }
                Console.WriteLine();
            } 
        }
    }
}
