/*****************************************************************
 * File name: DeleteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:27:29 PM
 * Date Updated: 11/9/2012 2:27:29 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "De_lete", Top = "_Edit", Category = "Cut", Order = 206)]
    public class DeleteCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Delete", typeof(DeleteCommand), new InputGestureCollection
        {
            new KeyGesture(Key.Delete, ModifierKeys.None)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.DeleteCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
