/*****************************************************************
 * File name: ReplaceCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:05:57 PM
 * Date Updated: 11/12/2012 1:05:57 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Replace", Top = "_Edit", Category = "Find", Order = 208)]
    sealed class ReplaceCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Replace; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.ReplaceCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
