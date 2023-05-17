namespace Bible_Verse_Memorization
{
    internal static class Program
    {
        private static readonly HashSet<string> IgnoreWords = new HashSet<string>
        {
            "the", "and", "that", "he", "his", "in", "but", "have", "is", "of", "be", "a", "to"
        };

        private static void Main()
        {
            Console.WriteLine("Enter the Bible verse you want to memorize: ");
            var bibleVerse = Console.ReadLine();

            if (bibleVerse == null) return;
            var memorableWords = GetMemorableWordsFromVerse(bibleVerse);

            Console.WriteLine("Memorable Words from the Bible Text:");
            DisplayMemorableWords(memorableWords);
        }

        private static List<string> GetMemorableWordsFromVerse(string verse)
        {
            var words = verse.Split(new[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Trim())
                .Where(word => !IgnoreWords.Contains(word.ToLower()))
                .ToList();

            var memorableWords = new List<string>();

            memorableWords.AddRange(GetWordsByCriteria(words, HasEmotionalSignificance, 3));
            memorableWords.AddRange(GetWordsByCriteria(words, IsDistinctive, 3));
            memorableWords.AddRange(GetWordsByCriteria(words, HasVisualImagery, 3));

            return memorableWords;
        }

        private static List<string> GetWordsByCriteria(List<string> words, Func<string, bool> criteria, int count)
        {
            var selectedWords = words.Where(criteria).Take(count).ToList();
            return selectedWords;
        }


        private static bool HasEmotionalSignificance(string word)
        {
            var emotionallySignificantTerms = new HashSet<string> { "love", "eternal life", "forgiveness" };
            return emotionallySignificantTerms.Any(term => word.ToLower().Contains(term));
        }

        private static bool IsDistinctive(string word)
        {
            var distinctiveSounds = new HashSet<string> { "so", "world", "perish" };
            return distinctiveSounds.Contains(word.ToLower());
        }

        private static bool HasVisualImagery(string word)
        {
            var wordsWithVisualImagery = new HashSet<string> { "Son", "believes" };
            return wordsWithVisualImagery.Contains(word);
        }


        private static void DisplayMemorableWords(IEnumerable<string> words)
        {
            Console.WriteLine(words.Any() ? "Memorable Words from the Bible Verse:" : "No memorable words found.");
        }
    }
}