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
        { "guys", "мальчики" },
        { "swimming", "купаются" },
        { "river", "речке" },
        { "me", "я" },
        { "my", "моим" },
        { "mushrooms", "грибами" },
        { "berries", "ягодами" },
        { "football", "футбол" },
        { "basketball", "баскетбол" },
        { "volleyball", "волейбол" },
        { "hockey", "хоккей" },
        { "running", "бег" },
        { "us", "мы" },
        { "look", "увидели" },
        { "fog", "туман" },
        { "rainbow", "радугу" },
        { "you", "ты" },
        { "sky", "небо" },
        { "recently", "недавно" },
        { "around", "вокруг" },
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