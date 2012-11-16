/*****************************************************************
 * File name: WordWrapCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:33:13 PM
 * Date Updated: 11/12/2012 1:33:13 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "",
                           MenuHeader = "_Word Wrap",
                           IsCheckable = true,
                           IsChecked = true,
                           IsEnabled = true,
                           MenuTop = "_Format",
                           MenuCategory = "LineNumber",
                           MenuOrder = 302)]
    sealed class WordWrapCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "WordWrap", typeof(WordWrapCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.WordWrapCommandExecuted; }
        }
    }
}
