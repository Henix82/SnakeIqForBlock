using NUnit.Framework;
using System.Text;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("\"\\\\ef \\\"", 0, "\\ef \"", 8)]
        [TestCase("'as\\\\'hk", 0, "as\\", 6)]
        [TestCase("' aed\\'die", 0, " aed\'die", 10)]
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("\"a 'b' 'c' d\"", 0, "a 'b' 'c' d", 13)]
        [TestCase("'\"1\" \"2\" \"3\"'", 0, "\"1\" \"2\" \"3\"", 13)]
        [TestCase("abc \"def g h", 4, "def g h", 8)]
        [TestCase("'", 0, "", 1)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    internal class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            char quote = line[startIndex];
            var value = new StringBuilder();
            int length = 1;
            while (startIndex + length < line.Length)
            {
                if (line[startIndex + length] == quote)
                {
                    length++;
                    break;
                }
                if (line[startIndex + length] == '\\')
                {
                    if (line[startIndex + length + 1] == quote)
                    {
                        value.Append(quote);
                        length += 2;
                    }
                    else if (line[startIndex + length + 1] == '\\')
                    {
                        value.Append('\\');
                        length += 2;
                    }
                    else
                    {
                        value.Append(line[startIndex + length + 1]);
                        length += 2;
                    }
                }
                else value.Append(line[startIndex + length++]);
            }
            return new Token(value.ToString(), startIndex, length);
        }
    }
}