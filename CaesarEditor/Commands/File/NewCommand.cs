/*****************************************************************
 * File name: NewCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/8/2012 11:25:37 AM
 * Date Updated: 11/8/2012 11:25:37 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/New.png",
                          ToolTip = "New",
                          ToolCategory = "New",
                          ToolOrder = 101)]
    [ExportMainMenuCommand(MenuIcon = "Images/New.png",
                           MenuHeader = "_New",
                           IsEnabled = true,
                           MenuTop = "_File",
                           MenuCategory = "New",
                           MenuOrder = 101)]
    sealed class NewCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.New; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.NewCommandExecuted; }
        }
    }
}
