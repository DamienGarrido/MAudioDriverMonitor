using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace MAudioDriverMonitor
{
    /// <summary>
    /// PowerStateMonitor wait for PowerModeChanged events and starts or stops registered services
    /// </summary>
    class PowerStateMonitor
    {
        /// <summary>
        /// PowerStateMonitor instance
        /// </summary>
        private static PowerStateMonitor instance = null;

        /// <summary>
        /// PowerStateMonitor accessor
        /// </summary>
        /// <returns></returns>
        internal static PowerStateMonitor Instance()
        {
            if (PowerStateMonitor.instance == null)
            {
                PowerStateMonitor.instance = new PowerStateMonitor();
            }
            return PowerStateMonitor.instance;
        }

        /// <summary>
        /// List of services that will be stopped on Suspend event
        /// </summary>
        internal Dictionary<String, ServiceWrapper> SuspendEventRegisteredServices = new Dictionary<String, ServiceWrapper>();

        /// <summary>
        /// List of services that will be started on Resume event
        /// </summary>
        internal Dictionary<String, ServiceWrapper> ResumeEventRegisteredServices = new Dictionary<String, ServiceWrapper>();

        /// <summary>
        /// Monitoring activation
        /// </summary>
        internal bool MonitoringOn;

        /// <summary>
        /// Register a new service to be started or stopped upon system resume or suspend event
        /// </summary>
        /// <param name="serviceName"></param>
        internal void registerSuspendEvent(String serviceName)
        {
            ServiceWrapper serviceInformation = new ServiceWrapper(serviceName);
            SuspendEventRegisteredServices.Add(serviceName, serviceInformation);
            SimpleLogger.Instance().WriteLine("New service registered for Suspend events: " + serviceInformation.ToString());
        }

        /// <summary>
        /// Register a new service to be started or stopped upon system resume or suspend event
        /// </summary>
        /// <param name="serviceName"></param>
        internal void registerResumeEvent(String serviceName)
        {
            ServiceWrapper serviceInformation = new ServiceWrapper(serviceName);
            ResumeEventRegisteredServices.Add(serviceName, serviceInformation);
            SimpleLogger.Instance().WriteLine("New service registered for Resume events: " + serviceInformation.ToString());
        }

        /// <summary>
        /// Unregister a service from Suspend event monitoring
        /// </summary>
        /// <param name="serviceName"></param>
        internal void unregisterSuspendEvent(String serviceName)
        {
            SuspendEventRegisteredServices.Remove(serviceName);
        }

        /// <summary>
        /// Unregister a service from Resume event monitoring
        /// </summary>
        /// <param name="serviceName"></param>
        internal void unregisterResumeEvent(String serviceName)
        {
            ResumeEventRegisteredServices.Remove(serviceName);
        }

        /// <summary>
        /// PowerModeChanged handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="event">PowerModeChanged event</param>
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs powerModeChangedEvent)
        {
            switch (powerModeChangedEvent.Mode)
            {
                case PowerModes.Suspend:
                    onSuspend();
                    break;
                case PowerModes.Resume:
                    onResume();
                    break;
                case PowerModes.StatusChange:
                    onStatusChanged();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Stop services on Suspend
        /// </summary>
        private void onSuspend()
        {
            SimpleLogger.Instance().WriteLine("PowerModes.Suspend event triggered !");
            if (MonitoringOn)
            {
                try
                {
                    stopServices();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Unable to stop services:\n" + ex.Message + "\n" + ex.InnerException.Message + "");
                }
            }
        }

        /// <summary>
        /// Restart services on Resume
        /// </summary>
        private void onResume()
        {
            SimpleLogger.Instance().WriteLine("PowerModes.Resume event triggered !");
            if (MonitoringOn)
            {
                try
                {
                    startServices();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Unable to start services:\n" + ex.Message + "\n" + ex.InnerException.Message + "");
                }
            }
        }

        /// <summary>
        /// onStatusChanged
        /// </summary>
        private void onStatusChanged()
        {
            SimpleLogger.Instance().WriteLine("PowerModes.StatusChanged event triggered !");
        }

        /// <summary>
        /// Register PowerModeChanged handler
        /// </summary>
        internal void registerHandler()
        {
            SimpleLogger.Instance().WriteLine("Registering PowerModeChanged event handler");
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal PowerStateMonitor()
        {
            SimpleLogger.Instance().WriteLine("Starting PowerStateMonitor");
            registerHandler();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~PowerStateMonitor()
        {
            SimpleLogger.Instance().WriteLine("Stopping PowerStateMonitor");
        }

        /// <summary>
        /// 
        /// </summary>
        internal void startServicesMonitoring()
        {
            MonitoringOn = true;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void stopServicesMonitoring()
        {
            MonitoringOn = false;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void startServices()
        {
            SimpleLogger.Instance().WriteLine("Starting " + ResumeEventRegisteredServices.Count + " services");
            foreach (ServiceWrapper serviceInformation in ResumeEventRegisteredServices.Values)
            {
                serviceInformation.start();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void stopServices()
        {
            SimpleLogger.Instance().WriteLine("Stopping " + ResumeEventRegisteredServices.Count + " services");
            foreach (ServiceWrapper serviceInformation in SuspendEventRegisteredServices.Values)
            {
                serviceInformation.stop();
            }
        }
    }
}
