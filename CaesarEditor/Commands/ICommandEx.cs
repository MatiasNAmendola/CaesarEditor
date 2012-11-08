/*****************************************************************
 * File name: ICommandEx.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/5/2012 00:00:00 AM
 * Date Updated: 11/5/2012 00:00:00 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System.Windows.Input;

    public interface ICommandEx
    {
        ICommand Command { get; }
        ExecutedRoutedEventHandler Executed { get; }
    }
}
