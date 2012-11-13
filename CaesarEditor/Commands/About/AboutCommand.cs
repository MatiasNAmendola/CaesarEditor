/*****************************************************************
 * File name: AboutCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:48:08 PM
 * Date Updated: 11/12/2012 1:48:08 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "_About",
                           IsEnabled = true,
                           MenuTop = "_Help",
                           MenuCategory = "Help",
                           MenuOrder = 9999)]
    sealed class AboutCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "About", typeof(AboutCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.AboutCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
