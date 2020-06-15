using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 计算练习
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public void Export(List<string> result, string path, string title= "计算练习", string filename= "计算练习")
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            StringBuilder sb = new StringBuilder();
            sb.Append($"<html><HEAD><META http-equiv=Content-Type content='text/html; charset=gb2312'></head><body><center><h2>{title}</h2><h3></h3>班级__________ 姓名________ 学号__________<br><br><table border=0 width=640 cellspacing=10>");
            for (int i = 0; i < result.Count; i++)
            {
                if (i == 0) sb.Append("<tr>");
                else if (i % 4 == 0) sb.Append("</tr><tr>");
                sb.Append("<td>" + result[i] + "＝</td>");
            }
            sb.Append("</tr><tr></tr></table></center></body></html>");
            if (File.Exists(System.IO.Path.Combine(path, $"{filename}.htm")))
            {
                int i = 1;
                while (File.Exists(System.IO.Path.Combine(path, $"{filename}{i}.htm")))
                {
                    i++;
                }
                filename = filename + i;
            }
            File.WriteAllText(System.IO.Path.Combine(path, $"{filename}.htm"), sb.ToString(), Encoding.Unicode);
            Process.Start(System.IO.Path.Combine(path, $"{filename}.htm"));
        }

        private void btn1b_Click(object sender, RoutedEventArgs e)
        {
            List<string> result = new List<string>();
            Calculation.出题(Convert.ToInt16(txt1bt1.Text), Calculation.二十以内加减法, result);
            Calculation.出题(Convert.ToInt16(txt1bt2.Text), Calculation.两位数加减个位, result);
            Calculation.出题(Convert.ToInt16(txt1bt3.Text), Calculation.两位数加减整十, result);
            result = Calculation.RandomSortList<string>(result);
            Export(result, null);
        }

        private void btn2a_Click(object sender, RoutedEventArgs e)
        {
            List<string> result = new List<string>();
            Calculation.出题(Convert.ToInt16(t1.Text), Calculation.X以内乘法, Convert.ToInt16(s1.Text), result);
            Calculation.出题(Convert.ToInt16(t2.Text), Calculation.X以内除法, Convert.ToInt16(s2.Text), result);
            Calculation.出题(Convert.ToInt16(t3.Text), Calculation.X以内加法, Convert.ToInt16(s3.Text), chkUnCarry.IsChecked ?? false, result);
            Calculation.出题(Convert.ToInt16(t4.Text), Calculation.X以内减法, Convert.ToInt16(s4.Text), chkUnBorrow.IsChecked ?? false, result);
            Calculation.出题(Convert.ToInt16(t5.Text), Calculation.两位数加减个位, result);
            Calculation.出题(Convert.ToInt16(t6.Text), Calculation.两位数加减整十, result);
            Calculation.出题(Convert.ToInt16(t7.Text), Calculation.二十以内加减法, result);
            Calculation.出题(Convert.ToInt16(t8.Text), Calculation.易混淆加减法, Convert.ToInt16(s8.Text), result);

            result = Calculation.RandomSortList<string>(result);
            Export(result, null);
        }

        private void btn2b_Click(object sender, RoutedEventArgs e)
        {
            List<string> result = new List<string>();
            Calculation.出题(Convert.ToInt16(t2b1.Text), Calculation.两位数加减法, result);
            Calculation.出题(Convert.ToInt16(t2b2.Text), Calculation.二千以内整百加减法, result);
            Export(result, null);
        }
    }
}
