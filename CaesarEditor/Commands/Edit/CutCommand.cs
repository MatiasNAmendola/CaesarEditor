/*****************************************************************
 * File name: CutCommand.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/9/2012 10:09:18 AM
 * Date Updated: 11/9/2012 10:09:18 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    [ExportMainMenuCommand(Icon = "", Header = "Cu_t", Top = "_Edit", Category = "Cut", Order = 203)]
    sealed class CutCommand : ICommandEx
    {
        public ICommand Command
        {
            get { return ApplicationCommands.Cut; }
        }

        public ExecutedRoutedEventHandler Executed
        {
            get { return null; }
        }
    }
}
