using System.Windows.Forms;
using GitUIPluginInterfaces;
using ResourceManager;

namespace CmdWindow
{
    public class CmdWindowPlugin : GitPluginBase, IGitPluginForRepository
    {
        public CmdWindowPlugin()
        {
            Description = "Show a cmd window";
            Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            return true;
        }
    }
}
