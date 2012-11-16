/*****************************************************************
 * File name: OpenCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/5/2012 00:00:00 AM
 * Date Updated: 11/5/2012 00:00:00 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Open.png",
                          ToolTip = "Open",
                          ToolCategory = "New",
                          ToolOrder = 102)]
    [ExportMainMenuCommand(MenuIcon = "Images/Open.png",
                           MenuHeader = "_Open",
                           IsEnabled = true,
                           MenuTop = "_File",
                           MenuCategory = "New",
                           MenuOrder = 102)]
    sealed class OpenCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Open; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.OpenCommandExecuted; }
        }
    }
}
