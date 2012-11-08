namespace CaesarEditor
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using CaesarEditor.Commands;
    using ICSharpCode.AvalonEdit.Highlighting;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public static MainWindow Instance
        {
            get { return instance; }
        }

        public MainWindow()
        {
            instance = this;
            InitializeComponent();
            App.CompositionContainer.ComposeParts(this);
            InitMainMenu();
        }

        [ImportMany("MainMenuCommand", typeof(ICommandEx))]
        private Lazy<ICommandEx, IMainMenuCommandMetadata>[] mainMenuCommandCollection = null;

        /// <summary> Initialize main menu. </summary>
        private void InitMainMenu()
        {
            foreach (var topGroup in mainMenuCommandCollection.OrderBy(c => c.Metadata.Order).GroupBy(c => c.Metadata.Top))
            {
                var topMenuItem = mainMenu.Items.OfType<MenuItem>().FirstOrDefault(m => string.Equals((m.Header as string), topGroup.Key));
                if (topMenuItem == null)
                {
                    topMenuItem = new MenuItem();
                    topMenuItem.Header = topGroup.Key;
                    mainMenu.Items.Add(topMenuItem);
                }
                foreach (var categoryGroup in topGroup.GroupBy(c => c.Metadata.Category))
                {
                    if (topMenuItem.Items.Count > 0)
                    {
                        topMenuItem.Items.Add(new Separator());
                    }
                    foreach (var entry in categoryGroup)
                    {
                        MenuItem menuItem = new MenuItem();
                        if (!string.IsNullOrEmpty(entry.Metadata.Icon))
                        {
                        }
                        menuItem.Header = entry.Metadata.Header;
                        menuItem.IsEnabled = entry.Metadata.IsEnabled;
                        menuItem.Command = entry.Value.Command;
                        CommandBindings.Add(new CommandBinding(menuItem.Command, entry.Value.Executed));
                        topMenuItem.Items.Add(menuItem);
                    }
                }
            }
        }

        public void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }

        public void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenDocument();
        }

        public void ExitCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private bool OpenDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Visual C# Files|*.cs|All Files|*.*";
            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() ?? false)
            {
                MainWindow.Instance.textEditor.Load(dialog.FileName);
                MainWindow.Instance.textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(dialog.FileName));
            }
            return true;
        }
    }
}