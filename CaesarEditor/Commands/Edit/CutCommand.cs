/*****************************************************************
 * File name: CutCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:09:18 AM
 * Date Updated: 11/9/2012 10:09:18 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportToolbarCommand(ToolIcon = "Images/Cut.png",
                          ToolTip = "Cut",
                          ToolCategory = "Cut",
                          ToolOrder = 203)]
    [ExportMainMenuCommand(MenuIcon = "Images/Cut.png",
                           MenuHeader = "Cu_t",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Cut",
                           MenuOrder = 203)]
    sealed class CutCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Cut; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
