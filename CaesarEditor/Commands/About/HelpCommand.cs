/*****************************************************************
 * File name: HelpCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:58:37 PM
 * Date Updated: 11/12/2012 1:58:37 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Help", Top = "_Help", Category = "Help", Order = 9901)]
    sealed class HelpCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Help; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.HelpCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
