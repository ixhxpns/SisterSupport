using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class jXYObstacle
{
    //讀檔的第一個座標
    public Point PointF { set; get; }
    //讀檔的第二個座標
    public Point PointS { set; get; }
    //第一座標X第二座標Y-> Left,Down 左下座標
    public Point PointLD { get { return new Point(PointF.X, PointS.Y); } }
    //第二座標X第一座標Y-> Right,Up 右上座標
    public Point PointRU { get { return new Point(PointS.X, PointF.Y); } }
    //障礙物的寬(橫向)
    public decimal FS_Dist_x
    {
        get
        {
            if ((PointF == null) || (PointS == null))
            {
                return 0;
            }
            return Math.Abs(PointF.X - PointS.X);
        }
    }
    //障礙物的長(縱向)
    public decimal FS_Dist_y
    {
        get
        {
            if ((PointF == null) || (PointS == null))
            {
                return 0;
            }
            return Math.Abs(PointF.Y - PointS.Y);
        }
    }
}
