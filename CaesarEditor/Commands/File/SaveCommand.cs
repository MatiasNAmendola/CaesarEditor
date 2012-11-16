/*****************************************************************
 * File name: SaveCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:04:30 AM
 * Date Updated: 11/9/2012 10:04:30 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Save.png",
                          ToolTip = "Save",
                          ToolCategory = "New",
                          ToolOrder = 103)]
    [ExportMainMenuCommand(MenuIcon = "Images/Save.png",
                           MenuHeader = "_Save",
                           IsEnabled = true,
                           MenuTop = "_File",
                           MenuCategory = "New",
                           MenuOrder = 103)]
    sealed class SaveCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Save; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.SaveCommandExecuted; }
        }
    }
}
