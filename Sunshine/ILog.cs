using System;

namespace Sunshine
{
    /// <summary>
    /// Defines a lightweight client side logging class for Silverlight.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Gets a readonly collection of the log entries.
        /// </summary>
        ReadOnlyObservableCollection<LogEntry> Entries { get; }
        
        /// <summary>
        /// Gets the log's type.
        /// </summary>
        Type Type { get; }
        
        /// <summary>
        /// Get the name of the log.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Clears the log entries.
        /// </summary>
        void Clear();

        void Debug(string format, params object[] args);
        
        /// <summary>
        /// Writes information (not errors) to the log file.
        /// </summary>
        /// <param name="format">A format string</param>
        /// <param name="args">Any arguments for the format string.</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Writes a warning (non critical error) to the log file
        /// </summary>
        /// <param name="format">A format string</param>
        /// <param name="args">Any arguments for the format string.</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Writes a critical or fatal error to the log file.
        /// </summary>
        /// <param name="format">A format string</param>
        /// <param name="args">Any arguments for the format string.</param>
        void Fatal(string format, params object[] args);

        /// <summary>
        /// Writes the args to the default logging output using the format provided.
        /// </summary>
        void WriteLine(LoggingLevel level, string format, params object[] args);
    }
}
