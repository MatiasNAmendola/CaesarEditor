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
        private string currentFileName;

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
                        menuItem.IsCheckable = entry.Metadata.IsCheckable;
                        menuItem.IsChecked = entry.Metadata.IsChecked;
                        menuItem.IsEnabled = entry.Metadata.IsEnabled;
                        menuItem.Command = entry.Value.Command;
                        if (entry.Value.Executed != null)
                        {
                            CommandBindings.Add(new CommandBinding(menuItem.Command, entry.Value.Executed));
                        }
                        topMenuItem.Items.Add(menuItem);
                    }
                }
            }
        }

        #region /// <summary> Main menu "File" </summary>
        public void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (PrepareClosing())
            {
                NewDocument();
            }
        }

        public void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (PrepareClosing())
            {
                OpenDocument();
            }
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
        #endregion

        #region /// <summary> Main menu "Format" </summary>
        public void LineNumberCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.ShowLineNumbers = !textEditor.ShowLineNumbers;
        }

        public void WordWrapCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.WordWrap = !textEditor.WordWrap;
        }

        public void FontCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Font");
        }
        #endregion

        #region /// <summary> Main menu "View" </summary>
        #endregion

        #region /// <summary> Main menu "Help" </summary>
        public void HelpCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Help");
        }

        public void AboutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("About");
        }
        #endregion

        private bool NewDocument()
        {
            textEditor.Clear();
            return true;
        }

        private bool OpenDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files|*.*";
            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() ?? false)
            {
                currentFileName = dialog.FileName;
                textEditor.Load(dialog.FileName);
                string fileExtension = Path.GetExtension(dialog.FileName);
                textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(fileExtension);
                return true;
            }
            return false;
        }

        private bool SaveDocument()
        {
            if (string.IsNullOrEmpty(currentFileName))
            {
                return SaveAsDocument();
            }
            textEditor.Save(currentFileName);
            return true;
        }

        private bool SaveAsDocument()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All Files|*.*";
            if (dialog.ShowDialog() ?? false)
            {
                currentFileName = dialog.FileName;
                textEditor.Save(currentFileName);
                return true;
            }
            return false;
        }

        private bool PrepareClosing()
        {
            if (textEditor.IsModified)
            {
                string caption = "CaesarEditor";
                string prompt = "Do you want to save changes?";
                switch (MessageBox.Show(prompt, caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Information))
                {
                    case MessageBoxResult.Yes: return SaveDocument();
                    case MessageBoxResult.No: return true;
                    case MessageBoxResult.Cancel: return false;
                    default: return false;
                }
            }
            return true;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !PrepareClosing();
            base.OnClosing(e);
        }
    }
}
