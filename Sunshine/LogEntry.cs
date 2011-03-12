using System;
using System.Diagnostics;

namespace Sunshine
{
    [DebuggerDisplay("Message = {Message}, Level = {Level}, Date={Date}")]
    public sealed class LogEntry
    {
        #region Properties

        private readonly LoggingLevel m_level;
        public LoggingLevel Level { get { return m_level; } }
        
        private readonly string m_message;
        public string Message { get { return m_message; } }

        private readonly DateTime m_date;
        public DateTime Date { get { return m_date; } }

        #endregion

        #region Constructors

        public LogEntry(LoggingLevel level, string message)
        {
            m_level = level;
            m_message = message;
            m_date = DateTime.Now;
        }

        #endregion
    }
}
