/*****************************************************************
 * File name: LineNumberCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:00:15 PM
 * Date Updated: 11/12/2012 1:00:15 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Line Number", IsCheckable = true, Top = "_Format", Category = "LineNumber", Order = 301)]
    sealed class LineNumberCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "LineNumber", typeof(LineNumberCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.LineNumberCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
