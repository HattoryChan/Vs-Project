namespace CoociesForServer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckAvalSpace_butt = new System.Windows.Forms.Button();
            this.AddToTrackFolLb_butt = new System.Windows.Forms.Button();
            this.Tracking_chBox = new System.Windows.Forms.CheckBox();
            this.TimerInter_tBox = new System.Windows.Forms.TextBox();
            this.TimerInterval_lb = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Setting_tabp = new System.Windows.Forms.TabPage();
            this.Monitor_tabp = new System.Windows.Forms.TabPage();
            this.TrackedFolder_dataGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Setting_tabp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackedFolder_dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckAvalSpace_butt
            // 
            this.CheckAvalSpace_butt.Location = new System.Drawing.Point(724, 52);
            this.CheckAvalSpace_butt.Name = "CheckAvalSpace_butt";
            this.CheckAvalSpace_butt.Size = new System.Drawing.Size(141, 28);
            this.CheckAvalSpace_butt.TabIndex = 0;
            this.CheckAvalSpace_butt.Text = "Check avaliable space";
            this.CheckAvalSpace_butt.UseVisualStyleBackColor = true;
            this.CheckAvalSpace_butt.Click += new System.EventHandler(this.CheckAvalSpace_butt_click);
            // 
            // AddToTrackFolLb_butt
            // 
            this.AddToTrackFolLb_butt.Location = new System.Drawing.Point(724, 6);
            this.AddToTrackFolLb_butt.Name = "AddToTrackFolLb_butt";
            this.AddToTrackFolLb_butt.Size = new System.Drawing.Size(123, 28);
            this.AddToTrackFolLb_butt.TabIndex = 2;
            this.AddToTrackFolLb_butt.Text = "Add tracked folder";
            this.AddToTrackFolLb_butt.UseVisualStyleBackColor = true;
            this.AddToTrackFolLb_butt.Click += new System.EventHandler(this.AddToTrackFolLb_butt_Click);
            // 
            // Tracking_chBox
            // 
            this.Tracking_chBox.AutoSize = true;
            this.Tracking_chBox.Location = new System.Drawing.Point(724, 158);
            this.Tracking_chBox.Name = "Tracking_chBox";
            this.Tracking_chBox.Size = new System.Drawing.Size(68, 17);
            this.Tracking_chBox.TabIndex = 3;
            this.Tracking_chBox.Text = "Tracking";
            this.Tracking_chBox.UseVisualStyleBackColor = true;
            this.Tracking_chBox.CheckedChanged += new System.EventHandler(this.Tracking_chBox_CheckedChanged);
            // 
            // TimerInter_tBox
            // 
            this.TimerInter_tBox.Location = new System.Drawing.Point(724, 120);
            this.TimerInter_tBox.Name = "TimerInter_tBox";
            this.TimerInter_tBox.Size = new System.Drawing.Size(101, 20);
            this.TimerInter_tBox.TabIndex = 4;
            this.TimerInter_tBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimerInter_tBox_KeyPress);
            // 
            // TimerInterval_lb
            // 
            this.TimerInterval_lb.AutoSize = true;
            this.TimerInterval_lb.Location = new System.Drawing.Point(724, 101);
            this.TimerInterval_lb.Name = "TimerInterval_lb";
            this.TimerInterval_lb.Size = new System.Drawing.Size(94, 13);
            this.TimerInterval_lb.TabIndex = 5;
            this.TimerInterval_lb.Text = "Timer Interval(sec)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Setting_tabp);
            this.tabControl1.Controls.Add(this.Monitor_tabp);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1110, 539);
            this.tabControl1.TabIndex = 7;
            // 
            // Setting_tabp
            // 
            this.Setting_tabp.Controls.Add(this.button1);
            this.Setting_tabp.Controls.Add(this.TrackedFolder_dataGV);
            this.Setting_tabp.Controls.Add(this.TimerInterval_lb);
            this.Setting_tabp.Controls.Add(this.CheckAvalSpace_butt);
            this.Setting_tabp.Controls.Add(this.TimerInter_tBox);
            this.Setting_tabp.Controls.Add(this.Tracking_chBox);
            this.Setting_tabp.Controls.Add(this.AddToTrackFolLb_butt);
            this.Setting_tabp.Location = new System.Drawing.Point(4, 22);
            this.Setting_tabp.Name = "Setting_tabp";
            this.Setting_tabp.Padding = new System.Windows.Forms.Padding(3);
            this.Setting_tabp.Size = new System.Drawing.Size(1102, 513);
            this.Setting_tabp.TabIndex = 0;
            this.Setting_tabp.Text = "Setting";
            this.Setting_tabp.UseVisualStyleBackColor = true;
            // 
            // Monitor_tabp
            // 
            this.Monitor_tabp.Location = new System.Drawing.Point(4, 22);
            this.Monitor_tabp.Name = "Monitor_tabp";
            this.Monitor_tabp.Padding = new System.Windows.Forms.Padding(3);
            this.Monitor_tabp.Size = new System.Drawing.Size(676, 513);
            this.Monitor_tabp.TabIndex = 1;
            this.Monitor_tabp.Text = "Monitor";
            this.Monitor_tabp.UseVisualStyleBackColor = true;
            // 
            // TrackedFolder_dataGV
            // 
            this.TrackedFolder_dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrackedFolder_dataGV.Location = new System.Drawing.Point(6, 6);
            this.TrackedFolder_dataGV.Name = "TrackedFolder_dataGV";
            this.TrackedFolder_dataGV.Size = new System.Drawing.Size(701, 150);
            this.TrackedFolder_dataGV.TabIndex = 7;
            this.TrackedFolder_dataGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.TrackedFolder_dataGV_RowPrePaint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(814, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 54);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 563);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "653";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Setting_tabp.ResumeLayout(false);
            this.Setting_tabp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackedFolder_dataGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CheckAvalSpace_butt;
        private System.Windows.Forms.Button AddToTrackFolLb_butt;
        private System.Windows.Forms.CheckBox Tracking_chBox;
        private System.Windows.Forms.TextBox TimerInter_tBox;
        private System.Windows.Forms.Label TimerInterval_lb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Setting_tabp;
        private System.Windows.Forms.TabPage Monitor_tabp;
        private System.Windows.Forms.DataGridView TrackedFolder_dataGV;
        private System.Windows.Forms.Button button1;
    }
}

