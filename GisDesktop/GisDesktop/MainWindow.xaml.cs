using GisDesktop.FigureProviders;
using Microsoft.Win32;
using System.Windows;
using GisDesktop.FigureProviders.Factories;
using GisDesktop.OpenFileDialogs.Factories;
using Figure.Providers.FigureProviders;
using System.Windows.Input;
using GisDesktop.ViewModels;
using System.ComponentModel;

namespace GisDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly IUIFigureFileProvider _figureFileProvider;

        public MainWindow(IOpenFileDialogFactory openFileDialogFactory, IUIFigureFileProviderFactory uiFigureFileProviderFactory)
        {
            InitializeComponent();

            _openFileDialog = openFileDialogFactory.Create();
            _figureFileProvider = uiFigureFileProviderFactory.Create();
        }

        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var success = _openFileDialog.ShowDialog();

            if (!success.HasValue || !success.Value)
                return;

            var path = _openFileDialog.FileName;
            FilePathTextBox.Text = path;
            await DownloadFiguresAsync(path);
        }

        private void PrintReadFileStateLabel(UIFigureProviderResult result)
        {
            if (!result.Success)
            {
                ReadFileStateLabel.Content = "Документ не прочитан";
                return;
            }

            if (result.HasParsedProblems)
            {
                ReadFileStateLabel.Content = "Документ прочитан с ошибками";
                return;
            }

            ReadFileStateLabel.Content = "Документ прочитан без ошибок";
        }

        public void Window_MouseDown(object sender, RoutedEventArgs e) => Grid.Focus();

        private async void FilePathTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var path = FilePathTextBox.Text;
            await DownloadFiguresAsync(path);
        }

        private async Task DownloadFiguresAsync(string filePaath)
        {
            FiguresCanvas.Children.Clear();

            var result = await _figureFileProvider.GetFiguresAsync(filePaath);
            foreach (var uiFigure in result.Figures)
                FiguresCanvas.Children.Add(uiFigure);

            PrintReadFileStateLabel(result);
        }
    }
}