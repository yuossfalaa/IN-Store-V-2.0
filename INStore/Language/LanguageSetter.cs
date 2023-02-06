using INStore.State.Registers;
using System.Globalization;

namespace INStore.Language
{
    public class LanguageSetter : ILanguageSetter
    {
        private readonly IRegister register;
        private  CultureInfo cultureInfo;
        public LanguageSetter(IRegister register)
        {
            this.register = register;
            cultureInfo = register.GetLanguage();
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = cultureInfo;
        }

        private void SetLanguage(CultureInfo Newculture)
        {
            register.SetLanguage(Newculture);
            cultureInfo = Newculture;
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = cultureInfo;
        }
        public bool IsArabic()
        {
            return cultureInfo.EnglishName == "Arabic (Egypt)";
        }
        public bool IsEnglish()
        {
            return cultureInfo.EnglishName == "English (United States)";
        }

        public void SetToArabic()
        {
            SetLanguage(new CultureInfo("en-US"));
        }

        public void SetToEnglish()
        {
            SetLanguage(new CultureInfo("ar-EG"));
        }
    }
}
