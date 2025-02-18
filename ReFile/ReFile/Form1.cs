using System;
using System.Diagnostics;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReFile
{
    public partial class GUI : Form
    {
        private ResourceManager ResourceManager;
        private string DirectoryPath = string.Empty;
        private List<string> Paths = new List<string>();

        public GUI()
        {
            InitializeComponent();
            this.ResourceManager = new ResourceManager("ReFile.Resources.Resources", typeof(GUI).Assembly);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.t_Timer.Start();
            this.t_Timer_Tick(this, EventArgs.Empty);
            this.SetTextForAllControls(this);
            this.tsmi_Details.PerformClick();
        }

        private void tsmi_Folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;

                switch (fbd.ShowDialog())
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            this.DirectoryPath = fbd.SelectedPath;
                        }
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.TryAgain:
                        break;
                    case DialogResult.Continue:
                        break;
                    default:
                        break;
                }
            }

            if (this.DirectoryPath != string.Empty)
            {
                this.lbl_Directory.Text = this.GetStringFromResource(this.lbl_Directory.Name, this.lbl_Directory.Text) + " " + this.DirectoryPath;
                this.Paths.AddRange(Directory.GetFiles(this.DirectoryPath));
                this.lbl_FileCount.Text = this.GetStringFromResource(this.lbl_FileCount.Name, this.lbl_FileCount.Text) + " " + this.Paths.Count;
                this.pb_Progress.Minimum = 0;
                this.pb_Progress.Maximum = this.Paths.Count;
                this.pb_Progress.Step = 1;
            }
        }

        private string GetStringFromResource(string name, string replacement = "")
        {
            string result = string.Empty;

            try
            {
                result = this.ResourceManager.GetString(name);

                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    result = replacement;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fehler beim Laden der Ressource: {ex.Message}");
                result = replacement;
            }

            return result;
        }

        private void SetTextForAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Wenn das Control die Text-Eigenschaft hat, versuche den Text zu setzen
                if (control is TextBox || control is Label || control is Button || control is ToolStripStatusLabel)
                {
                    string resourceKey = control.Name; // Verwende den Namen des Controls als Schlüssel für die Ressource

                    // Hole den Text aus den Ressourcen (mit einem Fallback-Wert)
                    string text = this.GetStringFromResource(resourceKey, control.Text);

                    // Setze den Text
                    control.Text = text;
                }

                // Rekursive Durchlauf von untergeordneten Controls, falls es sich um ein Container-Control handelt
                if (control.HasChildren)
                {
                    SetTextForAllControls(control);
                }
            }
        }

        private void t_Timer_Tick(object sender, EventArgs e)
        {
            this.tssl_Time.Text = DateTime.Now.ToString("HH:mm");
        }

        private void tsmi_Details_Click(object sender, EventArgs e)
        {
            if (this.tsmi_Details.Checked)
            {
                this.tb_Log.Visible = true;
                this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + this.tb_Log.Height);
            }
            else
            {
                this.tb_Log.Visible = false;
                this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height - this.tb_Log.Height);
            }
        }

        private async Task StartRenaming()
        {
            foreach (string path in this.Paths)
            {
                try
                {
                    DateTime createDate = File.GetCreationTime(path);
                    string newFileName = createDate.ToString("yyyyMMdd_HHmmss");
                    string directory = Path.GetDirectoryName(path);
                    if (string.IsNullOrWhiteSpace(directory))
                    {
                        throw new Exception("Bei der Konvertierung ist ein Fehler aufgetreten");
                    }
                    string extension = Path.GetExtension(path);
                    string newPath = Path.Combine(directory, newFileName + extension);

                    int counter = 1;
                    string originalNewPath = newPath;
                    while (File.Exists(newPath))
                    {
                        newPath = Path.Combine(directory, $"{newFileName}_{counter}{extension}");
                        counter++;
                    }

                    await Task.Run(() => File.Move(path, newPath));

                    this.Invoke(new Action(() => AddLog($"Umbenannt: {newPath}")));

                    this.Invoke(new Action(() =>
                    {
                        pb_Progress.PerformStep();
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => AddLog($"Fehler: {ex.Message}")));
                }
            }
        }

        private void AddLog(string log)
        {
            if (this.tb_Log.Visible)
            {
                this.tb_Log.Text += log;
                this.tb_Log.Text += Environment.NewLine;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.DirectoryPath))
            {
                this.tsmi_Folder.PerformClick();
            }
            this.StartRenaming();
        }

        private void tsmi_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ReFile v1.0\nCreated by Jonas Wolf", "About", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}