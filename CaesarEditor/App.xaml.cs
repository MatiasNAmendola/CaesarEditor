namespace CaesarEditor
{
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static CompositionContainer compositionContainer;

        public static CompositionContainer CompositionContainer
        {
            get { return compositionContainer; }
        }

        public App()
        {
            var catalog = new AssemblyCatalog(typeof(App).Assembly);
            compositionContainer = new CompositionContainer(catalog);
        }
    }
}
