using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }

        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        [TestCase("hello   world", new[] { "hello", "world" })]
        [TestCase(" hello world ", new[] { "hello", "world" })]
        [TestCase("", new string[] { })]
        [TestCase("''", new[] { "" })]
        [TestCase("' '", new[] { " " })]
        [TestCase("hello 'world'", new[] { "hello", "world" })]
        [TestCase("'hello' world", new[] { "hello", "world" })]
        [TestCase("hello'world'", new[] { "hello", "world" })]
        [TestCase("'\"\"'", new[] { "\"\"" })]
        [TestCase("\"''\"", new[] { "''" })]
        [TestCase("'hello", new[] { "hello" })]
        [TestCase("'hello ", new[] { "hello " })]
        [TestCase("'\\\\hello'", new[] { "\\hello" })]
        [TestCase("'\\\\'", new[] { "\\" })]
        [TestCase("'\\\"\\\"'", new[] { "\"\"" })]
        [TestCase("\"\\\"\\\"\"", new[] { "\"\"" })]
        [TestCase("'\\'\\''", new[] { "''" })]
        public static void RunTests(string input,
                            string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Подумайте как можно использовать ReadQuotedField и Token в этой задаче.
        public static List<Token> ParseLine(string line)
        {
            var fields=new List<Token>();
            int index = 0;
            while (index < line.Length)
            {
                if (line[index] == '\'' || line[index] == '\"')
                {
                    var token=ReadQuotedField(line, index);
                    index = token.GetIndexNextToToken();
                    fields.Add(token);
                }
                else if(line[index] == ' ')
                    index=SkipWhiteSpace(line, index);
                else
                {
                    var token = ReadField(line, index);
                    index = token.GetIndexNextToToken();
                    fields.Add(token);
                }
            }
            return fields;
        }

        private static int SkipWhiteSpace(string line,int startIndex)
        {
            int nextIndex = startIndex;
            while(nextIndex<line.Length&&line[nextIndex] == ' ')
                nextIndex++;
            return nextIndex;
        }

        private static Token ReadField(string line, int startIndex)
        {
            int length = 0;
            var value = new StringBuilder();
            while(length+startIndex < line.Length && line[startIndex+length]!=' ' 
                && line[startIndex + length] != '\'' && line[startIndex+length]!='\"')
            {
                value.Append(line[startIndex + length]);
                length++;
            }
            return new Token(value.ToString(), startIndex,length);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}