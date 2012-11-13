/*****************************************************************
 * File name: PasteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:25:38 PM
 * Date Updated: 11/9/2012 2:25:38 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Paste.png",
                          ToolTip = "Paste",
                          ToolCategory = "Cut",
                          ToolOrder = 205)]
    [ExportMainMenuCommand(MenuIcon = "Images/Paste.png",
                           MenuHeader = "_Paste",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Cut",
                           MenuOrder = 205)]
    sealed class PasteCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Paste; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
