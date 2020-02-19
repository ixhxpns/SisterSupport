using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/// <summary>
/// 畫圖主要Class
/// </summary>
public class jDrawlib
{
    /// <summary>
    /// 畫圖主要函式，此函式內皆為畫圖之行為。
    /// </summary>
    /// <param name="_pb">UI 物件 PictureBox</param>
    /// <param name="jf">jFile 類別</param>
    /// <param name="e">UI 物件 PictureBox -> 事件 PaintEventArgs</param>
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
            jXYObstacle obs = (jXYObstacle)item;
            Console.WriteLine("(x1,y1) -> ({0},{1}) ~ (x2,y2) -> ({2},{3})", obs.PointF.X, obs.PointF.Y, obs.PointS.X, obs.PointS.Y);
            Pen p1;
            p1 = new Pen(Color.Blue, 2);
            Pen p2;
            p2 = new Pen(Color.Green, 1);
            e.Graphics.DrawRectangle(p1, obs.PointF.X * jf.smooth, obs.PointF.Y * jf.smooth, (float)obs.FS_Dist_x * jf.smooth, (float)obs.FS_Dist_y * jf.smooth);
            e.Graphics.DrawString(String.Format("({0},{1})", obs.PointF.X, obs.PointF.Y), new Font("Arial", 7), new SolidBrush(Color.Black), new Point(obs.PointF.X * jf.smooth, obs.PointF.Y * jf.smooth));
            e.Graphics.DrawString(String.Format("({0},{1})", obs.PointS.X, obs.PointS.Y), new Font("Arial", 7), new SolidBrush(Color.Black), new Point(obs.PointS.X * jf.smooth, obs.PointS.Y * jf.smooth));
            e.Graphics.DrawLine(p2, new Point(obs.PointF.X * jf.smooth, 0), new Point(obs.PointF.X * jf.smooth, Max_Y));
            e.Graphics.DrawLine(p2, new Point(0, obs.PointF.Y * jf.smooth), new Point(Max_X, obs.PointF.Y * jf.smooth));
            e.Graphics.DrawLine(p2, new Point(obs.PointS.X * jf.smooth, 0), new Point(obs.PointS.X * jf.smooth, Max_Y));
            e.Graphics.DrawLine(p2, new Point(0, obs.PointS.Y * jf.smooth), new Point(Max_X, obs.PointS.Y* jf.smooth));
        }
        Console.WriteLine();
        Console.WriteLine("[Point]");
        foreach (var item in jf.lst_XYPoint)
        {
            jXYPoint pot = (jXYPoint)item;
            Console.WriteLine("(x1,y1) -> ({0},{1})", pot.PointO.X, pot.PointO.Y);
            DrawStrPoint(pot.PointO, e, jf, Color.Black);
        }
        TrainningFreeSpace(jf, e);
        Console.WriteLine();
        Console.WriteLine(String.Format("[AllPints]"));
        foreach (var item in lst_jxyAllPints.lst_XYAllPints)
        {
            Console.WriteLine(String.Format("({0},{1})",item.PointO.X,item.PointO.Y));
        }
    }
    /// <summary>
    /// 找出所有與障礙物"邊"延伸之交點
    /// </summary>
    /// <param name="jf">JFile</param>
    /// <param name="e">PaintEventArgs</param>
    public void TrainningFreeSpace(jFile jf, PaintEventArgs e)
    {
        
        List<jXYObstacle> tmplist = jf.lst_XYObstacle;
        jXYRange rag = jf.lst_XYRange[0];
        tmplist.Add(new jXYObstacle { PointF = rag.PointF, PointS = rag.PointS });//將jXYRange的座標一併塞入至 jXYObstacle。
        foreach (var item1 in tmplist)
        {
            foreach (var item2 in tmplist)
            {
                DrawStrPoint(new Point(item1.PointF.X * jf.smooth, item2.PointF.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item1.PointF.X, item2.PointF.Y) });//將找到的點塞入至jXYAllPints裡已經宣告的jXYAllPints list裡
                DrawStrPoint(new Point(item2.PointF.X * jf.smooth, item1.PointF.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item2.PointF.X, item1.PointF.Y) });
                DrawStrPoint(new Point(item1.PointS.X * jf.smooth, item2.PointS.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item1.PointS.X, item2.PointS.Y) });
                DrawStrPoint(new Point(item2.PointS.X * jf.smooth, item1.PointS.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item2.PointS.X, item1.PointS.Y) });
                DrawStrPoint(new Point(item1.PointLD.X * jf.smooth, item2.PointLD.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item1.PointLD.X ,item2.PointLD.Y) });
                DrawStrPoint(new Point(item2.PointLD.X * jf.smooth, item1.PointLD.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item2.PointLD.X, item1.PointLD.Y) });
                DrawStrPoint(new Point(item1.PointRU.X * jf.smooth, item2.PointRU.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item1.PointRU.X, item2.PointRU.Y) });
                DrawStrPoint(new Point(item2.PointRU.X * jf.smooth, item1.PointRU.Y * jf.smooth), e, jf, Color.Red);
                lst_jxyAllPints.Add(new jXYAllPints { PointO = new Point(item2.PointRU.X, item1.PointRU.Y) });
            }
        }
    }

    /// <summary>
    /// 畫字與圖的快速函式呼叫
    /// </summary>
    /// <param name="_pot">Point</param>
    /// <param name="e">UI 物件 PictureBox -> 事件 PaintEventArgs</param>
    /// <param name="jf">jFile 類別</param>
    /// <param name="color">顏色</param>
    public void DrawStrPoint(Point _pot , PaintEventArgs e,jFile jf,Color color)
    {
        
        Pen p2 = new Pen(color, 1);
        e.Graphics.DrawString(String.Format("({0},{1})", _pot.X/jf.smooth, _pot.Y/jf.smooth), new Font("Arial", 7), new SolidBrush(Color.Black), _pot);
        Pen p1 = new Pen(color, 1);
        e.Graphics.DrawLine(p1, new Point(_pot.X - 3, _pot.Y - 3), new Point(_pot.X + 3, _pot.Y + 3));
        e.Graphics.DrawLine(p1, new Point(_pot.X + 3, _pot.Y - 3), new Point(_pot.X - 3, _pot.Y + 3));
        Console.WriteLine(String.Format("DrawStrPoint({0},{1})",_pot.X/jf.smooth,_pot.Y/jf.smooth));

    }
}
