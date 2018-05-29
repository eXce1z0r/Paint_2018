using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace paint
{
    public partial class size_dialog : Form
    {
        private int curr_size = 1;
        private Color curr_color = Color.Blue;
        private int size = 0;
        private Pen TemplatePen;
        private Point[] pArr = new Point[2];
        public size_dialog()
        {
            InitializeComponent();

            trackBar1.Maximum = 100;
            numericUpDown1.DecimalPlaces = 1;

            TemplatePen = new Pen(curr_color, (float)curr_size);

            pArr[0] = new Point(10, 50);
            pArr[1] = new Point(this.Size.Width - 25, 50);

            curveTemplate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //size = trackBar1.Value;
            //trackBar1.Value = size;
            //trackBar1.Maximum = 100;
            curr_size = trackBar1.Value;
            numericUpDown1.Value = curr_size;

            curveTemplate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //numericUpDown1.DecimalPlaces = 1;
            curr_size = (int)numericUpDown1.Value;
            trackBar1.Value = curr_size;
            //numericUpDown1.Value = size;
           // numericUpDown1.Value = size;

            curveTemplate();
        }

        private void curveTemplate()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            TemplatePen = new Pen(curr_color, (float)curr_size);
            g.DrawCurve(TemplatePen, pArr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            size = curr_size;
            this.Close();
        }

        public int getSize()
        {
            return size;
        }

        public void setCurrSize(float size)
        {
            this.curr_size = (int)size;
            trackBar1.Value = this.curr_size;
            numericUpDown1.Value = this.curr_size;
        }

        public void setCurrColor(Color color)
        {
            this.curr_color = color;
        }

        private void size_dialog_Load(object sender, EventArgs e)
        {

        }


    }
}
