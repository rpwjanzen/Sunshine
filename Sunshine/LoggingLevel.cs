namespace Sunshine
{
    /// <summary>
    /// The type of error to log.
    /// </summary>
    public enum LoggingLevel
    {
        Debug,
        /// <summary>
        /// A message containing information only.
        /// </summary>
        Info,
        /// <summary>
        /// A non-critical warning error message.
        /// </summary>
        Warn,
        /// <summary>
        /// A fatal error message.
        /// </summary>
        Fatal
    }
}
