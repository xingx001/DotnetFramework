

namespace Dotnet.Mvc.ValueProvider
{
    public interface ICookie
    {
        T GetValue<T>(string name);

        T GetValue<T>(string name, bool expireOnceRead);

        void SetValue<T>(string name, T value);

        void SetValue<T>(string name, T value, float expireDurationInMinutes);

        void SetValue<T>(string name, T value, bool httpOnly, bool expireWithBrowser);

        void SetValue<T>(string name, T value, float expireDurationInMinutes, bool httpOnly, bool expireWithBrowser);

        void Delete(string name);
    }
}