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

    [ExportMainMenuCommand(Icon = "", Header = "_Redo", Top = "_Edit", Category = "Undo", Order = 202)]
    public class RedoCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Redo", typeof(RedoCommand), new InputGestureCollection
        {
            new KeyGesture(Key.Y, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.RedoCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
