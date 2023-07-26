using System.Globalization;

namespace INStore.State.Registers
{
    public interface IRegister
    {
        CultureInfo GetLanguage();
        void SetLanguage(CultureInfo Culture);
        string GetDBConnectionString();
        string SetDBConnectionString(string DBConnectionString);
        string GetLoggingLocation();
        string SetLoggingLocation();
        string ReturnLoggingFolderLocation();

    }
}