/*****************************************************************
 * File name: DeleteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:27:29 PM
 * Date Updated: 11/9/2012 2:27:29 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "De_lete", Top = "_Edit", Category = "Cut", Order = 206)]
    sealed class DeleteCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Delete; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
