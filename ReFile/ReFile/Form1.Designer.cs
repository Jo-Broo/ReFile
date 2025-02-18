namespace ReFile
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            ss_StatusStrip = new StatusStrip();
            tssl_Time = new ToolStripStatusLabel();
            ms_MenuStrip = new MenuStrip();
            tsmi_File = new ToolStripMenuItem();
            tsmi_Folder = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            tsmi_Settings = new ToolStripMenuItem();
            tsmi_Details = new ToolStripMenuItem();
            tsmi_Info = new ToolStripMenuItem();
            t_Timer = new System.Windows.Forms.Timer(components);
            lbl_Directory = new Label();
            lbl_FileCount = new Label();
            pb_Progress = new ProgressBar();
            btn_Start = new Button();
            tb_Log = new TextBox();
            ss_StatusStrip.SuspendLayout();
            ms_MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ss_StatusStrip
            // 
            resources.ApplyResources(ss_StatusStrip, "ss_StatusStrip");
            ss_StatusStrip.BackColor = Color.DarkGray;
            ss_StatusStrip.Items.AddRange(new ToolStripItem[] { tssl_Time });
            ss_StatusStrip.Name = "ss_StatusStrip";
            ss_StatusStrip.SizingGrip = false;
            // 
            // tssl_Time
            // 
            resources.ApplyResources(tssl_Time, "tssl_Time");
            tssl_Time.Name = "tssl_Time";
            // 
            // ms_MenuStrip
            // 
            resources.ApplyResources(ms_MenuStrip, "ms_MenuStrip");
            ms_MenuStrip.BackColor = Color.DarkGray;
            ms_MenuStrip.Items.AddRange(new ToolStripItem[] { tsmi_File, tsmi_Settings });
            ms_MenuStrip.Name = "ms_MenuStrip";
            // 
            // tsmi_File
            // 
            resources.ApplyResources(tsmi_File, "tsmi_File");
            tsmi_File.DropDownItems.AddRange(new ToolStripItem[] { tsmi_Folder, exitToolStripMenuItem });
            tsmi_File.Name = "tsmi_File";
            // 
            // tsmi_Folder
            // 
            resources.ApplyResources(tsmi_Folder, "tsmi_Folder");
            tsmi_Folder.Name = "tsmi_Folder";
            tsmi_Folder.Click += tsmi_Folder_Click;
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // tsmi_Settings
            // 
            resources.ApplyResources(tsmi_Settings, "tsmi_Settings");
            tsmi_Settings.DropDownItems.AddRange(new ToolStripItem[] { tsmi_Details, tsmi_Info });
            tsmi_Settings.Name = "tsmi_Settings";
            // 
            // tsmi_Details
            // 
            resources.ApplyResources(tsmi_Details, "tsmi_Details");
            tsmi_Details.Checked = true;
            tsmi_Details.CheckOnClick = true;
            tsmi_Details.CheckState = CheckState.Checked;
            tsmi_Details.Name = "tsmi_Details";
            tsmi_Details.Click += tsmi_Details_Click;
            // 
            // tsmi_Info
            // 
            resources.ApplyResources(tsmi_Info, "tsmi_Info");
            tsmi_Info.Name = "tsmi_Info";
            tsmi_Info.Click += tsmi_Info_Click;
            // 
            // t_Timer
            // 
            t_Timer.Interval = 60000;
            t_Timer.Tick += t_Timer_Tick;
            // 
            // lbl_Directory
            // 
            resources.ApplyResources(lbl_Directory, "lbl_Directory");
            lbl_Directory.Name = "lbl_Directory";
            // 
            // lbl_FileCount
            // 
            resources.ApplyResources(lbl_FileCount, "lbl_FileCount");
            lbl_FileCount.Name = "lbl_FileCount";
            // 
            // pb_Progress
            // 
            resources.ApplyResources(pb_Progress, "pb_Progress");
            pb_Progress.Name = "pb_Progress";
            // 
            // btn_Start
            // 
            resources.ApplyResources(btn_Start, "btn_Start");
            btn_Start.Name = "btn_Start";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // tb_Log
            // 
            resources.ApplyResources(tb_Log, "tb_Log");
            tb_Log.Name = "tb_Log";
            tb_Log.ReadOnly = true;
            // 
            // GUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            Controls.Add(tb_Log);
            Controls.Add(btn_Start);
            Controls.Add(pb_Progress);
            Controls.Add(lbl_FileCount);
            Controls.Add(lbl_Directory);
            Controls.Add(ss_StatusStrip);
            Controls.Add(ms_MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = ms_MenuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GUI";
            ss_StatusStrip.ResumeLayout(false);
            ss_StatusStrip.PerformLayout();
            ms_MenuStrip.ResumeLayout(false);
            ms_MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip ss_StatusStrip;
        private MenuStrip ms_MenuStrip;
        private ToolStripMenuItem tsmi_File;
        private ToolStripMenuItem tsmi_Folder;
        private ToolStripStatusLabel tssl_Time;
        private ToolStripMenuItem tsmi_Settings;
        private System.Windows.Forms.Timer t_Timer;
        private Label lbl_Directory;
        private Label lbl_FileCount;
        private ProgressBar pb_Progress;
        private Button btn_Start;
        private ToolStripMenuItem tsmi_Details;
        private TextBox tb_Log;
        private ToolStripMenuItem tsmi_Info;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
