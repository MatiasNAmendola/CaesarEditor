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

    [ExportMainMenuCommand(Icon = "", Header = "_Word Wrap", IsCheckable = true, Top = "_Format", Category = "LineNumber", Order = 302)]
    sealed class WordWrapCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "WordWrap", typeof(WordWrapCommand), new InputGestureCollection
        {
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.WordWrapCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
