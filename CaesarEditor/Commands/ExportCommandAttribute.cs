/*****************************************************************
 * File name: ExportCommandAttribute.cs
 * Description:
 * Author: Paboo
 * Homepage: http://www.paboo.cn/
 * Date Created: 11/5/2012 00:00:00 AM
 * Date Updated: 11/5/2012 00:00:00 AM
 *****************************************************************/
namespace CaesarEditor.Commands
{
    using System;
    using System.ComponentModel.Composition;

    public interface IMainMenuCommandMetadata
    {
        string MenuIcon { get; }
        string MenuHeader { get; }
        bool IsCheckable { get; }
        bool IsChecked { get; }
        bool IsEnabled { get; }

        string MenuTop { get; }
        string MenuCategory { get; }
        double MenuOrder { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportMainMenuCommandAttribute : ExportAttribute, IMainMenuCommandMetadata
    {
        public ExportMainMenuCommandAttribute()
            : base("MainMenuCommand", typeof(ICommandEx))
        {
        }

        public string MenuIcon { get; set; }
        public string MenuHeader { get; set; }
        public bool IsCheckable { get; set; }
        public bool IsChecked { get; set; }
        public bool IsEnabled { get; set; }

        public string MenuTop { get; set; }
        public string MenuCategory { get; set; }
        public double MenuOrder { get; set; }
    }

    public interface IToolbarCommandMetadata
    {
        string ToolIcon { get; }
        string ToolTip { get; }
        string ToolCategory { get; }
        double ToolOrder { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportToolbarCommandAttribute : ExportAttribute, IToolbarCommandMetadata
    {
        public ExportToolbarCommandAttribute()
            : base("ToolbarCommand", typeof(ICommandEx))
        {
        }

        public string ToolIcon { get; set; }
        public string ToolTip { get; set; }
        public string ToolCategory { get; set; }
        public double ToolOrder { get; set; }
    }
}
