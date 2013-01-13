using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MAudioDriverMonitor
{
    /// <summary>
    /// Simple logger to a log file
    /// </summary>
    class SimpleLogger : IDisposable
    {
        /// <summary>
        /// Default log filename
        /// </summary>
        internal const String DEFAULT_LOG_FILENAME = "MAudioDriverMonitor.log";

        /// <summary>
        /// Logger instance
        /// </summary>
        private static SimpleLogger instance = null;

        /// <summary>
        /// Log filename
        /// </summary>
        private String logFilename;

        /// <summary>
        /// Log file
        /// </summary>
        private TextWriter logFile;

        /// <summary>
        /// Initialized
        /// </summary>
        private bool initialized;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logFilename"></param>
        /// <returns></returns>
        internal static SimpleLogger Instance(String logFilename = null)
        {
            if (logFilename == null)
            {
                logFilename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SimpleLogger.DEFAULT_LOG_FILENAME);
            }
            if (SimpleLogger.instance == null)
            {
                SimpleLogger.instance = new SimpleLogger(logFilename);
            }
            return SimpleLogger.instance;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logFilename"></param>
        private SimpleLogger(String logFilename)
        {
            this.logFilename = logFilename;
            try
            {
                logFile = new StreamWriter(logFilename, true, Encoding.UTF8);
                initialized = true;
            }
            catch (IOException)
            {
                MessageBox.Show("Log file '" + logFilename + "' already in use !");
                initialized = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && initialized)
            {
                logFile.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Write a message to the logger followed by '\n'
        /// </summary>
        /// <param name="message">The message that will be written to the logger</param>
        internal void WriteLine(String message)
        {
            if (initialized)
            {
                logFile.WriteLine(DateTime.Now + " - " + message);
                logFile.Flush();
            }
        }

        /// <summary>
        /// Write a message to the logger
        /// </summary>
        /// <param name="message">The message that will be written to the logger</param>
        internal void Write(String message)
        {
            if (initialized)
            {
                logFile.Write(DateTime.Now + " - " + message);
                logFile.Flush();
            }
        }
    }
}
