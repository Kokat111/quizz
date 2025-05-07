namespace Quzz_rozwiazywanie.Services
{
    public interface IDialogService
    {
        string ShowOpenFileDialog(string filter);
        void ShowMessage(string message);
        void ShowError(string message);
    }
}
