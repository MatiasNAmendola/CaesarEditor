/*****************************************************************
 * File name: SaveCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:04:30 AM
 * Date Updated: 11/9/2012 10:04:30 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Save", Top = "_File", Category = "New", Order = 103)]
    public class SaveCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Save", typeof(SaveCommand), new InputGestureCollection
        {
            new KeyGesture(Key.S, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.SaveCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
