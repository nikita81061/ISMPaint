using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShapesLIb;

namespace ISMPaint
{
    public partial class Form1 : Form
    {
        protected List<Shape> Shapes;
        protected Mode Mode;
        protected int MouseX, MouseY, MouseX2, MouseY2;

        protected void AddShape(Shape shape)
        {
            Shapes.Add(shape);
            listBox1.Items.Add(shape);
            pictureBox1.Refresh();
        }
        protected void DeleteShape(int number)
        {
            Shapes.RemoveAt(number);
            listBox1.Items.RemoveAt(number);
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog.Color;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Shapes.Count; i++)
                Shapes[i].Draw(e.Graphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawDot;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawCircle;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Color color = new Color();
            color = button1.BackColor;
            switch (Mode)
            {
                case Mode.DrawDot:
                    Shape shape = new Dot(color, MouseX, MouseY);
                    AddShape(shape);
                    break;
                case Mode.DrawLine:
                    shape = new Line(color, MouseX, MouseY, e.X, e.Y);
                    AddShape(shape);
                    break;
                case Mode.DrawCircle:
                    int side = Math.Abs(MouseX - e.X) + Math.Abs(MouseY - e.Y);
                    shape = new Circle(color, MouseX, MouseY, side);
                    AddShape(shape);
                    break;
                case Mode.DrawRectangle:

                    if (MouseX > MouseX2 && MouseY > MouseY2)
                    {
                        Shape shape4 = new ShapesLIb.Rectangle(color, MouseX, MouseY, MouseX - MouseX2, MouseY - MouseY2);
                        AddShape(shape4);
                    }
                    else if (MouseX < MouseX2 && MouseY < MouseY2)
                    {
                        Shape shape4 = new ShapesLIb.Rectangle(color, MouseX, MouseY, MouseX2 - MouseX, MouseY2 - MouseY);
                        AddShape(shape4);
                    }
                    else if (MouseX > MouseX2 && MouseY < MouseY2)
                    {
                        Shape shape4 = new ShapesLIb.Rectangle(color, MouseX, MouseY2, Math.Abs(MouseX2 - MouseX), Math.Abs(MouseY2 - MouseY));
                        AddShape(shape4);
                    }
                    else if (MouseX < MouseX2 && MouseY > MouseY2)
                    {
                        Shape shape4 = new ShapesLIb.Rectangle(color, MouseX2, MouseY, Math.Abs(MouseX2 - MouseX), Math.Abs(MouseY2 - MouseY));
                        AddShape(shape4);

                    }
                    break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawDot:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
                case Mode.DrawLine:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
                case Mode.DrawCircle:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
                case Mode.DrawRectangle:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    DeleteShape(i);
                    i--;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawRectangle;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawDot:
                    if (e.Button == MouseButtons.Left)
                    {
                        pictureBox1.Refresh();
                        Graphics graphics = pictureBox1.CreateGraphics();
                        graphics.DrawEllipse(new Pen(Color.Black, 1), MouseX, MouseY, 2, 2);
                    }
                    break;
                case Mode.DrawLine:
                    if (e.Button == MouseButtons.Left)
                    {
                        pictureBox1.Refresh();
                        Graphics graphics = pictureBox1.CreateGraphics();
                        graphics.DrawLine(new Pen(Color.Black, 1), MouseX, MouseY, e.X, e.Y);
                    }
                    break;
                case Mode.DrawCircle:
                    if (e.Button == MouseButtons.Left)
                    {
                        pictureBox1.Refresh();
                        int side = Math.Abs(MouseX - e.X) + Math.Abs(MouseY - e.Y);
                        Graphics graphics = pictureBox1.CreateGraphics();
                        graphics.DrawEllipse(new Pen(Color.Black, 1), MouseX - side / 2, MouseY - side / 2, side, side);
                    }
                    break;
                case Mode.DrawRectangle:
                    if (e.Button == MouseButtons.Left)
                    {
                        
                        pictureBox1.Refresh();
                        Graphics graphics = pictureBox1.CreateGraphics();
                        MouseX2 = e.X;
                        MouseY2 = e.Y;
                        if (MouseX > MouseX2 && MouseY > MouseY2)
                        {
                            graphics.DrawRectangle(new Pen(button1.BackColor, 1), MouseX, MouseY, MouseX - MouseX2, MouseY - MouseY2);
                        }
                        else if (MouseX < MouseX2 && MouseY < MouseY2)
                        {
                            graphics.DrawRectangle(new Pen(button1.BackColor, 1), MouseX, MouseY, MouseX2 - MouseX, MouseY2 - MouseY);
                        }
                        else if (MouseX < MouseX2 && MouseY > MouseY2)
                        {
                            graphics.DrawRectangle(new Pen(button1.BackColor, 1), MouseX, MouseY2, Math.Abs(MouseX2 - MouseX), Math.Abs(MouseY2 - MouseY));
                        }
                        else if (MouseX > MouseX2 && MouseY < MouseY2)
                        {
                            graphics.DrawRectangle(new Pen(button1.BackColor, 1), MouseX2, MouseY, Math.Abs(MouseX2 - MouseX), Math.Abs(MouseY2 - MouseY));
                        }


                    }
                    break;
            }
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            Shapes = new List<Shape>();
            Mode = Mode.DrawDot;
        }
    }
}
