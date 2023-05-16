// See https://aka.ms/new-console-template for more information

namespace Bible_Verse_Memorization;

class BibleVerseMemorization
{
    // Set of common words to ignore
    private static readonly string[] IgnoreWords = { "the", "and", "that", "he", "his", "in", "but", "have", "is" };

    private static void Main()
    {
        Console.WriteLine("Enter the Bible verse you want to memorize: ");
        var bibleVerse = Console.ReadLine();

        var memorableWords = GetMemorableWordsFromVerse(bibleVerse);

        Console.WriteLine("\nMemorable Words from the Bible Verse:");
        foreach (var word in memorableWords)
        {
            Console.WriteLine(word);
        }
    }

    private static List<string> GetMemorableWordsFromVerse(string? verse)
    {
        // Split the verse into words
        var words = verse?.Split(new[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Filter out ignored words
        words = (words ?? throw new InvalidOperationException()).Where(word => !IgnoreWords.Contains(word.ToLower()))
            .ToArray();

        var memorableWords = words
            .Where(word => HasEmotionalSignificance(word) || IsDistinctive(word) || HasVisualImagery(word)).ToList();

        // Add some words based on repetition to aid memorization
        memorableWords.AddRange(words.Take(3));

        return memorableWords;
    }

    private static bool HasEmotionalSignificance(string word)
    {
        // Example: Check if the word contains emotionally significant terms
        string[] emotionallySignificantTerms = { "love", "eternal life", "forgiveness" };

        return emotionallySignificantTerms.Any(term => word.ToLower().Contains(term));
    }

    private static bool IsDistinctive(string word)
    {
        // Example: Check if the word has a distinct sound
        string[] distinctiveSounds = { "so", "world", "perish" };

        return distinctiveSounds.Contains(word.ToLower());
    }

    private static bool HasVisualImagery(string word)
    {
        // Example: Check if the word triggers visual imagery
        string[] wordsWithVisualImagery = { "Son", "believes" };

        return wordsWithVisualImagery.Contains(word);
    }
}