using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesLIb
{
    public abstract class Shape
    {
        protected int x, y;
        protected Color color;
        public Shape(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }
        public abstract void Draw(Graphics g);
        public abstract void Move(int x, int y);
    }
}
