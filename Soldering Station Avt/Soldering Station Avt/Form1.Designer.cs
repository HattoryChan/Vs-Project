namespace Soldering_Station_Avt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Bot_Graphics_Box = new System.Windows.Forms.PictureBox();
            this.GraphicDr_chBox = new System.Windows.Forms.CheckBox();
            this.Coord_lb = new System.Windows.Forms.Label();
            this.ShowCoordLabel = new System.Windows.Forms.Label();
            this.DrawPoint_lb = new System.Windows.Forms.ListBox();
            this.BottHeat_lb = new System.Windows.Forms.Label();
            this.BottomH_pnl = new System.Windows.Forms.Panel();
            this.TopH_pnl = new System.Windows.Forms.Panel();
            this.TopHeat_lb = new System.Windows.Forms.Label();
            this.Top_Graphics_Box = new System.Windows.Forms.PictureBox();
            this.MenuMain_tabCon = new System.Windows.Forms.TabControl();
            this.Bottom_tabP = new System.Windows.Forms.TabPage();
            this.Top_tabP = new System.Windows.Forms.TabPage();
            this.Sett_tabP = new System.Windows.Forms.TabPage();
            this.COMConnStatus_lb = new System.Windows.Forms.Label();
            this.DisconnCOM_Butt = new System.Windows.Forms.Button();
            this.COMGet_Butt = new System.Windows.Forms.Button();
            this.COMChoose_comBox = new System.Windows.Forms.ComboBox();
            this.COMConn_Butt = new System.Windows.Forms.Button();
            this.TxtSave_Butt = new System.Windows.Forms.Button();
            this.TimeSet_pnl = new System.Windows.Forms.Panel();
            this.TimeSetHelp_lb = new System.Windows.Forms.Label();
            this.TimePostfix_lb = new System.Windows.Forms.Label();
            this.TimeSet_comBox = new System.Windows.Forms.ComboBox();
            this.TimeSett_butt = new System.Windows.Forms.Button();
            this.TimeSet_tBox = new System.Windows.Forms.TextBox();
            this.TimeSet_lb = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OtherPoint_lb = new System.Windows.Forms.ListBox();
            this.ShowDrawPointName_lb = new System.Windows.Forms.Label();
            this.ShowOtherPoint_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Bot_Graphics_Box)).BeginInit();
            this.BottomH_pnl.SuspendLayout();
            this.TopH_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Top_Graphics_Box)).BeginInit();
            this.MenuMain_tabCon.SuspendLayout();
            this.Bottom_tabP.SuspendLayout();
            this.Top_tabP.SuspendLayout();
            this.Sett_tabP.SuspendLayout();
            this.TimeSet_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bot_Graphics_Box
            // 
            this.Bot_Graphics_Box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Bot_Graphics_Box.Location = new System.Drawing.Point(8, 20);
            this.Bot_Graphics_Box.Name = "Bot_Graphics_Box";
            this.Bot_Graphics_Box.Size = new System.Drawing.Size(1000, 470);
            this.Bot_Graphics_Box.TabIndex = 0;
            this.Bot_Graphics_Box.TabStop = false;
            this.Bot_Graphics_Box.Click += new System.EventHandler(this.Graphics_Box_Click);
            this.Bot_Graphics_Box.Paint += new System.Windows.Forms.PaintEventHandler(this.Graphics_Box_Paint);
            this.Bot_Graphics_Box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graphics_Box_MouseDown);
            this.Bot_Graphics_Box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graphics_Box_MouseMove);
            this.Bot_Graphics_Box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Graphics_Box_MouseUp);
            // 
            // GraphicDr_chBox
            // 
            this.GraphicDr_chBox.AutoSize = true;
            this.GraphicDr_chBox.Location = new System.Drawing.Point(700, 540);
            this.GraphicDr_chBox.Name = "GraphicDr_chBox";
            this.GraphicDr_chBox.Size = new System.Drawing.Size(95, 17);
            this.GraphicDr_chBox.TabIndex = 1;
            this.GraphicDr_chBox.Text = "Create graphic";
            this.GraphicDr_chBox.UseVisualStyleBackColor = true;
            this.GraphicDr_chBox.CheckedChanged += new System.EventHandler(this.GraphicDr_chBox_CheckedChanged);
            // 
            // Coord_lb
            // 
            this.Coord_lb.AutoSize = true;
            this.Coord_lb.Location = new System.Drawing.Point(30, 555);
            this.Coord_lb.Name = "Coord_lb";
            this.Coord_lb.Size = new System.Drawing.Size(58, 13);
            this.Coord_lb.TabIndex = 2;
            this.Coord_lb.Text = "Coordinate";
            // 
            // ShowCoordLabel
            // 
            this.ShowCoordLabel.AutoSize = true;
            this.ShowCoordLabel.Location = new System.Drawing.Point(30, 540);
            this.ShowCoordLabel.Name = "ShowCoordLabel";
            this.ShowCoordLabel.Size = new System.Drawing.Size(96, 13);
            this.ShowCoordLabel.TabIndex = 3;
            this.ShowCoordLabel.Text = "[Time],[Coordinate]";
            // 
            // DrawPoint_lb
            // 
            this.DrawPoint_lb.FormattingEnabled = true;
            this.DrawPoint_lb.Location = new System.Drawing.Point(1030, 30);
            this.DrawPoint_lb.Name = "DrawPoint_lb";
            this.DrawPoint_lb.Size = new System.Drawing.Size(100, 498);
            this.DrawPoint_lb.TabIndex = 5;
            this.DrawPoint_lb.SelectedIndexChanged += new System.EventHandler(this.DrawPoint_lb_SelectedIndexChanged);
            // 
            // BottHeat_lb
            // 
            this.BottHeat_lb.AutoSize = true;
            this.BottHeat_lb.Location = new System.Drawing.Point(5, 5);
            this.BottHeat_lb.Name = "BottHeat_lb";
            this.BottHeat_lb.Size = new System.Drawing.Size(76, 13);
            this.BottHeat_lb.TabIndex = 9;
            this.BottHeat_lb.Text = "Bottom heater:";
            // 
            // BottomH_pnl
            // 
            this.BottomH_pnl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BottomH_pnl.Controls.Add(this.BottHeat_lb);
            this.BottomH_pnl.Controls.Add(this.Bot_Graphics_Box);
            this.BottomH_pnl.Location = new System.Drawing.Point(3, 2);
            this.BottomH_pnl.Name = "BottomH_pnl";
            this.BottomH_pnl.Size = new System.Drawing.Size(1010, 509);
            this.BottomH_pnl.TabIndex = 10;
            // 
            // TopH_pnl
            // 
            this.TopH_pnl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TopH_pnl.Controls.Add(this.TopHeat_lb);
            this.TopH_pnl.Controls.Add(this.Top_Graphics_Box);
            this.TopH_pnl.Location = new System.Drawing.Point(3, 2);
            this.TopH_pnl.Name = "TopH_pnl";
            this.TopH_pnl.Size = new System.Drawing.Size(1026, 509);
            this.TopH_pnl.TabIndex = 11;
            // 
            // TopHeat_lb
            // 
            this.TopHeat_lb.AutoSize = true;
            this.TopHeat_lb.Location = new System.Drawing.Point(5, 4);
            this.TopHeat_lb.Name = "TopHeat_lb";
            this.TopHeat_lb.Size = new System.Drawing.Size(62, 13);
            this.TopHeat_lb.TabIndex = 9;
            this.TopHeat_lb.Text = "Top heater:";
            // 
            // Top_Graphics_Box
            // 
            this.Top_Graphics_Box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Top_Graphics_Box.Location = new System.Drawing.Point(8, 20);
            this.Top_Graphics_Box.Name = "Top_Graphics_Box";
            this.Top_Graphics_Box.Size = new System.Drawing.Size(1000, 470);
            this.Top_Graphics_Box.TabIndex = 0;
            this.Top_Graphics_Box.TabStop = false;
            this.Top_Graphics_Box.Click += new System.EventHandler(this.Top_Graphics_Box_Click);
            // 
            // MenuMain_tabCon
            // 
            this.MenuMain_tabCon.Controls.Add(this.Bottom_tabP);
            this.MenuMain_tabCon.Controls.Add(this.Top_tabP);
            this.MenuMain_tabCon.Controls.Add(this.Sett_tabP);
            this.MenuMain_tabCon.Location = new System.Drawing.Point(9, 10);
            this.MenuMain_tabCon.Name = "MenuMain_tabCon";
            this.MenuMain_tabCon.SelectedIndex = 0;
            this.MenuMain_tabCon.Size = new System.Drawing.Size(1020, 526);
            this.MenuMain_tabCon.TabIndex = 11;
            this.MenuMain_tabCon.SelectedIndexChanged += new System.EventHandler(this.MenuMain_tabCon_SelectedIndexChanged);
            this.MenuMain_tabCon.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MenuMain_tabCon_Selecting);
            // 
            // Bottom_tabP
            // 
            this.Bottom_tabP.Controls.Add(this.BottomH_pnl);
            this.Bottom_tabP.Location = new System.Drawing.Point(4, 22);
            this.Bottom_tabP.Name = "Bottom_tabP";
            this.Bottom_tabP.Padding = new System.Windows.Forms.Padding(3);
            this.Bottom_tabP.Size = new System.Drawing.Size(1012, 500);
            this.Bottom_tabP.TabIndex = 0;
            this.Bottom_tabP.Text = "Bottom";
            this.Bottom_tabP.UseVisualStyleBackColor = true;
            // 
            // Top_tabP
            // 
            this.Top_tabP.Controls.Add(this.TopH_pnl);
            this.Top_tabP.Location = new System.Drawing.Point(4, 22);
            this.Top_tabP.Name = "Top_tabP";
            this.Top_tabP.Padding = new System.Windows.Forms.Padding(3);
            this.Top_tabP.Size = new System.Drawing.Size(1012, 500);
            this.Top_tabP.TabIndex = 1;
            this.Top_tabP.Text = "Top";
            this.Top_tabP.UseVisualStyleBackColor = true;
            // 
            // Sett_tabP
            // 
            this.Sett_tabP.Controls.Add(this.COMConnStatus_lb);
            this.Sett_tabP.Controls.Add(this.DisconnCOM_Butt);
            this.Sett_tabP.Controls.Add(this.COMGet_Butt);
            this.Sett_tabP.Controls.Add(this.COMChoose_comBox);
            this.Sett_tabP.Controls.Add(this.COMConn_Butt);
            this.Sett_tabP.Controls.Add(this.TxtSave_Butt);
            this.Sett_tabP.Location = new System.Drawing.Point(4, 22);
            this.Sett_tabP.Name = "Sett_tabP";
            this.Sett_tabP.Padding = new System.Windows.Forms.Padding(3);
            this.Sett_tabP.Size = new System.Drawing.Size(1012, 500);
            this.Sett_tabP.TabIndex = 2;
            this.Sett_tabP.Text = "Setting";
            this.Sett_tabP.UseVisualStyleBackColor = true;
            // 
            // COMConnStatus_lb
            // 
            this.COMConnStatus_lb.AutoSize = true;
            this.COMConnStatus_lb.Location = new System.Drawing.Point(756, 97);
            this.COMConnStatus_lb.Name = "COMConnStatus_lb";
            this.COMConnStatus_lb.Size = new System.Drawing.Size(39, 13);
            this.COMConnStatus_lb.TabIndex = 5;
            this.COMConnStatus_lb.Text = "Closed";
            this.COMConnStatus_lb.Click += new System.EventHandler(this.COMConnStatus_lb_Click);
            // 
            // DisconnCOM_Butt
            // 
            this.DisconnCOM_Butt.Location = new System.Drawing.Point(875, 64);
            this.DisconnCOM_Butt.Name = "DisconnCOM_Butt";
            this.DisconnCOM_Butt.Size = new System.Drawing.Size(110, 30);
            this.DisconnCOM_Butt.TabIndex = 4;
            this.DisconnCOM_Butt.Text = "Disconnect to COM";
            this.DisconnCOM_Butt.UseVisualStyleBackColor = true;
            this.DisconnCOM_Butt.Click += new System.EventHandler(this.DisconnCOM_Butt_Click);
            // 
            // COMGet_Butt
            // 
            this.COMGet_Butt.Location = new System.Drawing.Point(951, 12);
            this.COMGet_Butt.Name = "COMGet_Butt";
            this.COMGet_Butt.Size = new System.Drawing.Size(44, 32);
            this.COMGet_Butt.TabIndex = 3;
            this.COMGet_Butt.Text = "Get";
            this.COMGet_Butt.UseVisualStyleBackColor = true;
            this.COMGet_Butt.Click += new System.EventHandler(this.COMGet_Butt_Click);
            // 
            // COMChoose_comBox
            // 
            this.COMChoose_comBox.FormattingEnabled = true;
            this.COMChoose_comBox.Location = new System.Drawing.Point(759, 19);
            this.COMChoose_comBox.Name = "COMChoose_comBox";
            this.COMChoose_comBox.Size = new System.Drawing.Size(176, 21);
            this.COMChoose_comBox.TabIndex = 2;
            // 
            // COMConn_Butt
            // 
            this.COMConn_Butt.Location = new System.Drawing.Point(759, 64);
            this.COMConn_Butt.Name = "COMConn_Butt";
            this.COMConn_Butt.Size = new System.Drawing.Size(100, 30);
            this.COMConn_Butt.TabIndex = 1;
            this.COMConn_Butt.Text = "Connect to COM";
            this.COMConn_Butt.UseVisualStyleBackColor = true;
            this.COMConn_Butt.Click += new System.EventHandler(this.COMConn_Butt_Click);
            // 
            // TxtSave_Butt
            // 
            this.TxtSave_Butt.Location = new System.Drawing.Point(27, 47);
            this.TxtSave_Butt.Name = "TxtSave_Butt";
            this.TxtSave_Butt.Size = new System.Drawing.Size(129, 34);
            this.TxtSave_Butt.TabIndex = 0;
            this.TxtSave_Butt.Text = "Save To Txt";
            this.TxtSave_Butt.UseVisualStyleBackColor = true;
            this.TxtSave_Butt.Click += new System.EventHandler(this.TxtSave_Butt_Click);
            // 
            // TimeSet_pnl
            // 
            this.TimeSet_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeSet_pnl.Controls.Add(this.TimeSetHelp_lb);
            this.TimeSet_pnl.Controls.Add(this.TimePostfix_lb);
            this.TimeSet_pnl.Controls.Add(this.TimeSet_comBox);
            this.TimeSet_pnl.Controls.Add(this.TimeSett_butt);
            this.TimeSet_pnl.Controls.Add(this.TimeSet_tBox);
            this.TimeSet_pnl.Controls.Add(this.TimeSet_lb);
            this.TimeSet_pnl.Location = new System.Drawing.Point(1033, 359);
            this.TimeSet_pnl.Name = "TimeSet_pnl";
            this.TimeSet_pnl.Size = new System.Drawing.Size(220, 115);
            this.TimeSet_pnl.TabIndex = 10;
            // 
            // TimeSetHelp_lb
            // 
            this.TimeSetHelp_lb.AutoSize = true;
            this.TimeSetHelp_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeSetHelp_lb.Location = new System.Drawing.Point(10, 78);
            this.TimeSetHelp_lb.Name = "TimeSetHelp_lb";
            this.TimeSetHelp_lb.Size = new System.Drawing.Size(319, 16);
            this.TimeSetHelp_lb.TabIndex = 5;
            this.TimeSetHelp_lb.Text = "In the point column the time will be in minutes!";
            // 
            // TimePostfix_lb
            // 
            this.TimePostfix_lb.AutoSize = true;
            this.TimePostfix_lb.Location = new System.Drawing.Point(130, 9);
            this.TimePostfix_lb.Name = "TimePostfix_lb";
            this.TimePostfix_lb.Size = new System.Drawing.Size(29, 13);
            this.TimePostfix_lb.TabIndex = 4;
            this.TimePostfix_lb.Text = "Unit:";
            // 
            // TimeSet_comBox
            // 
            this.TimeSet_comBox.FormattingEnabled = true;
            this.TimeSet_comBox.Location = new System.Drawing.Point(130, 25);
            this.TimeSet_comBox.Name = "TimeSet_comBox";
            this.TimeSet_comBox.Size = new System.Drawing.Size(60, 21);
            this.TimeSet_comBox.TabIndex = 3;
            // 
            // TimeSett_butt
            // 
            this.TimeSett_butt.Location = new System.Drawing.Point(65, 50);
            this.TimeSett_butt.Name = "TimeSett_butt";
            this.TimeSett_butt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimeSett_butt.Size = new System.Drawing.Size(70, 25);
            this.TimeSett_butt.TabIndex = 2;
            this.TimeSett_butt.Text = "Set time";
            this.TimeSett_butt.UseVisualStyleBackColor = true;
            this.TimeSett_butt.Click += new System.EventHandler(this.TimeSett_butt_Click);
            // 
            // TimeSet_tBox
            // 
            this.TimeSet_tBox.Location = new System.Drawing.Point(15, 25);
            this.TimeSet_tBox.Name = "TimeSet_tBox";
            this.TimeSet_tBox.Size = new System.Drawing.Size(100, 20);
            this.TimeSet_tBox.TabIndex = 1;
            this.TimeSet_tBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeSet_tBox_KeyPress);
            // 
            // TimeSet_lb
            // 
            this.TimeSet_lb.AutoSize = true;
            this.TimeSet_lb.Location = new System.Drawing.Point(10, 10);
            this.TimeSet_lb.Name = "TimeSet_lb";
            this.TimeSet_lb.Size = new System.Drawing.Size(101, 13);
            this.TimeSet_lb.TabIndex = 0;
            this.TimeSet_lb.Text = "Set Time for Button:";
            // 
            // OtherPoint_lb
            // 
            this.OtherPoint_lb.FormattingEnabled = true;
            this.OtherPoint_lb.Location = new System.Drawing.Point(1135, 30);
            this.OtherPoint_lb.Name = "OtherPoint_lb";
            this.OtherPoint_lb.Size = new System.Drawing.Size(100, 498);
            this.OtherPoint_lb.TabIndex = 12;
            // 
            // ShowDrawPointName_lb
            // 
            this.ShowDrawPointName_lb.AutoSize = true;
            this.ShowDrawPointName_lb.Location = new System.Drawing.Point(1030, 15);
            this.ShowDrawPointName_lb.Name = "ShowDrawPointName_lb";
            this.ShowDrawPointName_lb.Size = new System.Drawing.Size(72, 13);
            this.ShowDrawPointName_lb.TabIndex = 13;
            this.ShowDrawPointName_lb.Text = "Drawing point";
            // 
            // ShowOtherPoint_lb
            // 
            this.ShowOtherPoint_lb.AutoSize = true;
            this.ShowOtherPoint_lb.Location = new System.Drawing.Point(1135, 15);
            this.ShowOtherPoint_lb.Name = "ShowOtherPoint_lb";
            this.ShowOtherPoint_lb.Size = new System.Drawing.Size(62, 13);
            this.ShowOtherPoint_lb.TabIndex = 14;
            this.ShowOtherPoint_lb.Text = "Click to me!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 582);
            this.Controls.Add(this.ShowOtherPoint_lb);
            this.Controls.Add(this.ShowDrawPointName_lb);
            this.Controls.Add(this.TimeSet_pnl);
            this.Controls.Add(this.OtherPoint_lb);
            this.Controls.Add(this.MenuMain_tabCon);
            this.Controls.Add(this.DrawPoint_lb);
            this.Controls.Add(this.ShowCoordLabel);
            this.Controls.Add(this.Coord_lb);
            this.Controls.Add(this.GraphicDr_chBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bot_Graphics_Box)).EndInit();
            this.BottomH_pnl.ResumeLayout(false);
            this.BottomH_pnl.PerformLayout();
            this.TopH_pnl.ResumeLayout(false);
            this.TopH_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Top_Graphics_Box)).EndInit();
            this.MenuMain_tabCon.ResumeLayout(false);
            this.Bottom_tabP.ResumeLayout(false);
            this.Top_tabP.ResumeLayout(false);
            this.Sett_tabP.ResumeLayout(false);
            this.Sett_tabP.PerformLayout();
            this.TimeSet_pnl.ResumeLayout(false);
            this.TimeSet_pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Bot_Graphics_Box;
        private System.Windows.Forms.CheckBox GraphicDr_chBox;
        private System.Windows.Forms.Label Coord_lb;
        private System.Windows.Forms.Label ShowCoordLabel;
        private System.Windows.Forms.ListBox DrawPoint_lb;
        private System.Windows.Forms.Label BottHeat_lb;
        private System.Windows.Forms.Panel BottomH_pnl;
        private System.Windows.Forms.Panel TopH_pnl;
        private System.Windows.Forms.Label TopHeat_lb;
        private System.Windows.Forms.PictureBox Top_Graphics_Box;
        private System.Windows.Forms.TabControl MenuMain_tabCon;
        private System.Windows.Forms.TabPage Bottom_tabP;
        private System.Windows.Forms.TabPage Top_tabP;
        private System.Windows.Forms.Panel TimeSet_pnl;
        private System.Windows.Forms.Label TimeSet_lb;
        private System.Windows.Forms.ComboBox TimeSet_comBox;
        private System.Windows.Forms.Button TimeSett_butt;
        private System.Windows.Forms.TextBox TimeSet_tBox;
        private System.Windows.Forms.TabPage Sett_tabP;
        private System.Windows.Forms.Button TxtSave_Butt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox OtherPoint_lb;
        private System.Windows.Forms.Button COMGet_Butt;
        private System.Windows.Forms.ComboBox COMChoose_comBox;
        private System.Windows.Forms.Button COMConn_Butt;
        private System.Windows.Forms.Button DisconnCOM_Butt;
        private System.Windows.Forms.Label COMConnStatus_lb;
        private System.Windows.Forms.Label ShowDrawPointName_lb;
        private System.Windows.Forms.Label ShowOtherPoint_lb;
        private System.Windows.Forms.Label TimeSetHelp_lb;
        private System.Windows.Forms.Label TimePostfix_lb;
    }
}

