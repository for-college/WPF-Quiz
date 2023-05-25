using System.Collections.Generic;

internal static class Dictionary
{
    // Словарь ключ - значение для перевода слов на русский язык.
    // Пояснение: если лимит по кол-ву картинок в тексте, то слова для картинок необходимо перевести
    private static readonly Dictionary<string, string> wordPairs = new Dictionary<string, string>()
    {
        { "birch", "береза" },
        { "window", "окном" },
        { "under", "под" },
        { "wait", "ждать" },
        { "rain", "дождь" },
        { "me", "я" },
        { "my", "моим" },
        { "us", "мы" },
        { "rainbow", "радугу" },
        { "you", "ты" },
        { "sky", "небо" },
        { "recently", "недавно" },
        { "around", "кругом" },
        { "fitted", "облегала" },
        { "wonderful", "чудесный" },
        { "your", "твой" },
        { "father", "отец" },
        { "criminal", "преступник" },
        { "baby", "младенец" },
        { "he", "он" },
        { "hero", "герой" },
        { "fire", "пламенной" },
        { "blood", "окрававленной" },

        { "freezing", "мороз" },
        { "sun", "солнце" },
        { "friend", "друг" },

        { "watch", "часы" },
        { "freedom", "свободы" },
        { "read", "читал" },

        { "nounchain", "цепи" },
        { "day", "днём" },
        { "cat", "кот" },
        { "night", "ночью" },
        { "hnd", "рукой" },
    };
    // С помощью TryGetValue находим пару и переводим
    public static string TranslateWord(string englishWord)
    {
        if (wordPairs.TryGetValue(englishWord, out string russianWord))
        {
            return russianWord;
        }

        // Если нет пары, то возвращаем исходное слово
        return englishWord;
    }
}