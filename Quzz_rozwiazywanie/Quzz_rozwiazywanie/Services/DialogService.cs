using Microsoft.Win32;
using System.Windows;

namespace Quzz_rozwiazywanie.Services
{
    public class DialogService : IDialogService
    {
        public string ShowOpenFileDialog(string filter)
        {
            var dialog = new OpenFileDialog
            {
                Filter = filter,
                DefaultExt = ".quiz"
            };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
