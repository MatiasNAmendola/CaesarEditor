/*****************************************************************
 * File name: PasteCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:25:38 PM
 * Date Updated: 11/9/2012 2:25:38 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Paste", Top = "_Edit", Category = "Cut", Order = 205)]
    sealed class PasteCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Paste; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
