using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.path
{
    class Node
    {
        private int h;

        public int H
        {
            get { return h; }
            set { h = value; }
        }
        private int g;

        public int G
        {
            get { return g; }
            set { g = value; }
        }

        public int F { get { return g + h; } }

        private bool col;

        public bool Col
        {
            get { return col; }
            set { col = value; }
        }

        private Node parent;

        internal Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Node()
        {

        }
    }
}
