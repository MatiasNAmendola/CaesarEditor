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
        string Icon { get; }
        string Header { get; }
        bool IsCheckable { get; }
        bool IsChecked { get; }
        bool IsEnabled { get; }

        string Top { get; }
        string Category { get; }
        double Order { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportMainMenuCommandAttribute : ExportAttribute, IMainMenuCommandMetadata
    {
        private bool isEnabled = true;

        public ExportMainMenuCommandAttribute()
            : base("MainMenuCommand", typeof(ICommandEx))
        {
        }

        public string Icon { get; set; }
        public string Header { get; set; }
        public bool IsCheckable { get; set; }
        public bool IsChecked { get; set; }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        public string Top { get; set; }
        public string Category { get; set; }
        public double Order { get; set; }
    }

    public interface IToolbarCommandMetadata
    {
        string Icon { get; }
        string ToolTip { get; }
        string Category { get; }
        double Order { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportToolbarCommandAttribute : ExportAttribute, IToolbarCommandMetadata
    {
        public ExportToolbarCommandAttribute()
            : base("ToolbarCommand", typeof(ICommandEx))
        {
        }

        public string Icon { get; set; }
        public string ToolTip { get; set; }
        public string Category { get; set; }
        public double Order { get; set; }
    }
}
