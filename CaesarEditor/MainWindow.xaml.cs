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

        /// <summary> Initialize main menu </summary>
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

        #region /// <summary> Main menu "File" </summary>
        public void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            NewDocument();
        }

        public void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenDocument();
        }

        public void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveDocument();
        }

        public void SaveAsCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAsDocument();
        }

        public void ExitCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region /// <summary> Main menu "Edit" </summary>
        public void UndoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Undo");
        }

        public void RedoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Redo");
        }

        public void CutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Cut");
        }

        public void CopyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Copy");
        }

        public void PasteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Paste");
        }

        public void DeleteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Delete");
        }

        public void FindCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Find");
        }

        public void ReplaceCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Replace");
        }

        public void GotoCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Goto");
        }

        public void SelectAllCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("SelectAll");
        }

        public void DateTimeCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("DateTime");
        }
        #endregion

        #region /// <summary> Main menu "Format" </summary>
        public void LineNumberCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }

        public void WordWrapCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }

        public void FontCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
        #endregion

        #region /// <summary> Main menu "View" </summary>
        #endregion

        #region /// <summary> Main menu "Help" </summary>
        public void AboutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
        #endregion

        private bool NewDocument()
        {
            return MessageBox.Show("New") == MessageBoxResult.OK;
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
                return true;
            }
            return false;
        }

        private bool SaveDocument()
        {
            return MessageBox.Show("Save") == MessageBoxResult.OK;
        }

        private bool SaveAsDocument()
        {
            return MessageBox.Show("SaveAs") == MessageBoxResult.OK;
        }
    }
}
