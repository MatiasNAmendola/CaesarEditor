/*****************************************************************
 * File name: SaveAsCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 1:56:55 PM
 * Date Updated: 11/9/2012 1:56:55 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "Save _As", Top = "_File", Category = "New", Order = 104)]
    public class SaveAsCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "SaveAs", typeof(SaveAsCommand), new InputGestureCollection
        {
            //new KeyGesture(Key.H, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        private ExecutedRoutedEventHandler executed = (s, e) =>
        {
            MainWindow.Instance.SaveAsCommandExecuted(s, e);
        };

        public ExecutedRoutedEventHandler Executed
        {
            get { return executed; }
        }
    }
}
