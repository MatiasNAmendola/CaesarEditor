/*****************************************************************
 * File name: DeleteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:27:29 PM
 * Date Updated: 11/9/2012 2:27:29 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Delete.png",
                          ToolTip = "Delete",
                          ToolCategory = "Cut",
                          ToolOrder = 206)]
    [ExportMainMenuCommand(MenuIcon = "Images/Delete.png",
                           MenuHeader = "De_lete",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Cut",
                           MenuOrder = 206)]
    sealed class DeleteCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Delete; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
