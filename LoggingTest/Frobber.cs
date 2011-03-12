using Sunshine;

namespace LoggingTest
{
    public class Frobber
    {
        ILog log = LogManagerService.GetLogManager().GetLog(typeof(Frobber));

        public Frobber()
        {
            log.Debug("Frobber created");
        }
    }
}