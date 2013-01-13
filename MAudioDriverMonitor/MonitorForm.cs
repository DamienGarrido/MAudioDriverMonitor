using System;
using System.Windows.Forms;
using System.Drawing;
using System.ServiceProcess;

namespace MAudioDriverMonitor
{
    public partial class MonitorForm : Form
    {
        /// <summary>
        /// NormalFont
        /// </summary>
        private Font NormalFont;

        /// <summary>
        /// BoldFont
        /// </summary>
        private Font BoldFont;

        /// <summary>
        /// Select service
        /// </summary>
        private String selectedServiceName;

        /// <summary>
        /// IsShown
        /// </summary>
        internal bool IsShown { get; set; }

        /// <summary>
        /// MonitorForm
        /// </summary>
        internal MonitorForm()
        {
            InitializeComponent();

            // Set window & notify icon titles
            Text = Application.ProductName;
            notifyIcon.Text = Application.ProductName;

            // Initialize normal & bold fonts
            NormalFont = new Font("Segoe UI", 9);
            BoldFont = new Font("Segoe UI", 9, FontStyle.Bold);

            // Initialize label text
            lblDescription.Text = "When monitoring is enabled, '" + Application.ProductName + "' utility will automatically:" + Environment.NewLine;
            lblDescription.Text += "- Disable the registered Windows Audio Services before Suspending." + Environment.NewLine;
            lblDescription.Text += "- Enable the registered Windows Audio Services after Resuming." + Environment.NewLine;
            lblDescription.Text += "User can also manually start/stop services by:" + Environment.NewLine;
            lblDescription.Text += "- Right-clicking on below registered services." + Environment.NewLine;
            lblDescription.Text += "- Clicking on 'Start services' and 'Stop services' buttons." + Environment.NewLine;

            IsShown = true;

            // Suspend Service ListView initialization
            lsvSuspendServices.Columns.Add("Service name", 110);
            lsvSuspendServices.Columns.Add("Service status", 90);
            lsvSuspendServices.Columns.Add("Display name", 320);

            // Resume Service ListView initialization
            lsvResumeServices.Columns.Add("Service name", 110);
            lsvResumeServices.Columns.Add("Service status", 90);
            lsvResumeServices.Columns.Add("Display name", 320);
            updateServiceLists();

            startMonitoring();
        }

        private void updateServiceLists()
        {
            lsvResumeServices.Items.Clear();
            foreach (ServiceWrapper serviceInformation in PowerStateMonitor.Instance().ResumeEventRegisteredServices.Values)
            {
                ServiceWrapper newServiceInformation = new ServiceWrapper(serviceInformation.ServiceName);
                ListViewItem listViewItem = new ListViewItem(new string[] {
                    newServiceInformation.ServiceName,
                    newServiceInformation.Status.ToString(),
                    newServiceInformation.DisplayName
                });
                lsvResumeServices.Items.Add(listViewItem);
            }

            lsvSuspendServices.Items.Clear();
            foreach (ServiceWrapper serviceInformation in PowerStateMonitor.Instance().SuspendEventRegisteredServices.Values)
            {
                ServiceWrapper newServiceInformation = new ServiceWrapper(serviceInformation.ServiceName);
                ListViewItem listViewItem = new ListViewItem(new string[] {
                    newServiceInformation.ServiceName,
                    newServiceInformation.Status.ToString(),
                    newServiceInformation.DisplayName
                });
                lsvSuspendServices.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// Show Form
        /// </summary>
        internal void ShowMe()
        {
            SimpleLogger.Instance().WriteLine("MonitorForm.ShowMe: IsShown = " + IsShown);
            if (!IsShown)
            {
                itmShow.Font = NormalFont;
                itmShow.Enabled = false;

                itmHide.Font = BoldFont;
                itmHide.Enabled = true;

                IsShown = true;
                Show();
            }
        }

        /// <summary>
        /// Hide Form
        /// </summary>
        internal void HideMe()
        {
            SimpleLogger.Instance().WriteLine("MonitorForm.HideMe: IsShown = " + IsShown);

            if (IsShown)
            {
                itmHide.Font = NormalFont;
                itmHide.Enabled = false;

                itmShow.Font = BoldFont;
                itmShow.Enabled = true;

                IsShown = false;
                Hide();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SimpleLogger.Instance().WriteLine("FormClosingEvent received, CloseReason: " + e.CloseReason);
            // Do not ask confirmation if Windows is shutting down
            if ( CloseReason.WindowsShutDown != e.CloseReason )
            {
                // Ask confirmation
                DialogResult dialogResult = MessageBox.Show("You are about to quit the application.\nAudio services won't be automatically started/stopped anymore on Suspend or Resume.\nAre you sure ?", "Quit the application ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    // Cancel close
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itmShow_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked: " + sender.ToString());
            ShowMe();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itmHide_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked: " + sender.ToString());
            HideMe();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itmQuit_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked: " + sender.ToString());
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHide_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked: " + sender.ToString());
            HideMe();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked: " + sender.ToString());
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has double clicked notifyIcon: " + sender.ToString());
            if (IsShown)
            {
                HideMe();
            }
            else
            {
                ShowMe();
            }
        }

        /// <summary>
        /// Start Monitoring
        /// </summary>
        private void startMonitoring()
        {
            if (!PowerStateMonitor.Instance().MonitoringOn)
            {
                itmStartMonitoring.Enabled = false;
                itmStartMonitoring.Font = NormalFont;

                itmStopMonitoring.Enabled = true;
                itmStopMonitoring.Font = BoldFont;

                chkMonitoringStatus.Checked = true;
                chkMonitoringStatus.Text = "Monitoring is enabled";

                PowerStateMonitor.Instance().startServicesMonitoring();
            }
        }

        /// <summary>
        /// Stop Monitoring
        /// </summary>
        private void stopMonitoring()
        {
            if (PowerStateMonitor.Instance().MonitoringOn)
            {
                itmStopMonitoring.Enabled = false;
                itmStopMonitoring.Font = NormalFont;

                itmStartMonitoring.Enabled = true;
                itmStartMonitoring.Font = BoldFont;

                chkMonitoringStatus.Checked = false;
                chkMonitoringStatus.Text = "Monitoring is disabled";

                PowerStateMonitor.Instance().stopServicesMonitoring();
            }
        }

        private void itmStartMonitoring_Click(object sender, EventArgs e)
        {
            startMonitoring();
        }

        private void itmStopMonitoring_Click(object sender, EventArgs e)
        {
            stopMonitoring();
        }

        private void chkMonitoringStatus_MouseClick(object sender, MouseEventArgs e)
        {
            if (PowerStateMonitor.Instance().MonitoringOn)
            {
                stopMonitoring();
            }
            else
            {
                startMonitoring();
            }
        }

        private void btnStartServices_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine( "User has clicked the \"Start services\" button" );
            try
            {
                PowerStateMonitor.Instance().startServices();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to start services:\n" + ex.Message + "\n" + ex.InnerException.Message + "");
            } 

            updateServiceLists();
        }

        private void btnStopServices_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine( "User has clicked the \"Stop services\" button" );
            try
            {
                PowerStateMonitor.Instance().stopServices();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to stop services:\n" + ex.Message + "\n" + ex.InnerException.Message + "");
            } 
            updateServiceLists();
        }

        private void lsvSuspendServices_MouseDown(object sender, MouseEventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has right-clicked the Suspend Services ListView");
            if ((e.Button == MouseButtons.Right) && (lsvSuspendServices.GetItemAt(0, e.Y) != null))
            {
                // Retrieve Service name
                selectedServiceName = lsvSuspendServices.GetItemAt(0, e.Y).SubItems[0].Text;

                // Show context menu
                mnuService.Show(this.lsvSuspendServices, e.Location);

                if (PowerStateMonitor.Instance().SuspendEventRegisteredServices.ContainsKey(selectedServiceName))
                {
                    ServiceWrapper serviceInformation = null;
                    PowerStateMonitor.Instance().SuspendEventRegisteredServices.TryGetValue(selectedServiceName, out serviceInformation);
                    ServiceControllerStatus status = serviceInformation.Status;
                    if (status == System.ServiceProcess.ServiceControllerStatus.StopPending
                        || status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        startToolStripMenuItem.Enabled = true;
                        stopToolStripMenuItem.Enabled = false;
                    }
                    else if (status == System.ServiceProcess.ServiceControllerStatus.StartPending
                        || status == System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        startToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = true;
                    }
                }
            }
            updateServiceLists();
        }

        private void lsvResumeServices_MouseDown(object sender, MouseEventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has right-clicked the Resume Services ListView");
            if ((e.Button == MouseButtons.Right) && (lsvResumeServices.GetItemAt(0, e.Y) != null))
            {
                // Retrieve Service name
                selectedServiceName = lsvResumeServices.GetItemAt(0, e.Y).SubItems[0].Text;

                // Show context menu
                mnuService.Show(this.lsvResumeServices, e.Location);

                if (PowerStateMonitor.Instance().ResumeEventRegisteredServices.ContainsKey(selectedServiceName))
                {
                    ServiceWrapper serviceInformation = null;
                    PowerStateMonitor.Instance().ResumeEventRegisteredServices.TryGetValue(selectedServiceName, out serviceInformation);
                    ServiceControllerStatus status = serviceInformation.Status;
                    if (status == System.ServiceProcess.ServiceControllerStatus.StopPending
                        || status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        startToolStripMenuItem.Enabled = true;
                        stopToolStripMenuItem.Enabled = false;
                    }
                    else if (status == System.ServiceProcess.ServiceControllerStatus.StartPending
                        || status == System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        startToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = true;
                    }
                }
            }
            updateServiceLists();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked the \"Start\" button");
            ServiceWrapper theService = new ServiceWrapper(selectedServiceName);
            try
            {
                theService.start();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to start service '" + theService.DisplayName + "' (" + theService.ServiceName + ")\n"
                    + ex.Message + "\n" + ex.InnerException.Message + "");
            }
            updateServiceLists();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleLogger.Instance().WriteLine("User has clicked the \"Stop\" button");
            ServiceWrapper theService = new ServiceWrapper(selectedServiceName);
            try
            {
                theService.stop();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to stop service '" + theService.DisplayName + "' (" + theService.ServiceName + ")\n"
                    + ex.Message + "\n" + ex.InnerException.Message + "");
            }
            updateServiceLists();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            updateServiceLists();
        }
    }
}
