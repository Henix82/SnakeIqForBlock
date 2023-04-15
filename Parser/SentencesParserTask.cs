using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentences=GetSentences(text);
            foreach(var sentence in sentences)
                if (sentence.Any(Char.IsLetter))
                {
                    sentencesList.Add(new List<string>());
                    var words=sentence.Split(GetSplitSim(sentence),StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                        sentencesList[sentencesList.Count - 1].Add(word);
                }
            return sentencesList;
        }

        private static string[] GetSentences(string text)
        {
            var splitSim = new char[] { '.', '!', '?', ':', ';', '(', ')' };
            var sentences=text.Split(splitSim, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sentences.Length; i++)
                sentences[i] = sentences[i].Trim().ToLower();
            return sentences;
        }

        private static char[] GetSplitSim(string sentence)
        {
            var splitSim = new List<char>();
            for (int i = 0; i < sentence.Length; i++)
                if ((sentence[i] < 'a' || sentence[i] > 'z') && sentence[i] != '\'')
                    if(splitSim.All(s => sentence[i] != s))
                        splitSim.Add(sentence[i]);       
            return splitSim.ToArray();
        }
    }
}
