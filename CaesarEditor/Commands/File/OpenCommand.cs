/*****************************************************************
 * File name: OpenCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/5/2012 00:00:00 AM
 * Date Updated: 11/5/2012 00:00:00 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Open", Top = "_File", Category = "New", Order = 102)]
    sealed class OpenCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Open", typeof(OpenCommand), new InputGestureCollection
        {
            new KeyGesture(Key.O, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.OpenCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
