using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduation_Prog
{
    public partial class Form1 : Form
    {

        jFile jf = new jFile();
        jDrawlib jd = new jDrawlib();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jf.filePara();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[Rang]");
            foreach (var item in jf.lst_XYRange)
            {
                jXYRange rag =  (jXYRange)item; 
                Console.WriteLine("(x1,y1) -> ({0},{1}) ~ (x2,y2) -> ({2},{3})" ,rag.PointF.X, rag.PointF.Y,rag.PointS.X,rag.PointS.Y);
            }
            Console.WriteLine();
            Console.WriteLine("[Obstacle]");
            foreach (var item in jf.lst_XYObstacle)
            {
                jXYObstacle rag = (jXYObstacle)item;
                Console.WriteLine("(x1,y1) -> ({0},{1}) ~ (x2,y2) -> ({2},{3})", rag.PointF.X, rag.PointF.Y, rag.PointS.X, rag.PointS.Y);
            }
            Console.WriteLine();
            Console.WriteLine("[Point]");
            foreach (var item in jf.lst_XYPoint)
            {
                jXYPoint rag = (jXYPoint)item;
                Console.WriteLine("(x1,y1) -> ({0},{1})", rag.PointO.X, rag.PointO.Y);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            jd.baseDig(this.pictureBox1,jf,e);
        }
    }
}
