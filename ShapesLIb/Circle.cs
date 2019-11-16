using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesLIb
{
    public class Circle : Dot
    {
        protected int radius;
        public Circle(Color color, int x, int y, int radius)
            : base(color, x, y)
        {
            this.radius = radius;
        }
        public override void Draw(Graphics g)
        {
            Pen randcolor = new Pen(color, 3);
            g.DrawEllipse(randcolor, x - radius / 2, y - radius / 2, radius, radius);

        }
    }
}
