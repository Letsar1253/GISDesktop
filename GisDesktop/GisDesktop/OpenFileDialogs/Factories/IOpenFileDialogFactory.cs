using Microsoft.Win32;

namespace GisDesktop.OpenFileDialogs.Factories
{
    public interface IOpenFileDialogFactory
    {
        OpenFileDialog Create();
    }
}
