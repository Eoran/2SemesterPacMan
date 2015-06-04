using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pacman.path
{
   
    class Path
    {
        private Queue<Vector2> que;
        private Vector2 target;

        public Vector2 Target
        {
            get { return target; }
        }

        public Path(Queue<Vector2> path)
        {
            this.que = path;
            this.target = que.Dequeue();
        }

        public bool Next()
        {
            if(que.Count > 0)
            {
                target = que.Dequeue();
                return true;
            }
            else
            {
                return false;            }
        }


    }
}
