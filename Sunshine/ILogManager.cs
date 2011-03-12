using System;

namespace Sunshine
{
    public interface ILogManager
    {
        ReadOnlyObservableCollection<ILog> Logs { get; }
        ILog GetLog(Type type);
    }
}
