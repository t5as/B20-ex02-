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
            br.CreateBoard();
        }
    }
}
