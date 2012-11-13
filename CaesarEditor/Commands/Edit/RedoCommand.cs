/*****************************************************************
 * File name: RedoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:14:22 PM
 * Date Updated: 11/9/2012 2:14:22 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Redo.png",
                          ToolTip = "Redo",
                          ToolCategory = "Undo",
                          ToolOrder = 202)]
    [ExportMainMenuCommand(MenuIcon = "Images/Redo.png",
                           MenuHeader = "_Redo",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Undo",
                           MenuOrder = 202)]
    sealed class RedoCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Redo; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
