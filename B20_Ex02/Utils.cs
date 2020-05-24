using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    public class Utils
    {
        private static byte m_boardHeight;
        private static byte m_boardWidth;
        private static Dictionary<char, int> m_letterToIndex = new Dictionary<char, int>()
        {
            {'A', 0},
            {'B', 1},
            {'C', 2},
            {'D', 3},
            {'E', 4},
            {'F', 5}
        }; 


        public static byte boardHeight
        {
            get
            {
                return m_boardHeight;
            }
            set
            {
                m_boardHeight = value;
            }
        }

        public static byte boardWidth
        {
            get
            {
                return m_boardWidth;
            }
            set
            {
                m_boardWidth = value;
            }
        } 

        public static Dictionary<char, int> letterToIndex
        {
            get
            {
                return m_letterToIndex;
            }
        }
    }
}
