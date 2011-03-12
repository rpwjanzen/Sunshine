using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Sunshine
{
    public sealed class LogManager : ILogManager
    {
        #region Fields

        private readonly ObservableCollection<ILog> m_logs;
        private readonly ReadOnlyObservableCollection<ILog> m_readonlyLogs;
        private readonly Log m_globalLog;

        #endregion

        #region Constructors

        public LogManager()
        {
            if (!DesignerProperties.IsInDesignTool)
                m_logs = new ObservableCollection<ILog>();
            else
            {
                Log stringLog = new Log(typeof(string), null);
                stringLog.Debug("Debug");
                stringLog.Info("Info");
                stringLog.Warn("Warn");
                stringLog.Fatal("Fatal");

                m_logs = new ObservableCollection<ILog>();
                m_logs.Add(stringLog);
            }

            m_readonlyLogs = new ReadOnlyObservableCollection<ILog>(m_logs);
            m_globalLog = new Log(typeof(Global), null);
            m_logs.Add(m_globalLog);
        }

        #endregion

        #region ILogManager Members

        public ReadOnlyObservableCollection<ILog> Logs
        {
            get { return m_readonlyLogs; }
        }

        public ILog GetLog(Type type)
        {
            ILog log = Logs.FirstOrDefault(l => l.Type == type);
            if (log == null)
            {
                log = new Log(type, m_globalLog);
                m_logs.Add(log);
            }

            return log;
        }

        #endregion

        private sealed class Global { }
    }
}
