/*****************************************************************
 * File name: FontCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:41:52 PM
 * Date Updated: 11/12/2012 1:41:52 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "_Font",
                           IsEnabled = false,
                           MenuTop = "_Format",
                           MenuCategory = "LineNumber",
                           MenuOrder = 303)]
    sealed class FontCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Font", typeof(FontCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.FontCommandExecuted; }
        }
    }
}
