/*****************************************************************
 * File name: FontCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:41:52 PM
 * Date Updated: 11/12/2012 1:41:52 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Font", Top = "_Format", Category = "LineNumber", Order = 303)]
    sealed class FontCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Font", typeof(FontCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.FontCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
