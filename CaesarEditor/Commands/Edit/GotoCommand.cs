/*****************************************************************
 * File name: GotoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/12/2012 1:27:12 PM
 * Date Updated: 11/12/2012 1:27:12 PM
 *****************************************************************/
namespace CaesarEditor.Commands.Edit
{
    using System.Windows.Input;

    [ExportMainMenuCommand(MenuIcon = "Images/Goto.png",
                           MenuHeader = "_Go to",
                           IsEnabled = true,
                           MenuTop = "_Edit",
                           MenuCategory = "Find",
                           MenuOrder = 209)]
    sealed class GotoCommand : ICommandEx
    {
        private ICommand command = new RoutedUICommand(string.Empty, "Goto", typeof(GotoCommand), new InputGestureCollection
        {
            new KeyGesture(Key.G, ModifierKeys.Control)
        });

        public ICommand Command
        {
            get { return command; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return MainWindow.Instance.GotoCommandExecuted; }
        }
    }
}
