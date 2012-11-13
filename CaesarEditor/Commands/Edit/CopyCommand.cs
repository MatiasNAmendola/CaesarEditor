/*****************************************************************
 * File name: CopyCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:23:45 PM
 * Date Updated: 11/9/2012 2:23:45 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Copy.png",
                          ToolTip = "Copy",
                          ToolCategory = "Cut",
                          ToolOrder = 204)]
    [ExportMainMenuCommand(MenuIcon = "Images/Copy.png",
                           MenuHeader = "_Copy",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Cut",
                           MenuOrder = 204)]
    sealed class CopyCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Copy; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
