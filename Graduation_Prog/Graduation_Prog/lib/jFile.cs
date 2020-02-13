using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class jFile
{
    public string path { get; set; }

    public List<jXYRange> lst_XYRange = new List<jXYRange>();
    public List<jXYPoint> lst_XYPoint = new List<jXYPoint>();
    public List<jXYObstacle> lst_XYObstacle = new List<jXYObstacle>();


    public List<string> readOneCell(ref int LineCount)
    {
        int counter = 0;
        int chgBlock = 1; //三種區塊的座標
        string line;
        List<string> readLineList = new List<string>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (line.Length == 1)
            {
                chgBlock++;
                continue;
            }
            switch (chgBlock)
            {
                case 1:
                    if (line.IndexOf(@")(") > -1)
                    {
                        string[] PointSplit = Regex.Split(line, ")(", RegexOptions.IgnoreCase);
                        int _x0 = 0, _y0 = 0, _x1 = 0, _y1 = 0;

                        for (int i = 0; i < PointSplit.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                _x0 = int.Parse(PointSplit[i].Split(new char[] { '(', ',' })[0]);
                                _y0 = int.Parse(PointSplit[i].Split(new char[] { '(', ',' })[1]);
                            }
                            else
                            {
                                jXYRange jxyRange = new jXYRange();
                                _x1 = int.Parse(PointSplit[i].Split(new char[] { ',', ')' })[0]);
                                _y1 = int.Parse(PointSplit[i].Split(new char[] { ',', ')' })[1]);
                                jxyRange.PointF = new System.Drawing.Point(_x0, _y0);
                                jxyRange.PointS = new System.Drawing.Point(_x1, _y1);
                                lst_XYRange.Add(jxyRange);
                            }
                        }
                    }

                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            //readLineList.Add(line);
            counter++;
        }
        file.Close();
        LineCount = counter;
        System.Console.WriteLine("All Count Lines -> {0}", counter);
        return readLineList;
    }

}
