using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesLIb
{
    public class Dot : Shape
    {
        public Dot(Color color, int x, int y)
           : base(color, x, y) { }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x - 3, y - 3, 6, 6);
        }
        public override void Move(int shiftedX, int shiftedY)
        {
            x += shiftedX;
            y += shiftedY;
        }
    }
}
