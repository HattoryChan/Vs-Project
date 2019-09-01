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
using System.IO.Ports;


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

        GraphDraw Bot_Draw, Bot_Draw2;
        SerialPort serialPort1 = new SerialPort();
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

            // Bot_Draw = new GraphDraw(Bot_Graphics_Box, twoPoint, twoPointTime, twoPoint_count);
             Bot_Draw = new GraphDraw(Bot_Graphics_Box);
             Bot_Draw2 = new GraphDraw(Bot_Graphics_Box);

            //Help desk part
            ToolTip help = new ToolTip();
            help.SetToolTip(ShowOtherPoint_lb, "Click to change additional graphic");
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
                //Add items to point array
                Bot_Draw.MouseUp(sender, e, DrawPoint_lb);
               // Bot_Draw2.MouseUp(sender,new MouseEventArgs(e.Button, e.Clicks, e.X+10, e.Y+10, e.Delta), listBox1);
            }
            else
                MessageBox.Show("You mark not pass!");
        }



        private void Graphics_Box_Paint(object sender, PaintEventArgs e)
        {
            //Draw graphic for Bottom heater
            Pen PenBlack = new Pen(Color.Black, 2);
            Bot_Draw.Paint(sender, e, Color.Black);
            Bot_Draw2.Paint(sender, e, Color.Blue);

        }

        private void GraphicDr_chBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GraphicDr_chBox.Checked) //Create first dot and  allow you start to drawing
            {
                IsClicked = true;
                // Add items to list box
                Bot_Draw.DrawStart(DrawPoint_lb);
                Bot_Draw2.DrawStart(OtherPoint_lb);

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

                TimeSetHelp_lb.Text = "In the point column the time" + Environment.NewLine + "        will be in minutes!";
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

            Bot_Draw.TimeSet(TimeSet_tBox, DrawPoint_lb, SelectedDot);

            //Sett time: add to array and to list box
            TimeSet_tBox.Clear();  //Clear TextBox
            
        }

        private void TxtSave_Butt_Click(object sender, EventArgs e)
        {
            //Save to txt in format: point.Y \t time
             Bot_Draw.TxtSave(saveFileDialog1);

            MessageBox.Show("Файл сохранен");
        }

        private void TimeSet_tBox_KeyPress(object sender, KeyPressEventArgs e)
        {  //Create perform Click if we pressed Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimeSett_butt.PerformClick();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(DoUpdate));
            Bot_Graphics_Box.Invalidate();
        }

        private void DoUpdate(object s, EventArgs e)
        {
            char[] rMess;
            rMess = serialPort1.ReadLine().ToCharArray();
            int Time = 0;
            string s_rMess = new string(rMess);
            //Message type:
            //head pr  temp  ti:me crc Start with 0- sec, 1- min, 2 - hour
            // 01   0  000   00 00 0
            if (rMess.Length == 12 && rMess[0] == '0')
            {
              //In [10] position: 0 - sec, 1-min 2-hour    07:25 = (0*10 + 7)*60 + (2*10 + 5)
              if (rMess[10] == '1') Time = ( ((rMess[6]-48) * 10 + (rMess[7]-48))*60 + ( (rMess[8]-48) * 10 + (rMess[9]-48) ));          
              // X - Time, Y - Temp
              Bot_Draw2.AddToDotList(new Point(Time, (rMess[3]-48) * 100 + (rMess[4]-48) * 10 + (rMess[5]-48)), OtherPoint_lb);           
              Array.Clear(rMess,0, rMess.Length);
            }
        }


        private void COMConn_Butt_Click(object sender, EventArgs e)
        {
            try
            {

                // настройки порта
                serialPort1.PortName = COMChoose_comBox.SelectedItem.ToString();
                serialPort1.BaudRate = 56000;
                serialPort1.DataBits = 8;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.ReadTimeout = 1000;
                serialPort1.WriteTimeout = 1000;
                serialPort1.DataReceived += serialPort1_DataReceived;
                serialPort1.Open();
                COMConnStatus_lb.Text = "Opened";
            }
            catch (Exception eX)
            {
                MessageBox.Show("ERROR: невозможно открыть порт:" + eX.ToString());                
            }
        }

        private void DisconnCOM_Butt_Click(object sender, EventArgs e)
        {
            
            try
            {
                serialPort1.Close();
                COMConnStatus_lb.Text = "Closed";
            }
            catch
            {
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch
            {
            }
        }

        private void COMConnStatus_lb_Click(object sender, EventArgs e)
        {

        }

        private void ShowOtherPoint_lb_Click(object sender, EventArgs e)
        {

        }

        private void COMGet_Butt_Click(object sender, EventArgs e)
        {
            COMChoose_comBox.Items.Clear();
            foreach (string portName in SerialPort.GetPortNames())
            {
                COMChoose_comBox.Items.Add(portName);
            }
            COMChoose_comBox.SelectedIndex = 0;
        }
    }
}
