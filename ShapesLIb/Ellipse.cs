using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesLIb
{
    public class Ellipse : Circle
    {
        protected int height;
        public Ellipse(Color color, int x, int y, int radius, int height)
            : base(color, x, y, radius)
        { 
            this.height = height;
        }
        public override void Draw(Graphics g)
        {
            Pen randcolor = new Pen(color, 3);
            g.DrawEllipse(randcolor, x - radius / 2, y - height / 2, radius, height);
        }
    }
}
