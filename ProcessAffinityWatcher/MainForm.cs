using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace ProcessAffinityWatcher
{
    public partial class MainForm : Form
    {

        private bool waitCheckbox = false;
        private Dictionary<string, string> lastStatus = new Dictionary<string, string>();

        private CheckBox[] checkBoxes = new CheckBox[16];

        public MainForm()
        {
            InitializeComponent();

            checkBoxes[0] = chkCPU00;
            checkBoxes[1] = chkCPU01;
            checkBoxes[2] = chkCPU02;
            checkBoxes[3] = chkCPU03;
            checkBoxes[4] = chkCPU04;
            checkBoxes[5] = chkCPU05;
            checkBoxes[6] = chkCPU06;
            checkBoxes[7] = chkCPU07;
            checkBoxes[8] = chkCPU08;
            checkBoxes[9] = chkCPU09;
            checkBoxes[10] = chkCPU10;
            checkBoxes[11] = chkCPU11;
            checkBoxes[12] = chkCPU12;
            checkBoxes[13] = chkCPU13;
            checkBoxes[14] = chkCPU14;
            checkBoxes[15] = chkCPU15;

            TmrProcessCheck_Tick(null, null);
        }

        private void TmrProcessCheck_Tick(object sender, EventArgs e)
        {
            int pc = Environment.ProcessorCount;
            for(int i = 1; i < checkBoxes.Length; i++)
            {
                if(pc < (i+1)) checkBoxes[i].Enabled = false;
            }

            cmbProcessSelect.Enabled = false;
            cmbProcessSelect.Items.Clear();
            Process[] processes = Process.GetProcesses();
            List<string> processNames = new List<string>();

            foreach (Process process in processes)
            {
                if(!processNames.Contains(process.ProcessName))
                {
                    processNames.Add(process.ProcessName);
                }
            }

            processNames.Sort(new ProcessNameComparer());
            foreach (string processName in processNames)
            {
                cmbProcessSelect.Items.Add(processName);
            }
            cmbProcessSelect.Enabled = true;

            if (sender == null) lstWatchList.Items.Clear();

            Dictionary<string, int> settings = GetAffinitySettings();
            foreach(string key in settings.Keys)
            {
                if (sender == null)
                {
                    lstWatchList.Items.Add(key);
                }

                processes = Process.GetProcessesByName(key);
                if(processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        if (settings[key] <= 0) continue;
                        if (process.ProcessorAffinity.ToInt32() != settings[key])
                        {
                            process.ProcessorAffinity = new IntPtr(settings[key]);
                            SetProcessStatus(key, "Affinity set at " + DateTime.Now.ToLongTimeString());
                        } else
                        {
                            SetProcessStatus(key, "Affinity already correct", true);
                        }
                    }
                } else
                {
                    SetProcessStatus(key, "Process not found at " + DateTime.Now.ToLongTimeString());
                }
            }
        }

        private void CmbProcessSelect_Enter(object sender, EventArgs e)
        {
            tmrProcessCheck.Enabled = false;
            tmrProcessCheck.Stop();
            Debug.Print("Timer stopped");
        }

        private void CmbProcessSelect_Leave(object sender, EventArgs e)
        {
            tmrProcessCheck.Enabled = true;
            tmrProcessCheck.Start();
            Debug.Print("Timer started");
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            string value = cmbProcessSelect.Text;
            if(value != null && value != "")
            {
                if (!lstWatchList.Items.Contains(value))
                {
                    lstWatchList.Items.Add(value);
                    Dictionary<string, int> settings = GetAffinitySettings();
                    int startAffinity = (int)Math.Pow(2, Environment.ProcessorCount) - 1;
                    Process[] process = Process.GetProcessesByName(value);
                    if (process.Length > 0)
                    {
                        startAffinity = process[0].ProcessorAffinity.ToInt32();
                    }
                    settings.Add(value, startAffinity);
                    SaveAffinitySettings(settings);
                }
                lstWatchList.SelectedIndex = lstWatchList.Items.Count-1;
            }
        }

        private void lstWatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWatchList.SelectedIndex < 0) return;

            string processSelected = lstWatchList.Items[lstWatchList.SelectedIndex].ToString();
            lblProcessName.Text = "Set affinity for " + processSelected + ":";

            if(lastStatus.ContainsKey(processSelected))
            {
                lblProcessStatus.Text = lastStatus[processSelected];
            } else
            {
                lblProcessStatus.Text = "---";
            }

            Dictionary<string, int> settings = GetAffinitySettings();
            int cpuMask = settings[processSelected];

            for(int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Checked = ((cpuMask & (1 << i)) != 0);
            }

            chkCPUAll.Checked = (cpuMask == (Math.Pow(2, Environment.ProcessorCount) - 1));
        }

        private void ChkCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (waitCheckbox) return;
            this.waitCheckbox = true;
            if(
                (chkCPU00.Checked || !chkCPU00.Enabled) &&
                (chkCPU01.Checked || !chkCPU01.Enabled) &&
                (chkCPU02.Checked || !chkCPU02.Enabled) &&
                (chkCPU03.Checked || !chkCPU03.Enabled) &&
                (chkCPU04.Checked || !chkCPU04.Enabled) &&
                (chkCPU05.Checked || !chkCPU05.Enabled) &&
                (chkCPU06.Checked || !chkCPU06.Enabled) &&
                (chkCPU07.Checked || !chkCPU07.Enabled) &&
                (chkCPU08.Checked || !chkCPU08.Enabled) &&
                (chkCPU09.Checked || !chkCPU09.Enabled) &&
                (chkCPU10.Checked || !chkCPU10.Enabled) &&
                (chkCPU11.Checked || !chkCPU11.Enabled) &&
                (chkCPU12.Checked || !chkCPU12.Enabled) &&
                (chkCPU13.Checked || !chkCPU13.Enabled) &&
                (chkCPU14.Checked || !chkCPU14.Enabled) &&
                (chkCPU15.Checked || !chkCPU15.Enabled)
            )
            {
                chkCPUAll.Checked = true;
            } else
            {
                chkCPUAll.Checked = false;
            }
            this.waitCheckbox = false;
        }

        private Dictionary<string, int> GetAffinitySettings()
        {

            Dictionary<string, int> settings = new Dictionary<string, int>();

            try
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string specificFolder = Path.Combine(folder, "ProcessAffinityWatcher");
                string filePath = Path.Combine(specificFolder, "settings.config");
                StreamReader sr = new StreamReader(filePath);

                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] processAffinity = line.Split(new char[1] { ':' }, 2);
                    if (processAffinity.Length == 2)
                    {
                        try
                        {
                            settings.Add(processAffinity[0], int.Parse(processAffinity[1]));
                        }
                        catch { }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            } catch { }

            return settings;
        }

        private void SaveAffinitySettings(Dictionary<string, int> settings)
        {
            try
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string specificFolder = Path.Combine(folder, "ProcessAffinityWatcher");
                Directory.CreateDirectory(specificFolder);

                StreamWriter sw = new StreamWriter(Path.Combine(specificFolder, "settings.config"));
                foreach (string key in settings.Keys)
                {
                    sw.WriteLine(key + ":" + settings[key].ToString());
                }

                sw.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to save settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetProcessStatus(string processName, string status, bool onlyifempty = false)
        {
            if (lastStatus.ContainsKey(processName))
            {
                if (onlyifempty) return;
                lastStatus[processName] = status;
            }
            else
            {
                lastStatus.Add(processName, status);
            }

            if (lstWatchList.SelectedIndex < 0) return;
            string processSelected = lstWatchList.Items[lstWatchList.SelectedIndex].ToString();

            if(processSelected == processName)
            {
                lblProcessStatus.Text = status;
            }
        }

        private void chkCPUAll_CheckedChanged(object sender, EventArgs e)
        {
            if (waitCheckbox) return;
            this.waitCheckbox = true;
            chkCPU00.Checked = chkCPU00.Enabled && chkCPUAll.Checked;
            chkCPU01.Checked = chkCPU01.Enabled && chkCPUAll.Checked;
            chkCPU02.Checked = chkCPU02.Enabled && chkCPUAll.Checked;
            chkCPU03.Checked = chkCPU03.Enabled && chkCPUAll.Checked;
            chkCPU04.Checked = chkCPU04.Enabled && chkCPUAll.Checked;
            chkCPU05.Checked = chkCPU05.Enabled && chkCPUAll.Checked;
            chkCPU06.Checked = chkCPU06.Enabled && chkCPUAll.Checked;
            chkCPU07.Checked = chkCPU07.Enabled && chkCPUAll.Checked;
            chkCPU08.Checked = chkCPU08.Enabled && chkCPUAll.Checked;
            chkCPU09.Checked = chkCPU09.Enabled && chkCPUAll.Checked;
            chkCPU10.Checked = chkCPU10.Enabled && chkCPUAll.Checked;
            chkCPU11.Checked = chkCPU11.Enabled && chkCPUAll.Checked;
            chkCPU12.Checked = chkCPU12.Enabled && chkCPUAll.Checked;
            chkCPU13.Checked = chkCPU13.Enabled && chkCPUAll.Checked;
            chkCPU14.Checked = chkCPU14.Enabled && chkCPUAll.Checked;
            chkCPU15.Checked = chkCPU15.Enabled && chkCPUAll.Checked;
            this.waitCheckbox = false;
        }

        private void btnSaveAffinity_Click(object sender, EventArgs e)
        {
            if (lstWatchList.SelectedIndex < 0) return;
            string processSelected = lstWatchList.Items[lstWatchList.SelectedIndex].ToString();

            int affinityMask = 0;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked && checkBoxes[i].Enabled) affinityMask |= (1 << i);
            }

            if(affinityMask <= 0)
            {
                checkBoxes[0].Checked = true;
                affinityMask = 1;
            }

            Dictionary<string, int> settings = GetAffinitySettings();
            settings[processSelected] = affinityMask;
            SaveAffinitySettings(settings);

            Process[] processes = Process.GetProcessesByName(processSelected);
            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    process.ProcessorAffinity = new IntPtr(affinityMask);
                }
                SetProcessStatus(processSelected, "Affinity set at " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                SetProcessStatus(processSelected, "Process not found at " + DateTime.Now.ToLongTimeString());
            }
        }

        private void btnRemoveProcess_Click(object sender, EventArgs e)
        {
            if (lstWatchList.SelectedIndex < 0) return;
            string processSelected = lstWatchList.Items[lstWatchList.SelectedIndex].ToString();

            Dictionary<string, int> settings = GetAffinitySettings();
            settings.Remove(processSelected);
            SaveAffinitySettings(settings);

            lstWatchList.Items.RemoveAt(lstWatchList.SelectedIndex);

            if(lstWatchList.Items.Count > 0)
            {
                lstWatchList.SelectedIndex = 0;
            } else
            {
                lstWatchList.SelectedIndex = -1;
            }
        }

        private void trayMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                trayMain.Visible = true;
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Pakl (pakl.dev) under the MIT license.\n\nThe MIT License (MIT)\n\nCopyright(c) 2022 Pascal Pohl\n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and / or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class ProcessNameComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return new CaseInsensitiveComparer().Compare(a, b);
        }
    }
}
