/*****************************************************************
 * File name: NewCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/8/2012 11:25:37 AM
 * Date Updated: 11/8/2012 11:25:37 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_New", Top = "_File", Category = "New", Order = 0)]
    sealed class NewCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "New", typeof(NewCommand), new InputGestureCollection
        {
            new KeyGesture(Key.N, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            //MainWindow.Instance.NewCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
