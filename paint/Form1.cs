using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace paint
{
    public partial class Form1 : Form
    {
        private Boolean paint = false;
        private Boolean mouseDown = false;
        private Boolean mouseUp = false;
        private Pen myPen;
        private ArrayList myArrayList = new ArrayList();
        private int size = 1;
        private Color color = Color.Black;

        public Form1()
        {
            InitializeComponent();
            this.Cursor = new Cursor("PENCIL.CUR");
            myPen = new Pen(this.ForeColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                Point p = new Point(e.X, e.Y);
                myArrayList.Add(p);
                if (myArrayList.Count <= 1)
                {
                    return;
                }
                Point[] pointArr = new Point[myArrayList.Count];
                myArrayList.CopyTo(pointArr, 0);
                Graphics b = this.CreateGraphics();
                b.DrawCurve(myPen, pointArr);
            }
            else
            {
                myArrayList.Clear();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                paint = true;
                mouseDown = true;
                myArrayList.Clear();
            }
        }

        private void fontColorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size_dialog sizeDialog = new size_dialog();
            sizeDialog.setCurrSize(myPen.Width);
            sizeDialog.setCurrColor(myPen.Color);
            sizeDialog.ShowDialog();
            //myPen = new Pen(, );
            size = sizeDialog.getSize();
            penChange(size, color);
           /* if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
               

            }*/
            //myPen.Width = fontDialog1.Font;
            //myPen.SetLineCap(fontDialog1.Font);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void colorDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void colorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myArrayList.Clear();
                //myPen = new Pen(colorDialog1.Color);
                color = colorDialog1.Color;
                penChange(size, color);
            }


            //myPen.Color = colorDialog1.Color;
            //new Pen(colorDialog1.Color);
        }

        private void penChange(int size, Color color)
        {
            myPen = new Pen(color, size);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
