using System.Collections.Generic;
using System.Linq;
namespace TextAnalysis
{
    internal static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var dictionaryReapet = new Dictionary<string, Dictionary<string, int>>();
            SetBiagram(dictionaryReapet, text);
            SetTrigram(dictionaryReapet, text);
            return GetFinalGram(dictionaryReapet);
        }

        private static void SetBiagram(Dictionary<string, Dictionary<string, int>> dictionaryReapet, 
            List<List<string>> text)
        {
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Count - 1; j++)
                {
                    string first = text[i][j];
                    string second = text[i][j + 1];

                    if (dictionaryReapet.ContainsKey(first))
                    {
                        if (dictionaryReapet[first].ContainsKey(second))
                            dictionaryReapet[first][second]++;
                        else dictionaryReapet[first][second] = 1;
                    }
                    else dictionaryReapet[first] = new Dictionary<string, int> { [second] = 1 };
                }
            }
        }

        private static void SetTrigram(Dictionary<string, Dictionary<string, int>> dictionaryReapet, 
            List<List<string>> text)
        {
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Count - 2; j++)
                {
                    string first = text[i][j] + " " + text[i][j + 1];
                    string second = text[i][j + 2];

                    if (dictionaryReapet.ContainsKey(first))
                    {
                        if (dictionaryReapet[first].ContainsKey(second))
                            dictionaryReapet[first][second]++;
                        else dictionaryReapet[first][second] = 1;
                    }
                    else dictionaryReapet[first] = new Dictionary<string, int> { [second] = 1 };
                }
            }
        }

        private static Dictionary<string, string> GetFinalGram(Dictionary<string, Dictionary<string, int>> dictionary)
        {
            var dictionaryGram = new Dictionary<string, string>();
            foreach (var item in dictionary)
                dictionaryGram[item.Key] = GetMostSecond(item.Value);
            return dictionaryGram;
        }

        private static string GetMostSecond(Dictionary<string, int> pair)
        {
            string mostSecond = pair.ElementAt(0).Key;
            foreach (var item in pair)
                if (pair[mostSecond] < item.Value || 
                    pair[mostSecond] == item.Value && string.CompareOrdinal(mostSecond, item.Key) > 0)
                    mostSecond = item.Key;
            return mostSecond;
        }
    }
}