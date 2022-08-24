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

namespace ProcessAffinityWatcher
{
    public partial class MainForm : Form
    {

        private bool waitCheckbox = false;
        private Dictionary<string, string> lastStatus = new Dictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void TmrProcessCheck_Tick(object sender, EventArgs e)
        {
            int pc = Environment.ProcessorCount;
            if (pc < 16) chkCPU15.Enabled = false;
            if (pc < 15) chkCPU14.Enabled = false;
            if (pc < 14) chkCPU13.Enabled = false;
            if (pc < 13) chkCPU12.Enabled = false;
            if (pc < 12) chkCPU11.Enabled = false;
            if (pc < 11) chkCPU10.Enabled = false;
            if (pc < 10) chkCPU09.Enabled = false;
            if (pc < 9) chkCPU08.Enabled = false;
            if (pc < 8) chkCPU07.Enabled = false;
            if (pc < 7) chkCPU06.Enabled = false;
            if (pc < 6) chkCPU05.Enabled = false;
            if (pc < 5) chkCPU04.Enabled = false;
            if (pc < 4) chkCPU03.Enabled = false;
            if (pc < 3) chkCPU02.Enabled = false;
            if (pc < 2) chkCPU01.Enabled = false;

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

            if ((cpuMask & 32768) != 0) chkCPU15.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 16384) != 0) chkCPU14.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 8192) != 0) chkCPU13.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 4096) != 0) chkCPU12.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 2048) != 0) chkCPU11.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 1024) != 0) chkCPU10.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 512) != 0) chkCPU09.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 256) != 0) chkCPU08.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 128) != 0) chkCPU07.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 64) != 0) chkCPU06.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 32) != 0) chkCPU05.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 16) != 0) chkCPU04.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 8) != 0) chkCPU03.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 4) != 0) chkCPU02.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 2) != 0) chkCPU01.Checked = true; else chkCPU15.Checked = false;
            if ((cpuMask & 1) != 0) chkCPU00.Checked = true; else chkCPU15.Checked = false;

            if(cpuMask == (Math.Pow(2, Environment.ProcessorCount)-1))
            {
                chkCPUAll.Checked = true;
            } else
            {
                chkCPUAll.Checked = false;
            }
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
            Debug.WriteLine("Settings loaded: " + Properties.Settings.Default.AffinitySettings);

            Dictionary<string, int> settings = new Dictionary<string, int>();
            string s = Properties.Settings.Default.AffinitySettings;
            if(s != null && s.Length > 0)
            {
                string[] parts = s.Split('\\');
                foreach (string p in parts)
                {
                    string[] processAffinity = p.Split(new char[1] { ':' }, 2);
                    if(processAffinity.Length == 2)
                    {
                        try
                        {
                            settings.Add(processAffinity[0], int.Parse(processAffinity[1]));
                        } catch {}
                    }
                }
            }

            return settings;
        }

        private void SaveAffinitySettings(Dictionary<string, int> settings)
        {
            string[] parts = new string[settings.Count];
            int i = 0;
            foreach(string key in settings.Keys)
            {
                parts[i] = key + ":" + settings[key].ToString();
                i++;
            }

            Properties.Settings.Default.AffinitySettings = String.Join("\\", parts);
            Properties.Settings.Default.Save();
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
            if (chkCPU00.Checked && chkCPU00.Enabled) affinityMask |= 1;
            if (chkCPU01.Checked && chkCPU01.Enabled) affinityMask |= 2;
            if (chkCPU02.Checked && chkCPU02.Enabled) affinityMask |= 4;
            if (chkCPU03.Checked && chkCPU03.Enabled) affinityMask |= 8;
            if (chkCPU04.Checked && chkCPU04.Enabled) affinityMask |= 16;
            if (chkCPU05.Checked && chkCPU05.Enabled) affinityMask |= 32;
            if (chkCPU06.Checked && chkCPU06.Enabled) affinityMask |= 64;
            if (chkCPU07.Checked && chkCPU07.Enabled) affinityMask |= 128;
            if (chkCPU08.Checked && chkCPU08.Enabled) affinityMask |= 256;
            if (chkCPU09.Checked && chkCPU09.Enabled) affinityMask |= 512;
            if (chkCPU10.Checked && chkCPU10.Enabled) affinityMask |= 1024;
            if (chkCPU11.Checked && chkCPU11.Enabled) affinityMask |= 2048;
            if (chkCPU12.Checked && chkCPU12.Enabled) affinityMask |= 4096;
            if (chkCPU13.Checked && chkCPU13.Enabled) affinityMask |= 8192;
            if (chkCPU14.Checked && chkCPU14.Enabled) affinityMask |= 16384;
            if (chkCPU15.Checked && chkCPU15.Enabled) affinityMask |= 32768;

            if(affinityMask > 0)
            {
                Dictionary<string, int> settings = GetAffinitySettings();
                settings[processSelected] = affinityMask;
                SaveAffinitySettings(settings);

                Process[] processes = Process.GetProcessesByName(processSelected);
                if(processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.ProcessorAffinity = new IntPtr(affinityMask);
                    }
                    SetProcessStatus(processSelected, "Affinity set at " + DateTime.Now.ToLongTimeString());
                } else
                {
                    SetProcessStatus(processSelected, "Process not found at " + DateTime.Now.ToLongTimeString());
                }
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
