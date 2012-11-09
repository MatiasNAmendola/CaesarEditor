/*****************************************************************
 * File name: PasteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:25:38 PM
 * Date Updated: 11/9/2012 2:25:38 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Paste", Top = "_Edit", Category = "Cut", Order = 205)]
    public class PasteCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Paste", typeof(PasteCommand), new InputGestureCollection
        {
            new KeyGesture(Key.V, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.PasteCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
