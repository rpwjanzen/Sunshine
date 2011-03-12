using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Sunshine
{
    // Based on http://stackoverflow.com/questions/228723/silverlight-logging-framework-and-or-best-practices
    // Heavily modified.
    /// <summary>
    /// A lightweight client side logging class for Silverlight.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Entries = {EntriesCount}")]
    public sealed class Log : ILog
    {
        #region Fields

        private readonly ObservableCollection<LogEntry> m_entries;

        #endregion

        #region Properties

        private readonly ReadOnlyObservableCollection<LogEntry> m_readonlyLogEntries;
        private readonly string m_name;
        private readonly Log m_globalLog;
        private readonly Type m_type;
        #endregion

        #region Constructors

        public Log(Type logType, Log globalLog)
        {
            m_entries = new ObservableCollection<LogEntry>();
            m_readonlyLogEntries = new ReadOnlyObservableCollection<LogEntry>(m_entries);
            m_type = logType;
            m_name = Type.Name.ToWords();

            m_globalLog = globalLog;
        }

        #endregion

        #region Debug Properties
        
        public int EntriesCount
        {
            get { return m_entries.Count; }
        }

        #endregion

        #region ILog Members

        public Type Type { get { return m_type; } }

        public ReadOnlyObservableCollection<LogEntry> Entries
        {
            get { return m_readonlyLogEntries; }
        }
        
        public string Name
        {
            get { return m_name; }
        }
        
        public void Clear()
        {
            m_entries.Clear();
        }

        public void Debug(string format, params object[] args)
        {
            WriteLine(LoggingLevel.Debug, format, args);
        }

        public void Info(string format, params object[] args)
        {
            WriteLine(LoggingLevel.Info, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            WriteLine(LoggingLevel.Warn, format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            WriteLine(LoggingLevel.Fatal, format, args);
        }

        public void WriteLine(LoggingLevel level, string format, params object[] args)
        {
            string message = string.Format(format, args);
            LogEntry entry = new LogEntry(level, message);
            m_entries.Add(entry);

            if (m_globalLog != null)
                m_globalLog.m_entries.Add(entry);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
