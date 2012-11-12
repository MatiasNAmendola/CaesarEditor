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
    sealed class SaveCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Save; }
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
