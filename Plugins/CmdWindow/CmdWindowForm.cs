using System;
using System.Windows.Forms;
using GitCommands;
using GitUIPluginInterfaces;

namespace CmdWindow
{
    public partial class CmdWindowForm : ResourceManager.GitExtensionsControl
    {
        private IGitUICommands m_gitUiCommands;

        public CmdWindowForm()
        {
            InitializeComponent();
            Translate();
        }

        public void Register(IGitUICommands gitUiCommands)
        {
            m_gitUiCommands = gitUiCommands;
        }

        /// <summary>
        /// Handles the Load event of the FormConsoleControlSample control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormConsoleControlSample_Load(object sender, EventArgs e)
        {
           consoleControl.StartProcess("cmd", null);
           consoleControl.IsInputEnabled = true;
           UpdateUIState();
        }

    /// <summary>
        /// Updates the state of the UI.
        /// </summary>
        private void UpdateUIState()
        {
            //  Update the state.
            if (consoleControl.IsProcessRunning)
                toolStripStatusLabelConsoleState.Text = "Running " + System.IO.Path.GetFileName(consoleControl.ProcessInterface.ProcessFileName);
            else
                toolStripStatusLabelConsoleState.Text = "Not Running";
        }

        /// <summary>
        /// Handles the Tick event of the timerUpdateUI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timerUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        private void consoleControl_ConsoleOutput(object sender, EventArgs e)
        {
            if (m_gitUiCommands != null) m_gitUiCommands.RepoChangedNotifier.Notify();
        }
    }
}
