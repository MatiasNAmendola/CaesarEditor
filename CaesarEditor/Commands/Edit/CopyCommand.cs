/*****************************************************************
 * File name: CopyCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:23:45 PM
 * Date Updated: 11/9/2012 2:23:45 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Copy", Top = "_Edit", Category = "Cut", Order = 204)]
    public class CopyCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Copy", typeof(CopyCommand), new InputGestureCollection
        {
            new KeyGesture(Key.C, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.CopyCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
