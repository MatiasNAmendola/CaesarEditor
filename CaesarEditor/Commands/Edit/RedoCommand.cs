/*****************************************************************
 * File name: RedoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:14:22 PM
 * Date Updated: 11/9/2012 2:14:22 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Redo", Top = "_Edit", Category = "Undo", Order = 202)]
    sealed class RedoCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Redo; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
