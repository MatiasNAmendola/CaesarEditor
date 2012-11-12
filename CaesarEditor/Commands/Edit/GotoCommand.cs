/*****************************************************************
 * File name: GotoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:27:12 PM
 * Date Updated: 11/12/2012 1:27:12 PM
 *****************************************************************/
namespace CaesarEditor.Commands.Edit
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Go to", Top = "_Edit", Category = "Find", Order = 209)]
    sealed class GotoCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Goto", typeof(GotoCommand), new InputGestureCollection
        {
            new KeyGesture(Key.G, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.GotoCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
