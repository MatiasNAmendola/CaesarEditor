/*****************************************************************
 * File name: SelectAllCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/13/2012 9:23:44 AM
 * Date Updated: 11/13/2012 9:23:44 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "Select _All",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "SelectAll",
                           MenuOrder = 210)]
    sealed class SelectAllCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.SelectAll; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
