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

    [ExportMainMenuCommand(Icon = "", Header = "_Undo", Top = "_Edit", Category = "Undo", Order = 201)]
    public class UndoCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Undo", typeof(UndoCommand), new InputGestureCollection
        {
            new KeyGesture(Key.Z, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.UndoCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
