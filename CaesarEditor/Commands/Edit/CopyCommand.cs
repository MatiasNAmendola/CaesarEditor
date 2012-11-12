/*****************************************************************
 * File name: CopyCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 2:23:45 PM
 * Date Updated: 11/9/2012 2:23:45 PM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "_Copy", Top = "_Edit", Category = "Cut", Order = 204)]
    sealed class CopyCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Copy; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
