using Microsoft.Win32;

namespace GisDesktop.OpenFileDialogs.Factories
{
    internal class OpenFileDialogFactory : IOpenFileDialogFactory
    {
        public OpenFileDialog Create()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Выберите файл с ГИС данными";

            return openFileDialog;
        }
    }
}
