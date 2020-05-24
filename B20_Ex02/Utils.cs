using System;
using System.Collections.Generic;
using System.Text;

namespace B20_Ex02
{
    class Utils
    {
        private byte m_boardHeight;
        private byte m_boardWidth;
        private Dictionary<char, int> m_letterToIndex = new Dictionary<char, int>()
        {
            {'A', 0},
            {'B', 1},
            {'C', 2},
            {'D', 3},
            {'E', 4},
            {'F', 5}
        }; 

        public Utils(byte i_boardHeight, byte i_boardWidth)
        {
            m_boardHeight = i_boardHeight;
            m_boardWidth = i_boardWidth;
        }

        public byte getBoardHeight
        {
            get
            {
                return m_boardHeight;
            }
        }

        public byte getBoardWidth
        {
            get
            {
                return m_boardWidth;
            }
        } 

        public Dictionary<char, int> letterToIndex
        {
            get
            {
                return m_letterToIndex;
            }
        }
    }
}
