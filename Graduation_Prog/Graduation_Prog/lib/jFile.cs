using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class jFile
{
    public string path { get; set; } = @"C:\CodeData\input_example.txt"; //預設路徑

    public List<jXYRange> lst_XYRange = new List<jXYRange>();
    public List<jXYPoint> lst_XYPoint = new List<jXYPoint>();
    public List<jXYObstacle> lst_XYObstacle = new List<jXYObstacle>();
    public int smooth = 5;


    public List<string> filePara()
    {
        int counter = 0;
        int chgBlock = 1; //三種區塊的座標
        string line;
        List<string> readLineList = new List<string>();
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while ((line = file.ReadLine()) != null)
        {
            if (line.Length == 0)
            {
                chgBlock++;
                continue;
            }
            switch (chgBlock)
            {
                case 1:
                    if (line.IndexOf(@")(") > -1)
                    {
                        string[] PointSplit = line.Split(new char[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
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

                    if (line.IndexOf(@")(") > -1)
                    {
                        string[] PointSplit = line.Split(new char[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
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
                                jXYObstacle jxyObstacle = new jXYObstacle();
                                _x1 = int.Parse(PointSplit[i].Split(new char[] { ',', ')' })[0]);
                                _y1 = int.Parse(PointSplit[i].Split(new char[] { ',', ')' })[1]);
                                jxyObstacle.PointF = new System.Drawing.Point(_x0, _y0);
                                jxyObstacle.PointS = new System.Drawing.Point(_x1, _y1);
                                lst_XYObstacle.Add(jxyObstacle);
                            }
                        }
                    }
                    break;
                case 3:
                    int _x = 0, _y = 0;
                    _x = int.Parse(line.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    _y = int.Parse(line.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    jXYPoint jxyPoint = new jXYPoint();
                    jxyPoint.PointO = new System.Drawing.Point(_x * smooth, _y * smooth);
                    lst_XYPoint.Add(jxyPoint);
                    break;
            }
            //readLineList.Add(line);
            counter++;
        }
        file.Close();
        System.Console.WriteLine("All Count Lines -> {0}", counter);
        return readLineList;
    }

}
