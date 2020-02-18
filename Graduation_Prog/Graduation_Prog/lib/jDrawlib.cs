using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class jDrawlib
{
    public void baseDig(PictureBox _pb, jFile jf, PaintEventArgs e)
    {
        int Max_X = 0;
        int Max_Y = 0;
        Console.WriteLine("[Rang]");
        foreach (var item in jf.lst_XYRange)
        {
            jXYRange rag = (jXYRange)item;
            Console.WriteLine("(x1,y1) -> ({0},{1}) ~ (x2,y2) -> ({2},{3})", rag.PointF.X, rag.PointF.Y, rag.PointS.X, rag.PointS.Y);
            Pen p1;
            p1 = new Pen(Color.Red, 2);
            e.Graphics.DrawRectangle(p1, rag.PointF.X * jf.smooth, rag.PointF.Y * jf.smooth, (float)rag.FS_Dist_x * jf.smooth, (float)rag.FS_Dist_y * jf.smooth);
            Max_X = rag.FS_Dist_x * jf.smooth;
            Max_Y = rag.FS_Dist_y * jf.smooth;
        }
        Console.WriteLine();
        Console.WriteLine("[Obstacle]");
        foreach (var item in jf.lst_XYObstacle)
        {
            jXYObstacle rag = (jXYObstacle)item;
            Console.WriteLine("(x1,y1) -> ({0},{1}) ~ (x2,y2) -> ({2},{3})", rag.PointF.X, rag.PointF.Y, rag.PointS.X, rag.PointS.Y);
            Pen p1;
            p1 = new Pen(Color.Blue, 2);
            Pen p2;
            p2 = new Pen(Color.Green, 1);
            e.Graphics.DrawRectangle(p1, rag.PointF.X * jf.smooth, rag.PointF.Y * jf.smooth, (float)rag.FS_Dist_x * jf.smooth, (float)rag.FS_Dist_y * jf.smooth);
            e.Graphics.DrawLine(p2, new Point(rag.PointF.X * jf.smooth, 0), new Point(rag.PointF.X * jf.smooth, Max_Y));
            e.Graphics.DrawLine(p2, new Point(0, rag.PointF.Y * jf.smooth), new Point(Max_X, rag.PointF.Y * jf.smooth));
            e.Graphics.DrawLine(p2, new Point(rag.FS_rDist_x * jf.smooth, 0), new Point(rag.FS_rDist_x * jf.smooth, Max_Y));
            e.Graphics.DrawLine(p2, new Point(0, rag.FS_rDist_y * jf.smooth), new Point(Max_X, rag.FS_rDist_y * jf.smooth));
        }
        Console.WriteLine();
        Console.WriteLine("[Point]");
        foreach (var item in jf.lst_XYPoint)
        {
            jXYPoint rag = (jXYPoint)item;
            Console.WriteLine("(x1,y1) -> ({0},{1})", rag.PointO.X, rag.PointO.Y);
            Pen p1;
            Pen p2;
            p2 = new Pen(Color.Gray, 2);
            e.Graphics.DrawString(String.Format("({0},{1})", rag.PointO.X, rag.PointO.Y), new Font("Arial", 7), new SolidBrush(Color.Black), rag.PointO);
            //Pen p3;
            //p3 = new Pen(Color.GreenYellow, 1);
            //e.Graphics.DrawLine(p3, new Point(rag.PointO.X, 0), new Point(rag.PointO.X, Max_Y));
            //e.Graphics.DrawLine(p3, new Point(0, rag.PointO.Y), new Point(Max_X, rag.PointO.Y));

            p1 = new Pen(Color.Black, 2);
            e.Graphics.DrawString("．", new Font("Arial", 16), new SolidBrush(Color.Black), new Point(rag.PointO.X, rag.PointO.Y));
            e.Graphics.DrawLine(p1, new Point(rag.PointO.X - 5, rag.PointO.Y - 5), new Point(rag.PointO.X + 5, rag.PointO.Y + 5));
            e.Graphics.DrawLine(p1, new Point(rag.PointO.X + 5, rag.PointO.Y - 5), new Point(rag.PointO.X - 5, rag.PointO.Y + 5));
        }
    }
}
