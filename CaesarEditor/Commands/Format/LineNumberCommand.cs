/*****************************************************************
 * File name: LineNumberCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:00:15 PM
 * Date Updated: 11/12/2012 1:00:15 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "_Line Number",
                           IsCheckable = true,
                           IsChecked = true,
                           IsEnabled = true,
                           MenuTop = "_Format",
                           MenuCategory = "LineNumber",
                           MenuOrder = 301)]
    sealed class LineNumberCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "LineNumber", typeof(LineNumberCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.LineNumberCommandExecuted; }
        }
    }
}
