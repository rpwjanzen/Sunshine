using System.Windows.Controls;

namespace Sunshine.UI
{
    public partial class LogManagerView : UserControl
    {
        #region Fields

        private readonly ILog m_log = LogManagerService.GetLogManager().GetLog(typeof(LogManagerView));

        #endregion

        #region Constructors

        public LogManagerView()
        {
            InitializeComponent();
            ILogManager logManager = LogManagerService.GetLogManager();
            // This line will cause a harmless BindingExpression path error because the DataContext is inheirited to the m_logViewer.
            this.DataContext = logManager;
            // 0 is the Global Log
            m_logViewer.Log = logManager.Logs[0];
        }

        #endregion

        #region Event Handlers

        private void m_logsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_logViewer.Log = m_logsDataGrid.SelectedItem as ILog;
        }

        #endregion
    }
}
