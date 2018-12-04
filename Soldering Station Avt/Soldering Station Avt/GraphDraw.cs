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

        Point[] twoPoint;
        int[] twoPointTime;
        int twoPoint_count;

        public GraphDraw (PictureBox GraphBox, Point[] DotPoint, int[] TimePoint, int DotPoint_count)
        {
            Graphics = GraphBox;
            twoPoint = DotPoint;
            twoPointTime = TimePoint;
            twoPoint_count = DotPoint_count;
        }

        public void Pen_sett(Pen LinePen)
        {
            Pen_Line = LinePen;
        }

        public void PenDot_sett(Pen DotPen)
        {
            Pen_Dot = DotPen;
        }




        public void Paint(object sender, PaintEventArgs e)
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
                        e.Graphics.DrawRectangle(Pen_Dot, twoPoint[i - 1].X - (Pen_Dot.Width / 2), (Graphics.Height - twoPoint[i - 1].Y) - (Pen_Dot.Width / 2), b, b); //Draw point
                    }
                    e.Graphics.DrawLine(Pen_Line, new Point(twoPoint[i - 2].X, Graphics.Height - twoPoint[i - 2].Y),
                                                        new Point(twoPoint[i - 1].X, Graphics.Height - twoPoint[i - 1].Y)); //Draw line
                }
            }
        }
    }
}
