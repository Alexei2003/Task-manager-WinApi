using static Task_manager_WinApi.ProcessesColumns;
using System.Text.Json;

namespace Task_manager_WinApi.Language
{
    internal class Localization
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
