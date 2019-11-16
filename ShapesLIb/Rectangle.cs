using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesLIb
{
    public class Rectangle : Line
    {
        protected int width;
        protected int height;
        public Rectangle(Color color, int x, int y, int width, int height)
            : base(color, x, y, width, height)
        {
            this.width = width;
            this.height = height;
        }
        public override void Draw(Graphics g)
        {
            Pen randcolor = new Pen(color, 3);
            g.DrawRectangle(randcolor, x - width / 2, y - height / 2, width, height);

        }
    }
}
