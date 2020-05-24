using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Program
    { 
        static void Main()
        {
            //byte[] boardDimensions = Identifier.StartGame();
            Utils.boardHeight = 4;
            Utils.boardWidth = 6;
            GameDataMatrix gdm = new GameDataMatrix();
            gdm.setMatrices(); 
            /*for(int i = 0; i < Utils.boardHeight; i++)
            {
                for(int j = 0; j < Utils.boardWidth; j++)
                {
                    Console.Write(GameDataMatrix.getDataMatrix[i, j]);
                }
                Console.WriteLine();
            }*/
            DrawBoard br = new DrawBoard();
            br.createBoard();
            br.updateBoard(0, 4);
            Console.WriteLine(Utils.charExistsInMatrix(GameDataMatrix.dataMatrix, ' '));
        }
    }
}
