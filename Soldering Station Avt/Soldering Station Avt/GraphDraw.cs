using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Soldering_Station_Avt
{
    class GraphDraw 
    {

        int GridMainWigth = 5;
        int GridSecWigth = 1;
        int GridScaleMax = 500;
        int GridScaleMin = 0;
        int GridScaleStep = 25;
        int GridTextSize = 8;
        
        PictureBox Graphics;
        Pen Pen_Line = new Pen(Color.Black, 2);
        Pen Pen_Dot = new Pen(Color.Black, 5);

        Point[] twoPoint = new Point[100];
        int[] twoPointTime = new int[100];

        int twoPoint_count = 1;

        public Point[] twoPointget
        {
            get
            {
                return twoPoint;
            }

        }

        public GraphDraw (PictureBox GraphBox)//, Point[] DotPoint, int[] TimePoint, int DotPoint_count)
        {
            Graphics = GraphBox;
          //  twoPoint = DotPoint;
           // twoPointTime = TimePoint;
          //  twoPoint_count = DotPoint_count;
        }

        public void Pen_sett(Pen LinePen)
        {
            Pen_Line = LinePen;
        }

        public void PenDot_sett(Pen DotPen)
        {
            Pen_Dot = DotPen;
        }


        public void DrawStart(ListBox DrawPoint_lb)
        {
            twoPoint[0] = new Point(0, 0);//Convert.ToInt32(Graphics_Box.Height));
            DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
            twoPoint_count++;
        }

        public void AddToDotList(Point e, ListBox DrawPoint_lb)
        {
            if (twoPoint[twoPoint_count - 1].X < e.X)  //Time can't go back
            {
                twoPoint[twoPoint_count] = new Point(e.X,  e.Y); //вычитаем длинну формы из Y координаты для смены точки нуля
                twoPointTime[twoPoint_count] = e.X;                //Add time value to Array

                DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
                twoPoint_count++;
            }
            else
            {
                MessageBox.Show("Time does not turn back!");
            }
        }


        public void MouseUp(object sender, MouseEventArgs e,ListBox DrawPoint_lb)
        {
            if (twoPoint[twoPoint_count - 1].X < e.X)  //Time can't go back
            {
                twoPoint[twoPoint_count] = new Point(e.X, Convert.ToInt32(Graphics.Height) - e.Y); //вычитаем длинну формы из Y координаты для смены точки нуля
                twoPointTime[twoPoint_count] = 0;                //Add time value to Array

                DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
                twoPoint_count++;
            }
            else
            {
                MessageBox.Show("Time does not turn back!");
            }
        }

        public void TimeSet(TextBox TimeSet_tBox, ListBox DrawPoint_lb, int SelectedDot)
        {
            if (!Int32.TryParse(TimeSet_tBox.Text, out int n)) //Check to Integer
            {
                MessageBox.Show("You didn't enter Integer, please, be carefull!");
            }
            else
            {
                twoPointTime[SelectedDot] = Convert.ToInt32(TimeSet_tBox.Text);       //Get Text Box value  and add to list
                DrawPoint_lb.Items[SelectedDot] = $"Point {SelectedDot + 1} = [{twoPoint[SelectedDot + 1].Y},{twoPointTime[SelectedDot]}]";
            }
        }

        public void TxtSave(SaveFileDialog saveFileDialog1)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            string dotString = "";
            for (int i = 1; i < twoPoint_count; i++)
            {

                dotString += $"{twoPoint[i].Y}\t{twoPointTime[i-1]}\n";
            }
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, dotString);
        }

        public void Paint(object sender, PaintEventArgs e, Color PenColor)
        {

            //Remember: X and Y axes - reversed
            e.Graphics.DrawLine(new Pen(Color.Black, GridMainWigth), new Point((GridMainWigth / 3), 0), new Point((GridMainWigth / 3), Graphics.Height)); //Draw Axes
            e.Graphics.DrawLine(new Pen(Color.Black, GridMainWigth), new Point(0, Graphics.Height - (GridMainWigth / 2)), new Point(Graphics.Width, Graphics.Height - (GridMainWigth / 2)));

            for (int i = GridScaleMin; i <= GridScaleMax; i += GridScaleStep) //Draw X,Y axes and the division
            {
                e.Graphics.DrawLine(new Pen(Color.Black, GridSecWigth * 2), new Point(GridMainWigth / 2, Graphics.Height - i), new Point(GridMainWigth * 2, Graphics.Height - i)); //division

                e.Graphics.DrawString(i.ToString(), new Font("Arial", GridTextSize), new SolidBrush(Color.Black), new Point(GridMainWigth * 3, Graphics.Height - 25 - i + GridTextSize)); //value

            }


            for (int i = GridScaleMin; i <= GridScaleMax; i += (GridScaleStep + GridSecWigth / 2)) //Draw Grid
            {
                e.Graphics.DrawLine(new Pen(Color.Black, GridMainWigth / 4), new Point(0, Graphics.Height - i), new Point(Graphics.Width, Graphics.Height - i)); //main Grid
            }


            if (twoPoint_count >= 2)   //draw graphics
            {
                for (int i = 2; i <= twoPoint_count; i++)
                {
                    for (int b = 0; b <= Pen_Dot.Width; b++)   //вычитаем длинну формы из Y координаты для смены точки нуля                     
                    {
                        e.Graphics.DrawRectangle(new Pen(PenColor, Pen_Dot.Width), twoPoint[i - 1].X - (Pen_Dot.Width / 2), (Graphics.Height - twoPoint[i - 1].Y) - (Pen_Dot.Width / 2), b, b); //Draw point
                    }
                    e.Graphics.DrawLine(new Pen(PenColor, Pen_Line.Width), new Point(twoPoint[i - 2].X, Graphics.Height - twoPoint[i - 2].Y),
                                                                           new Point(twoPoint[i - 1].X, Graphics.Height - twoPoint[i - 1].Y)); //Draw line
                }
            }
        }

        /*----------------------------------------------------
         * Function for getting data
         * ---------------------------------------------------
         */
        public Point twoPoint_get(int index)
        {
            return twoPoint[index];
        }

        public int twoPointTime_get(int index)
        {
            return twoPointTime[index];
        }
    }
}
