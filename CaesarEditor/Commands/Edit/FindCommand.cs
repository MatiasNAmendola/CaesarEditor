/*****************************************************************
 * File name: FindCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:09:36 AM
 * Date Updated: 11/9/2012 10:09:36 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Find", Top = "_Edit", Category = "Find", Order = 207)]
    sealed class FindCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Find; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.FindCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
