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
            this.ShowDotLabel = new System.Windows.Forms.Label();
            this.ChangeDotInfo_label = new System.Windows.Forms.Label();
            this.BottHeat_lb = new System.Windows.Forms.Label();
            this.BottomH_pnl = new System.Windows.Forms.Panel();
            this.TopH_pnl = new System.Windows.Forms.Panel();
            this.TopHeat_lb = new System.Windows.Forms.Label();
            this.Top_Graphics_Box = new System.Windows.Forms.PictureBox();
            this.MenuMain_tabCon = new System.Windows.Forms.TabControl();
            this.Bottom_tabP = new System.Windows.Forms.TabPage();
            this.Top_tabP = new System.Windows.Forms.TabPage();
            this.TimeSet_pnl = new System.Windows.Forms.Panel();
            this.TimeSet_comBox = new System.Windows.Forms.ComboBox();
            this.TimeSett_butt = new System.Windows.Forms.Button();
            this.TimeSet_tBox = new System.Windows.Forms.TextBox();
            this.TimeSet_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Bot_Graphics_Box)).BeginInit();
            this.BottomH_pnl.SuspendLayout();
            this.TopH_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Top_Graphics_Box)).BeginInit();
            this.MenuMain_tabCon.SuspendLayout();
            this.Bottom_tabP.SuspendLayout();
            this.Top_tabP.SuspendLayout();
            this.TimeSet_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bot_Graphics_Box
            // 
            this.Bot_Graphics_Box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Bot_Graphics_Box.Location = new System.Drawing.Point(8, 21);
            this.Bot_Graphics_Box.Name = "Bot_Graphics_Box";
            this.Bot_Graphics_Box.Size = new System.Drawing.Size(996, 467);
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
            this.GraphicDr_chBox.Location = new System.Drawing.Point(696, 547);
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
            this.Coord_lb.Location = new System.Drawing.Point(34, 548);
            this.Coord_lb.Name = "Coord_lb";
            this.Coord_lb.Size = new System.Drawing.Size(58, 13);
            this.Coord_lb.TabIndex = 2;
            this.Coord_lb.Text = "Coordinate";
            // 
            // ShowCoordLabel
            // 
            this.ShowCoordLabel.AutoSize = true;
            this.ShowCoordLabel.Location = new System.Drawing.Point(34, 535);
            this.ShowCoordLabel.Name = "ShowCoordLabel";
            this.ShowCoordLabel.Size = new System.Drawing.Size(96, 13);
            this.ShowCoordLabel.TabIndex = 3;
            this.ShowCoordLabel.Text = "[Time],[Coordinate]";
            // 
            // DrawPoint_lb
            // 
            this.DrawPoint_lb.FormattingEnabled = true;
            this.DrawPoint_lb.Location = new System.Drawing.Point(1033, 27);
            this.DrawPoint_lb.Name = "DrawPoint_lb";
            this.DrawPoint_lb.Size = new System.Drawing.Size(231, 472);
            this.DrawPoint_lb.TabIndex = 5;
            this.DrawPoint_lb.SelectedIndexChanged += new System.EventHandler(this.DrawPoint_lb_SelectedIndexChanged);
            // 
            // ShowDotLabel
            // 
            this.ShowDotLabel.AutoSize = true;
            this.ShowDotLabel.Location = new System.Drawing.Point(1107, 512);
            this.ShowDotLabel.Name = "ShowDotLabel";
            this.ShowDotLabel.Size = new System.Drawing.Size(149, 13);
            this.ShowDotLabel.TabIndex = 7;
            this.ShowDotLabel.Text = "You changing dot №, to value";
            // 
            // ChangeDotInfo_label
            // 
            this.ChangeDotInfo_label.AutoSize = true;
            this.ChangeDotInfo_label.Location = new System.Drawing.Point(1117, 536);
            this.ChangeDotInfo_label.Name = "ChangeDotInfo_label";
            this.ChangeDotInfo_label.Size = new System.Drawing.Size(94, 13);
            this.ChangeDotInfo_label.TabIndex = 8;
            this.ChangeDotInfo_label.Text = "№ of point = value";
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
            this.BottomH_pnl.Size = new System.Drawing.Size(1026, 509);
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
            this.Top_Graphics_Box.Size = new System.Drawing.Size(991, 468);
            this.Top_Graphics_Box.TabIndex = 0;
            this.Top_Graphics_Box.TabStop = false;
            this.Top_Graphics_Box.Click += new System.EventHandler(this.Top_Graphics_Box_Click);
            // 
            // MenuMain_tabCon
            // 
            this.MenuMain_tabCon.Controls.Add(this.Bottom_tabP);
            this.MenuMain_tabCon.Controls.Add(this.Top_tabP);
            this.MenuMain_tabCon.Location = new System.Drawing.Point(9, 3);
            this.MenuMain_tabCon.Name = "MenuMain_tabCon";
            this.MenuMain_tabCon.SelectedIndex = 0;
            this.MenuMain_tabCon.Size = new System.Drawing.Size(1018, 522);
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
            this.Bottom_tabP.Size = new System.Drawing.Size(1010, 496);
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
            this.Top_tabP.Size = new System.Drawing.Size(1010, 496);
            this.Top_tabP.TabIndex = 1;
            this.Top_tabP.Text = "Top";
            this.Top_tabP.UseVisualStyleBackColor = true;
            // 
            // TimeSet_pnl
            // 
            this.TimeSet_pnl.Controls.Add(this.TimeSet_comBox);
            this.TimeSet_pnl.Controls.Add(this.TimeSett_butt);
            this.TimeSet_pnl.Controls.Add(this.TimeSet_tBox);
            this.TimeSet_pnl.Controls.Add(this.TimeSet_lb);
            this.TimeSet_pnl.Location = new System.Drawing.Point(1029, 481);
            this.TimeSet_pnl.Name = "TimeSet_pnl";
            this.TimeSet_pnl.Size = new System.Drawing.Size(228, 94);
            this.TimeSet_pnl.TabIndex = 10;
            // 
            // TimeSet_comBox
            // 
            this.TimeSet_comBox.FormattingEnabled = true;
            this.TimeSet_comBox.Location = new System.Drawing.Point(126, 33);
            this.TimeSet_comBox.Name = "TimeSet_comBox";
            this.TimeSet_comBox.Size = new System.Drawing.Size(38, 21);
            this.TimeSet_comBox.TabIndex = 3;
            // 
            // TimeSett_butt
            // 
            this.TimeSett_butt.Location = new System.Drawing.Point(90, 59);
            this.TimeSett_butt.Name = "TimeSett_butt";
            this.TimeSett_butt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimeSett_butt.Size = new System.Drawing.Size(75, 23);
            this.TimeSett_butt.TabIndex = 2;
            this.TimeSett_butt.Text = "Set time";
            this.TimeSett_butt.UseVisualStyleBackColor = true;
            this.TimeSett_butt.Click += new System.EventHandler(this.TimeSett_butt_Click);
            // 
            // TimeSet_tBox
            // 
            this.TimeSet_tBox.Location = new System.Drawing.Point(22, 33);
            this.TimeSet_tBox.Name = "TimeSet_tBox";
            this.TimeSet_tBox.Size = new System.Drawing.Size(98, 20);
            this.TimeSet_tBox.TabIndex = 1;
            // 
            // TimeSet_lb
            // 
            this.TimeSet_lb.AutoSize = true;
            this.TimeSet_lb.Location = new System.Drawing.Point(19, 17);
            this.TimeSet_lb.Name = "TimeSet_lb";
            this.TimeSet_lb.Size = new System.Drawing.Size(101, 13);
            this.TimeSet_lb.TabIndex = 0;
            this.TimeSet_lb.Text = "Set Time for Button:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 572);
            this.Controls.Add(this.TimeSet_pnl);
            this.Controls.Add(this.MenuMain_tabCon);
            this.Controls.Add(this.ChangeDotInfo_label);
            this.Controls.Add(this.ShowDotLabel);
            this.Controls.Add(this.DrawPoint_lb);
            this.Controls.Add(this.ShowCoordLabel);
            this.Controls.Add(this.Coord_lb);
            this.Controls.Add(this.GraphicDr_chBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Bot_Graphics_Box)).EndInit();
            this.BottomH_pnl.ResumeLayout(false);
            this.BottomH_pnl.PerformLayout();
            this.TopH_pnl.ResumeLayout(false);
            this.TopH_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Top_Graphics_Box)).EndInit();
            this.MenuMain_tabCon.ResumeLayout(false);
            this.Bottom_tabP.ResumeLayout(false);
            this.Top_tabP.ResumeLayout(false);
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
        private System.Windows.Forms.Label ShowDotLabel;
        private System.Windows.Forms.Label ChangeDotInfo_label;
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
    }
}

