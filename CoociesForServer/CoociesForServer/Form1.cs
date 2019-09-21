using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;


namespace CoociesForServer
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int timerCounter = 0; //счётчик для таймера

        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;

            TrackedFolder_dataGV.AutoResizeColumns();
            TrackedFolder_dataGV.ColumnCount = 7;
            TrackedFolder_dataGV.AllowUserToAddRows = false;
            TrackedFolder_dataGV.AutoSizeColumnsMode =
                     DataGridViewAutoSizeColumnsMode.AllCells;

            TrackedFolder_dataGV.Columns[0].HeaderText = "Name";
            TrackedFolder_dataGV.Columns[0].Name = TrackedFolder_dataGV.Columns[0].HeaderText;
            TrackedFolder_dataGV.Columns[0].ReadOnly = true;

            TrackedFolder_dataGV.Columns[1].HeaderText = "FreeSpace, MB";
            TrackedFolder_dataGV.Columns[1].Name = TrackedFolder_dataGV.Columns[1].HeaderText;
            TrackedFolder_dataGV.Columns[1].ReadOnly = true;

            TrackedFolder_dataGV.Columns[2].HeaderText = "Folders";
            TrackedFolder_dataGV.Columns[2].Name = TrackedFolder_dataGV.Columns[2].HeaderText;
            TrackedFolder_dataGV.Columns[2].ReadOnly = true;

            TrackedFolder_dataGV.Columns[3].HeaderText = "Items";
            TrackedFolder_dataGV.Columns[3].Name = TrackedFolder_dataGV.Columns[3].HeaderText;
            TrackedFolder_dataGV.Columns[3].ReadOnly = true;

            TrackedFolder_dataGV.Columns[4].HeaderText = "OldestFile";
            TrackedFolder_dataGV.Columns[4].Name = TrackedFolder_dataGV.Columns[4].HeaderText;
            TrackedFolder_dataGV.Columns[4].ReadOnly = true;

            TrackedFolder_dataGV.Columns[5].HeaderText = "OldestFolder";
            TrackedFolder_dataGV.Columns[5].Name = TrackedFolder_dataGV.Columns[5].HeaderText;
            TrackedFolder_dataGV.Columns[5].ReadOnly = true;

            TrackedFolder_dataGV.Columns[6].HeaderText = "Path";
            TrackedFolder_dataGV.Columns[6].Name = TrackedFolder_dataGV.Columns[6].HeaderText;
            TrackedFolder_dataGV.Columns[6].ReadOnly = true;


            DataGridViewCheckBoxColumn RadioButtColDirectory = new DataGridViewCheckBoxColumn();
            RadioButtColDirectory.HeaderText = "DeletingFolder";
            RadioButtColDirectory.Name = RadioButtColDirectory.HeaderText.ToString();
            RadioButtColDirectory.TrueValue = true;
            RadioButtColDirectory.FalseValue = false;
            RadioButtColDirectory.Width = 100;
            RadioButtColDirectory.ReadOnly = false;
            TrackedFolder_dataGV.Columns.Add(RadioButtColDirectory);

            DataGridViewCheckBoxColumn RadioButtColFiles = new DataGridViewCheckBoxColumn();
            RadioButtColFiles.HeaderText = "DeletingFile";
            RadioButtColFiles.Name = RadioButtColFiles.HeaderText.ToString();
            RadioButtColFiles.TrueValue = true;
            RadioButtColFiles.FalseValue = false;
            RadioButtColFiles.Width = 100;
            RadioButtColFiles.ReadOnly = false;
            TrackedFolder_dataGV.Columns.Add(RadioButtColFiles);

        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                ProgressBar_lb.Text = "Last Update Time: " + DateTime.Now.ToString();
                CheckAvalSpace_butt.PerformClick();
                if (Convert.ToInt32(FreeSpace_tbox.Text.ToString()) > int.Parse(TrackedFolder_dataGV["FreeSpace, MB", 0].Value.ToString(), NumberStyles.AllowThousands))
                {
                    timer.Stop();
                    string Answer = SearchOldestItemRowInDataGridView();
                    if (Answer != "" && Answer != "Error")
                    {                        
                        try
                        {
                           File.Delete(Answer);                            
                        }
                        catch (Exception ex)
                        {
                            List<String> ItemsWithMistake = new List<string>();
                            ItemsWithMistake.Add(Answer);

                            DataGVFilling(ItemsWithMistake);
                            File.Delete(SearchOldestItemRowInDataGridView());
                            //  MessageBox.Show(ex.ToString());
                        }
                        try
                        {
                            Directory.Delete(Answer, true);
                        }
                        catch (Exception ex)
                        {
                            List<String> ItemsWithMistake = new List<string>();
                            ItemsWithMistake.Add(Answer);

                            DataGVFilling(ItemsWithMistake);
                            Directory.Delete(SearchOldestItemRowInDataGridView(), true);
                            //  MessageBox.Show(ex.ToString());
                        }
                        
                    }
                    timer.Start();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckAvalSpace_butt_click(object sender, EventArgs e)
        {
            DataGVFilling();
            /*
            try
            {
                for (int i = 0; i < TrackedFolder_dataGV.Rows.Count; i++)
                {
                    DriveInfo path = new DriveInfo(TrackedFolder_dataGV["Path", i].Value.ToString());
                    double Ffree = (path.AvailableFreeSpace / 1024) / 1024;
                    DirectoryInfo directory = new DirectoryInfo(TrackedFolder_dataGV["Path", i].Value.ToString());

                    TrackedFolder_dataGV["FreeSpace, MB", i].Value = Ffree.ToString("#,##");
                    TrackedFolder_dataGV["Folders", i].Value = directory.GetDirectories().Length.ToString();
                    TrackedFolder_dataGV["Items", i].Value = directory.GetFiles().Length.ToString();

                    TrackedFolder_dataGV["OldestFile", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString(), "ForFiles");

                    TrackedFolder_dataGV["OldestFolder", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString());

                    TrackedFolder_dataGV.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
        }

        //
        // Summary:
        //          Filling Data Grid View 
        private void DataGVFilling()
        {
            try
            {
                for (int i = 0; i < TrackedFolder_dataGV.Rows.Count; i++)
                {
                    DriveInfo path = new DriveInfo(TrackedFolder_dataGV["Path", i].Value.ToString());
                    double Ffree = (path.AvailableFreeSpace / 1024) / 1024;
                    DirectoryInfo directory = new DirectoryInfo(TrackedFolder_dataGV["Path", i].Value.ToString());

                    TrackedFolder_dataGV["FreeSpace, MB", i].Value = Ffree.ToString("#,##");
                    TrackedFolder_dataGV["Folders", i].Value = directory.GetDirectories().Length.ToString();
                    TrackedFolder_dataGV["Items", i].Value = directory.GetFiles().Length.ToString();

                    TrackedFolder_dataGV["OldestFile", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString(), "ForFiles");

                    TrackedFolder_dataGV["OldestFolder", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString());                    

                    TrackedFolder_dataGV.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGVFilling:" + ex.ToString());
            }
        }

        //
        // Summary:
        //          Filling Data Grid View without this items
        private void DataGVFilling(List<string> WithoutThoseItems)
        {
            try
            {
                for (int i = 0; i < TrackedFolder_dataGV.Rows.Count; i++)
                {
                    DriveInfo path = new DriveInfo(TrackedFolder_dataGV["Path", i].Value.ToString());
                    double Ffree = (path.AvailableFreeSpace / 1024) / 1024;
                    DirectoryInfo directory = new DirectoryInfo(TrackedFolder_dataGV["Path", i].Value.ToString());

                    TrackedFolder_dataGV["FreeSpace, MB", i].Value = Ffree.ToString("#,##");
                    TrackedFolder_dataGV["Folders", i].Value = directory.GetDirectories().Length.ToString();
                    TrackedFolder_dataGV["Items", i].Value = directory.GetFiles().Length.ToString();

                    TrackedFolder_dataGV["OldestFile", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString(), WithoutThoseItems, "ForFiles");

                    TrackedFolder_dataGV["OldestFolder", i].Value =
                                   GetOldestItem(TrackedFolder_dataGV["Path", i].Value.ToString(), WithoutThoseItems);

                    TrackedFolder_dataGV.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGVFilling WithoutThoseItems:  " + ex.ToString());
            }
        }

        //
        // Summary:
        //      Returns value is oldes File path
        private string GetOldestItem(string FilesPath, string ForFile = "0")
        {
            TimeSpan oldestItemTime = DateTime.Now - DateTime.Now;
            string oldestItemName = "";
            //Search oldest directory
            foreach (string file in Directory.GetFiles(FilesPath))
            {
                TimeSpan currentFileTime = DateTime.Now - File.GetLastWriteTime(file);
                if (oldestItemTime.Days < currentFileTime.Days)
                {
                    oldestItemTime = currentFileTime;
                    oldestItemName = file;
                }
            }
            return Path.GetFileName(oldestItemName);
        }

        //
        // Summary:
        //      Returns value is oldes File path without  those items
        private string GetOldestItem(string FilesPath, List<string> WithoutThoseItems, string ForFile = "0")
        {
            TimeSpan oldestItemTime = DateTime.Now - DateTime.Now;
            string oldestItemName = "";
            //Search oldest directory
            foreach (string file in Directory.GetFiles(FilesPath))
            {
                TimeSpan currentFileTime = DateTime.Now - File.GetLastWriteTime(file);                
                if ((oldestItemTime.Days < currentFileTime.Days) && WithoutThoseItems.IndexOf(file) == -1)
                {
                    oldestItemTime = currentFileTime;
                    oldestItemName = file;
                }
            }
            return Path.GetFileName(oldestItemName);
        }


        //
        // Summary:
        //      Returns value is oldes Directory path
        private string GetOldestItem(string DirectoryPath)
        {
            TimeSpan oldestItemTime = DateTime.Now - DateTime.Now;
            string oldestItemName = "";
            //Search oldest directory
            foreach (string file in Directory.GetDirectories(DirectoryPath))
            {
                TimeSpan currentFileTime = DateTime.Now - File.GetLastWriteTime(file);
                if (oldestItemTime.Days < currentFileTime.Days)
                {
                    oldestItemTime = currentFileTime;
                    oldestItemName = file;
                }
            }
            return Path.GetFileName(oldestItemName);
        }

        //
        // Summary:
        //      Returns value is oldes Directory path without  those items
        private string GetOldestItem(string DirectoryPath, List<string> WithoutThoseItems)
        {
            TimeSpan oldestItemTime = DateTime.Now - DateTime.Now;
            string oldestItemName = "";           
            //Search oldest directory
            foreach (string file in Directory.GetDirectories(DirectoryPath))
            {
                TimeSpan currentFileTime = DateTime.Now - File.GetLastWriteTime(file);
                if ((oldestItemTime.Days < currentFileTime.Days)  && !WithoutThoseItems.Contains(file))
                {
                    oldestItemTime = currentFileTime;
                    oldestItemName = file;
                }
            }
            return Path.GetFileName(oldestItemName);
        }

        private string SearchOldestItemRowInDataGridView()
        {
            try
            {
                TimeSpan oldestItemTime = DateTime.Now - DateTime.Now;
                string oldestItem = "";
                foreach (DataGridViewRow row in TrackedFolder_dataGV.Rows)
                {
                    TimeSpan currentFileTime;
                    string finalPath = "";

                    if (Convert.ToBoolean(TrackedFolder_dataGV["DeletingFolder", row.Index].Value) == true)
                    {
                        finalPath = TrackedFolder_dataGV["Path", row.Index].Value.ToString() + "\\" + TrackedFolder_dataGV["OldestFolder", row.Index].Value.ToString();
                        currentFileTime = DateTime.Now - File.GetLastWriteTime(finalPath);
                    }
                    else if (Convert.ToBoolean(TrackedFolder_dataGV["DeletingFile", row.Index].Value) == true)
                    {
                        finalPath = TrackedFolder_dataGV["Path", row.Index].Value.ToString() + "\\" + TrackedFolder_dataGV["OldestFile", row.Index].Value.ToString();
                        currentFileTime = DateTime.Now - File.GetLastWriteTime(finalPath);
                    }
                    else
                    {
                        continue;
                    }
                    if (oldestItemTime.Days < currentFileTime.Days)
                    {
                        oldestItemTime = currentFileTime;
                        oldestItem = finalPath;
                    }
                }
                return oldestItem.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SearchOldestItemRowInDataGridView:  " + ex.ToString());
            }
            return "Error";
        }


        private void AddToTrackFolLb_butt_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        TrackedFolder_dataGV.Rows.Add();
                        TrackedFolder_dataGV["Path", TrackedFolder_dataGV.Rows.Count - 1].Value = fbd.SelectedPath.ToString();
                        TrackedFolder_dataGV["Name", TrackedFolder_dataGV.Rows.Count - 1].Value = Path.GetFileName(fbd.SelectedPath);
                        TrackedFolder_dataGV.AutoResizeColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddToTrackFolLb_butt_Click: " + ex.ToString());
            }
        }

        private void Tracking_chBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Tracking_chBox.Checked)
            {
                if (TimerInter_tBox.Text != String.Empty)
                {
                    timer.Interval = Convert.ToInt32(TimerInter_tBox.Text) * 1000;
                }
                else
                {
                    timer.Interval = 1000; //интервал между срабатываниями 1000 миллисекунд
                }

                FreeSpace_tbox.ReadOnly = true;
                TimerInter_tBox.ReadOnly = true;
                TrackedFolder_dataGV.Columns["DeletingFile"].ReadOnly = true;
                TrackedFolder_dataGV.Columns["DeletingFolder"].ReadOnly = true;
                timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
                timer.Start();
            }
            else
            {
                timer.Stop();
                FreeSpace_tbox.ReadOnly = false;
                TimerInter_tBox.ReadOnly = false;
                TrackedFolder_dataGV.Columns["DeletingFile"].ReadOnly = false;
                TrackedFolder_dataGV.Columns["DeletingFolder"].ReadOnly = false;
            }
        }

        private void TimerInter_tBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SearchOldestItemRowInDataGridView());
            //MessageBox.Show(SearchOldestItemRowInDataGridView());
            // File.Delete(SearchOldestItemRowInDataGridView());
            List<String> ItemsWithMistake = new List<string>();
            ItemsWithMistake.Add("C:\\Users\\Admin\\.android\\adbkey");
            ItemsWithMistake.Add("C:\\Users\\Admin\\.android\\avd");

            DataGVFilling(ItemsWithMistake);
            MessageBox.Show(SearchOldestItemRowInDataGridView());
           // File.Delete(SearchOldestItemRowInDataGridView());
        }

        private void TrackedFolder_dataGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.TrackedFolder_dataGV.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.TrackedFolder_dataGV.Rows[index].HeaderCell.Value = indexStr;
        }

        private void ApplicationHeaderName_tBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = ApplicationHeaderName_tBox.Text;
        }

        private void FreeSpace_lb_Click(object sender, EventArgs e)
        {

        }

        private void FreeSpace_tbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void DeleteSelectedRow_butt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TrackedFolder_dataGV.SelectedRows)
            {
                TrackedFolder_dataGV.Rows.RemoveAt(row.Index);
            }
        }

        private void ProgressBar_lb_Click(object sender, EventArgs e)
        {

        }
    }
}
