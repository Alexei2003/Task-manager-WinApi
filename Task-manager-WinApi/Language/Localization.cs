namespace Task_manager_WinApi.Language
{
    public class Localization
    {
        public enum Language
        {
            en, ru
        }


        public static string? GetLanguageName(Language language)
        {
            switch (language)
            {
                case Language.en:
                    return "en";
                    break;
                case Language.ru:
                    return "ru";
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
