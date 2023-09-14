using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SP_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listViewProcesses.SelectedIndexChanged += listViewProcesses_SelectedIndexChanged;

            listViewProcesses.Columns.Add("Process Name", 200);
            listViewProcesses.Columns.Add("Process ID", 70);
            listViewProcesses.Columns.Add("Process Owner", 150);
            listViewProcesses.Columns.Add("Working Set", 80);
            listViewProcesses.Columns.Add("Base Priority", 70);
            listViewProcesses.Columns.Add("Thread Count", 80);

            listViewThreads.Columns.Add("Thread ID");
            listViewThreads.Columns.Add("Base Priority", 70);
        }

        private void UpdateProcessList()
        {
            listViewProcesses.Items.Clear();

            Process[] processes = Process.GetProcesses();

            Parallel.ForEach(processes, (process) =>
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(GetProcessOwner(process.Id));
                item.SubItems.Add((process.WorkingSet64 / (1024 * 1024)).ToString("N2") + " MB");
                item.SubItems.Add(process.BasePriority.ToString());
                item.SubItems.Add(process.Threads.Count.ToString());

                listViewProcesses.Items.Add(item);
            });

            /*foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(GetProcessOwner(process.Id));
                item.SubItems.Add((process.WorkingSet64 / (1024 * 1024)).ToString("N2") + " MB");
                item.SubItems.Add(process.BasePriority.ToString());
                item.SubItems.Add(process.Threads.Count.ToString());

                listViewProcesses.Items.Add(item);
            }*/

            label1.Text = "Total Processes: " + processes.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void listViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count > 0)
            {
                int selectedProcessId = int.Parse(listViewProcesses.SelectedItems[0].SubItems[1].Text);
                ShowProcessThreads(selectedProcessId);
            }
        }

        private void ShowProcessThreads(int processId)
        {
            listViewThreads.Items.Clear();

            Process process = Process.GetProcessById(processId);
            ProcessThreadCollection threads = process.Threads;

            foreach (ProcessThread thread in threads)
            {
                ListViewItem item = new ListViewItem(thread.Id.ToString());
                item.SubItems.Add(thread.Id.ToString());
                item.SubItems.Add(thread.BasePriority.ToString());

                listViewThreads.Items.Add(item);
            }
        }

        private string GetProcessOwner(int processID)
        {
            string processOwner = "Unknown owner";

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"Select * From Win32_Process Where ProcessId = {processID}"))
                using (ManagementObjectCollection processList = searcher.Get())
                {
                    foreach (ManagementObject mo in processList)
                    {
                        string[] ownerInfo = new string[2];
                        mo.InvokeMethod("GetOwner", (object[])ownerInfo);
                        processOwner = $"{ownerInfo[0]}\\{ownerInfo[1]}";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return processOwner;
        }
    }
}
