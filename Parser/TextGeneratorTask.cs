
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    internal static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var phrase = phraseBeginning.Split(' ').ToList();
            for (int i = 0; i < wordsCount; i++)
            {
                if (phrase.Count >= 2)
                {
                    var key = phrase[phrase.Count - 2] + " " + phrase[phrase.Count - 1];
                    if (nextWords.ContainsKey(key))
                    {
                        phrase.Add(nextWords[key]);
                        continue;
                    }    
                }
                if (nextWords.ContainsKey(phrase[phrase.Count - 1]))
                    phrase.Add(nextWords[phrase[phrase.Count - 1]]);
                else break;
            }
            var result = string.Join(" ",phrase);
            return result;
        }
    }
}