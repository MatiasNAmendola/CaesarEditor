/*****************************************************************
 * File name: UndoCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:08:57 AM
 * Date Updated: 11/9/2012 10:08:57 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Undo", Top = "_Edit", Category = "Undo", Order = 201)]
    sealed class UndoCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Undo; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
