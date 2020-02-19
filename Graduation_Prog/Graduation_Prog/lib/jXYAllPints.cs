using System.Collections.Generic;
using System.Drawing;
public class jXYAllPints
{
    public Point PointO
    {
        get;
        set;
    } 
}
public static class lst_jxyAllPints
{
    public static List<jXYAllPints> lst_XYAllPints = new List<jXYAllPints>();//整張圖所有交點List
    public static void Add(jXYAllPints _ap)
    {
        //每次加入點的時候，判斷這個LIST裡有沒有一樣的座標，若沒有才能加入，排除一樣的重覆存入LIST。
        if (!lst_XYAllPints.Exists(x => x.PointO == _ap.PointO))
        {
            lst_XYAllPints.Add(_ap);
        }
    }
}