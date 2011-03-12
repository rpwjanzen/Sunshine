using System.Collections.Specialized;
using System.Windows.Controls;

namespace Sunshine.UI
{
    public partial class LogViewer : UserControl
    {
        #region Fields

        private readonly ILog m_log = LogManagerService.GetLogManager().GetLog(typeof(LogViewer));

        #endregion

        #region Constructors

        public LogViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ILog Log
        {
            get { return this.DataContext as ILog; }
            set
            {
                ILog previousLog = Log;
                if (previousLog != null)
                    previousLog.Entries.CollectionChanged -= new NotifyCollectionChangedEventHandler(LogEntries_CollectionChanged);

                this.DataContext = value;
                m_log.Debug("Log set to {0}", Log);

                if (Log != null)
                    Log.Entries.CollectionChanged += new NotifyCollectionChangedEventHandler(LogEntries_CollectionChanged);
            }
        }

        #endregion

        #region Event Handlers

        void LogEntries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add)
                return;
            
            m_dataGrid.ScrollIntoView(e.NewItems[0], null);            
        }

        private void clearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Log == null)
                return;

            m_log.Debug("Clearing log {0}", Log);
            Log.Clear();
        }

        #endregion
    }
}
