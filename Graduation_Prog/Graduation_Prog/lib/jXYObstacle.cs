using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class jXYObstacle
{
    public Point PointF { set; get; }
    public Point PointS { set; get; }
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
    public int FS_rDist_x
    {
        get
        {
            if ((PointF == null) || (PointS == null))
            {
                return 0;
            }
            return Math.Abs(PointF.X + PointS.X);
        }
    }
    public int FS_rDist_y
    {
        get
        {
            if ((PointF == null) || (PointS == null))
            {
                return 0;
            }
            return Math.Abs(PointF.Y + PointS.Y);
        }
    }
}
