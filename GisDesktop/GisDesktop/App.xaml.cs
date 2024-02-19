using Figure.Providers.FigureProviders.Factories;
using GisDesktop.Converters.FiguresConverter.Factories;
using GisDesktop.FigureProviders.Factories;
using GisDesktop.OpenFileDialogs.Factories;
using GisDesktop.ViewModels;
using System.Windows;

namespace GisDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var openFileDialogFactory = new OpenFileDialogFactory();

            var figureFileProviderFactory = new FigureFileProviderFactory();
            var figuresConverterFactory = new FiguresConverterFactory();
            var uiFigureFileProviderFactory = new UIFigureFileProviderFactory(figureFileProviderFactory, figuresConverterFactory);

            MainWindow = new MainWindow(openFileDialogFactory, uiFigureFileProviderFactory);
            MainWindow.DataContext = new MainViewModel();
            MainWindow.Show();
        }
    }

}
