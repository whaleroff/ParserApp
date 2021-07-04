using System.Collections.Generic;
using NUnit.Framework;
using ParserApp;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        /// <summary>
        /// Тест метода для очистки текста с помощью регулярного выражения
        /// </summary>
        [Test]
        public void RegexParserTest()
        {
            RegexParser parser = new RegexParser();
            var testFile = "html1.txt";
            var clearString = parser.ParsFromFile(testFile);
            var testDictionary = new Dictionary<string, int>()
            {
                {"Test", 1},
                {"Тест", 1},
                {"сайт", 1},
                {"Контент", 1},
                {"Аптека", 1},
                {"Аптеки", 2},
                {"Тут", 1},
                {"тоже", 1},
                {"есть", 1},
                {"текст", 1},
                {"И", 1},
                {"даже", 1},
                {"тут", 1},
                {"я", 1},
                {"напишу", 1},
                {"про", 1}
            };
            var dictionary = parser.GetWordsAndCounts(clearString);
            Assert.AreEqual(testDictionary, dictionary);
        }
    }
}