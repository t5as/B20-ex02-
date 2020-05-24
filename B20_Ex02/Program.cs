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
            GameDataMatrix gdm = new GameDataMatrix();
            gdm.setMatrices();
            DrawBoard br = new DrawBoard();
            int[] check = UI.moveToIntArray("A4");
            br.createBoard();
            br.updateBoard((byte)check[0], (byte)check[1]);
            //Console.WriteLine(Utils.charExistsInMatrix(GameDataMatrix.dataMatrix, ' '));
        }
    }
}
