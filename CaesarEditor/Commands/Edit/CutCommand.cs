/*****************************************************************
 * File name: CutCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:09:18 AM
 * Date Updated: 11/9/2012 10:09:18 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "Cu_t", Top = "_Edit", Category = "Cut", Order = 203)]
    public class CutCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Cut", typeof(CutCommand), new InputGestureCollection
        {
            new KeyGesture(Key.X, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.CutCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
