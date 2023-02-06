using System.Globalization;

namespace INStore.Language
{
    public interface ILanguageSetter
    {
        public bool IsArabic();
        public bool IsEnglish();
        public void SetToArabic();
        public void SetToEnglish();
        private void SetLanguage(CultureInfo Newculture) { }
    }
}