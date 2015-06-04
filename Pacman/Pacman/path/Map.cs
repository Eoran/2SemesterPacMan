using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.path
{
    class Map
    {
        private int tilew;
        private int tileh;
        private Node[,] nodes;
        public Map(int tilewidth, int tileheight)
        {
            tilew = tilewidth;
            tileh = tileheight;
            nodes = new Node[tilew, tileh];
        }
        public Path findPath(Node start, Node goal)
        {
            if (start == null || goal == null || start == goal)
            {
                return null;
            }
            else
            {
                findh(goal);
                List<Node> open = new List<Node>();
                List<Node> closed = new List<Node>();

                open.Add(start);
                bool goalfound = false;

                while (!goalfound)
                {
                    open = new List<Node>(open.OrderBy(n => n.F));
                    Node p = open.First();

                    int px;
                    int py;

                    findPos(p, out px, out py);

                    for (int i = 0; i < 4; i++)
                    {
                        Node n = null;
                        switch (i)
                        {
                            case 0:
                                n = getNodeAt(px, py + 1);
                                break;
                            case 1:
                                n = getNodeAt(px + 1, py);
                                break;
                            case 2:
                                n = getNodeAt(px, py - 1);
                                break;
                            case 3:
                                n = getNodeAt(px - 1, py);
                                break;
                        }
                        if (n != null)
                        {
                            if (!closed.Contains(n))
                            {
                                if (n == goal)
                                {
                                    n.Parent = p;
                                    goalfound = true;
                                    break;
                                }
                                else if (n.Parent != null)
                                {
                                    if (p.G + 1 < n.G)
                                    {
                                        n.Parent = p;
                                        n.G = p.G + 1;
                                    }
                                }
                                else
                                {
                                    n.Parent = p;
                                    n.G = p.G + 1;
                                    open.Add(n);
                                }
                            }
                        }
                    }
                    open.Remove(p);
                    closed.Add(p);

                    if(open.Count == 0 && !goalfound)
                    {
                        Reset();
                        return null;
                    }
                }
            }
            Path path = TracePath(goal);
            Reset();
            return path;
        }
        private Path TracePath(Node goal)
        {
            if(goal.Parent == null)
            {
                return null;
            }
            else
            {
                Stack<Vector2> path = new Stack<Vector2>();
                Node p = goal;
                
                while(p != null)
                {
                    int x;
                    int y;
                    findPos(p, out x, out y);
                    path.Push(new Vector2(x, y) * 32f);
                    p = p.Parent;
                }
                return new Path(new Queue<Vector2>(path));
            }
        }
        private void findh(Node goal)
        {
            int goalY;
            int goalX;
            findPos(goal, out goalX, out goalY);

            foreach (Node n in nodes)
            {
                if (n != goal)
                {
                    int nx;
                    int ny;
                    findPos(n, out nx, out ny);
                    n.H = manhatten(goalX, goalY, nx, ny);
                }
                else
                {
                    n.H = 0;
                }
            }
        }
        private void findPos(Node n, out int x, out int y)
        {
            for (int i = 0; i < nodes.GetLength(0); i++)
            {
                for (int j = 0; j < nodes.GetLength(1); j++)
                {
                    if (nodes[i, j] == n)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
            x = -1;
            y = -1;

        }
        private int manhatten(int x1, int y1, int x2, int y2)
        {
            int maxX = Math.Max(x1, x2);
            int maxY = Math.Max(y1, y2);
            int minX = Math.Min(x1, x2);
            int minY = Math.Min(y1, y2);

            return Math.Abs(maxX - minX) + Math.Abs(maxY - maxX);
        }
        public Node getNodeAt(int x, int y)
        {
            if (x >= 0 && x < tilew && y < tileh && y >= 0)
            {
                return nodes[x, y];
            }
            else
            {
                return null;
            }

        }
        public Node getNodeAt(Vector2 pos)
        {
            int x = (int)(pos.X / 32f);
            int y = (int)(pos.Y / 32f);
            return getNodeAt(x, y);
        }
        private void Reset()
        {
            foreach(Node n in nodes)
            {
                n.Parent = null;
                n.H = 0;
                n.G = 0;
            }
        }
    }
}
