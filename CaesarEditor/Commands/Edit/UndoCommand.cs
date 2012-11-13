/*****************************************************************
 * File name: UndoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:08:57 AM
 * Date Updated: 11/9/2012 10:08:57 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Undo.png",
                          ToolTip = "Undo",
                          ToolCategory = "Undo",
                          ToolOrder = 201)]
    [ExportMainMenuCommand(MenuIcon = "Images/Undo.png",
                           MenuHeader = "_Undo",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Undo",
                           MenuOrder = 201)]
    sealed class UndoCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Undo; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
