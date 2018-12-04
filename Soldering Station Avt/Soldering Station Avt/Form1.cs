using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Soldering_Station_Avt
{
    public partial class Form1 : Form
    {
        
        Point[] twoPoint = new Point[100];
        int[] twoPointTime = new int[100];
        bool IsClicked = false;
        int twoPoint_count = 1;
        int SelectedDot = 0;

        int dotRadius = 5;
        int lineWidth = 2;

        int GridMainWigth = 5;
        int GridSecWigth = 1;
        int GridScaleMax = 500;
        int GridScaleMin = 0;
        int GridScaleStep = 25;
        int GridTextSize = 8;

       
        public Form1()
        {
            InitializeComponent();
            TimeSet_pnl.Location = new Point(402, 168);  //Set panel to centre
            TimeSet_pnl.Visible = false;                //And dont see it

            BottomH_pnl.Controls.Add(BottHeat_lb);   //Attach the elements to panel
            BottomH_pnl.Controls.Add(Bot_Graphics_Box);

            TopH_pnl.Controls.Add(TopHeat_lb);
            TopH_pnl.Controls.Add(Top_Graphics_Box);

            TimeSet_comBox.Items.AddRange(new string[] { "Sec", "Min", "Hour" }); //Add measurement to comBox
            TimeSet_comBox.SelectedIndex = 1; //Set Min as default

            

        }

        private void Graphics_Box_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Graphics_Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsClicked && MenuMain_tabCon.SelectedTab == Bottom_tabP)
            {
                Coord_lb.Text = $"[{e.X}], [{Convert.ToInt32(Bot_Graphics_Box.Height) - e.Y}]"; //вычитаем длинну формы из Y координаты для смены точки нуля
                Bot_Graphics_Box.Invalidate();
            }
        }

        private void Graphics_Box_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsClicked && MenuMain_tabCon.SelectedTab == Bottom_tabP)
            {
                if (twoPoint[twoPoint_count - 1].X < e.X)  //Time can't go back
                {                    
                    twoPoint[twoPoint_count] = new Point(e.X, Convert.ToInt32(Bot_Graphics_Box.Height) - e.Y ); //вычитаем длинну формы из Y координаты для смены точки нуля
                    twoPointTime[twoPoint_count] = 0;                //Add time value to Array
                    // DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
                    DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
                    twoPoint_count++;
                }
                else
                {
                    MessageBox.Show("Time does not turn back!");
                }
            }
            else
                MessageBox.Show("You mark not pass!");
        }



        private void Graphics_Box_Paint(object sender, PaintEventArgs e)
        {
            //Draw graphic for Bottom heater
            Pen PenBlack = new Pen(Color.Black, 2);
            GraphDraw Bot_Draw = new GraphDraw(Bot_Graphics_Box, twoPoint, twoPointTime, twoPoint_count);
            Bot_Draw.Paint(sender, e);

        }

        private void GraphicDr_chBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GraphicDr_chBox.Checked) //Create first dot and  allow you start to drawing
            {
                IsClicked = true;
                twoPoint[0] = new Point(0, 0);//Convert.ToInt32(Graphics_Box.Height));
                DrawPoint_lb.Items.Add($"Point {twoPoint_count} = [{twoPoint[twoPoint_count].Y},{twoPointTime[twoPoint_count]}]");
                twoPoint_count++;  

            }
            else
            {
                IsClicked = false;
                
            }
        }

        private void Graphics_Box_Click(object sender, EventArgs e)
        {               
            
        }

        private void ChangePoint_butt_Click(object sender, EventArgs e)
        {

        }

        private void DrawPoint_lb_Click(object sender, EventArgs e)
        {

        }

        private void MenuMain_tabCon_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Top_Graphics_Box_Click(object sender, EventArgs e)
        {

        }

        private void MenuMain_tabCon_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPageIndex == 1)
            {
                MessageBox.Show("TOP");
            }
            if (MenuMain_tabCon.SelectedTab == Bottom_tabP)   //This is our flag to see which panel be active!
            {
              //  MessageBox.Show("Bott");
            }
        }

        private void TimeCoord_pnl_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("You must enter the time value");
        }

        private void DrawPoint_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrawPoint_lb.SelectedIndex != -1)  //If we have changed dot
            {
                MenuMain_tabCon.Enabled = false; //Disable all other elements
                BottomH_pnl.Enabled = false;
                Bot_Graphics_Box.Enabled = false;                

                TimeSet_pnl.Visible = true;    //TimeSet panel - visible
                SelectedDot = DrawPoint_lb.SelectedIndex;   // Remember dot number
                TimeSet_lb.Text = $"Set Time for button №{SelectedDot+1} :";  // Show dot number

                TimeSet_tBox.Focus();  //Set cursor on Text Box
                
                
                DrawPoint_lb.ClearSelected();               //And Clear selected Flag
            }
            
        }

        private void TimeSett_butt_Click(object sender, EventArgs e)
        {
            //TimeSett_butt.PerformClick(); //Press to the button exp(for future)
            
            MenuMain_tabCon.Enabled = true;  //Enable all elements
            BottomH_pnl.Enabled = true;
            Bot_Graphics_Box.Enabled = true;
            GraphicDr_chBox.Enabled = true;

            TimeSet_pnl.Visible = false;       //Hide time panel

            if (!Int32.TryParse(TimeSet_tBox.Text, out int n )) //Check to Integer
            {
                MessageBox.Show("You didn't enter Integer, please, be carefull!");
            }
            else
            {
                twoPointTime[SelectedDot] = Convert.ToInt32(TimeSet_tBox.Text);       //Get Text Box value  and add to list
                DrawPoint_lb.Items[SelectedDot] = $"Point {SelectedDot+1} = [{twoPoint[SelectedDot+1].Y},{twoPointTime[SelectedDot]}]"; 
            }
            TimeSet_tBox.Clear();  //Clear TextBox
            
        }

        private void TxtSave_Butt_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            string dotString = "";
            for (int i = 1; i< twoPoint_count; i++)
            {
                dotString += $"{twoPoint[i].Y}\t{twoPointTime[i-1]}\n";
            }
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, dotString);
            MessageBox.Show("Файл сохранен");
        }
    }
}
