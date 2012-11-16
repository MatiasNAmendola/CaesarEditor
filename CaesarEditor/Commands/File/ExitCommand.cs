/*****************************************************************
 * File name: ExitCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/7/2012 00:00:00 AM
 * Date Updated: 11/7/2012 00:00:00 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "E_xit",
                           IsEnabled = true,
                           MenuTop = "_File",
                           MenuCategory = "Exit",
                           MenuOrder = 199)]
    sealed class ExitCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Exit", typeof(ExitCommand), new InputGestureCollection
        {
            new KeyGesture(Key.F4, ModifierKeys.Alt)
        });

        public ICommand Command
        {
            get { return command; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.ExitCommandExecuted; }
        }
    }
}
