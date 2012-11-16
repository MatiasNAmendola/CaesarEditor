namespace CaesarEditor
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using CaesarEditor.Commands;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Search;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFileName;

        public string CurrentFileName
        {
            get { return this.currentFileName; }
            private set
            {
                this.currentFileName = value;
                this.Title = string.Format("{0} - {1}", value, "CaesarEditor");
            }
        }

        private string currentFilePath;

        public string CurrentFilePath
        {
            get { return this.currentFilePath; }
            private set { this.currentFilePath = value; }
        }

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
            textEditor.TextArea.DefaultInputHandler.NestedInputHandlers.Add(new SearchInputHandler(textEditor.TextArea));
            InitMainMenu();
            InitToolbar();
            NewDocument();
        }

        [ImportMany("MainMenuCommand", typeof(ICommandEx))]
        private Lazy<ICommandEx, IMainMenuCommandMetadata>[] mainMenuCommandCollection = null;

        /// <summary> Initialize main menu </summary>
        private void InitMainMenu()
        {
            foreach (var topGroup in mainMenuCommandCollection.OrderBy(c => c.Metadata.MenuOrder).GroupBy(c => c.Metadata.MenuTop))
            {
                var topMenuItem = mainMenu.Items.OfType<MenuItem>().FirstOrDefault(m => string.Equals((m.Header as string), topGroup.Key));
                if (topMenuItem == null)
                {
                    topMenuItem = new MenuItem();
                    topMenuItem.Header = topGroup.Key;
                    mainMenu.Items.Add(topMenuItem);
                }
                foreach (var categoryGroup in topGroup.GroupBy(c => c.Metadata.MenuCategory))
                {
                    if (topMenuItem.Items.Count > 0)
                    {
                        topMenuItem.Items.Add(new Separator());
                    }
                    foreach (var entry in categoryGroup)
                    {
                        MenuItem menuItem = new MenuItem();
                        if (!string.IsNullOrEmpty(entry.Metadata.MenuIcon))
                        {
                            menuItem.Icon = LoadImage(entry.Metadata.MenuIcon);
                        }
                        menuItem.Header = entry.Metadata.MenuHeader;
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

        [ImportMany("ToolbarCommand", typeof(ICommandEx))]
        private Lazy<ICommandEx, IToolbarCommandMetadata>[] toolbarCommandCollection = null;

        /// <summary> Initialize toolbar </summary>
        private void InitToolbar()
        {
            int pos = 0;
            foreach (var commandGroup in toolbarCommandCollection.OrderBy(c => c.Metadata.ToolOrder).GroupBy(c => c.Metadata.ToolCategory))
            {
                foreach (var command in commandGroup)
                {
                    toolBar.Items.Insert(pos++, MakeToolbarItem(command));
                }
                toolBar.Items.Insert(pos++, new Separator());
            }
        }

        private Button MakeToolbarItem(Lazy<ICommandEx, IToolbarCommandMetadata> command)
        {
            Button button = new Button();
            button.ToolTip = command.Metadata.ToolTip;
            button.Content = LoadImage(command.Metadata.ToolIcon);
            button.Command = command.Value.Command;
            return button;
        }

        private Image LoadImage(string icon)
        {
            Uri uri = new Uri("pack://application:,,,/" + icon);
            BitmapImage image = new BitmapImage(uri);
            image.Freeze();
            return new Image { Width = 16, Height = 16, Source = image };
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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !PrepareClosing();
            base.OnClosing(e);
        }
        #endregion

        #region /// <summary> Main menu "Edit" </summary>
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
        }
        #endregion

        #region /// <summary> Main menu "View" </summary>
        #endregion

        #region /// <summary> Main menu "Help" </summary>
        public void AboutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("About");
        }
        #endregion

        private bool NewDocument()
        {
            textEditor.Clear();
            CurrentFileName = "Untitled";
            CurrentFilePath = "";
            textEditor.IsModified = false;
            return true;
        }

        private bool OpenDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Visual C# Files|*.cs"
                         + "|Web Files|*.htm;*.html"
                         + "|IL Files|*.il"
                         + "|Script Files|*.js"
                         + "|Text Files|*.txt"
                         + "|All Files|*.*";
            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() ?? false)
            {
                CurrentFileName = dialog.SafeFileName;
                CurrentFilePath = dialog.FileName;
                textEditor.Load(dialog.FileName);
                string fileExtension = Path.GetExtension(dialog.FileName);
                textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(fileExtension);
                return true;
            }
            return false;
        }

        private bool SaveDocument()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                return SaveAsDocument();
            }
            textEditor.Save(currentFilePath);
            return true;
        }

        private bool SaveAsDocument()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All Files|*.*";
            if (dialog.ShowDialog() ?? false)
            {
                CurrentFileName = dialog.SafeFileName;
                CurrentFilePath = dialog.FileName;
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
    }
}
