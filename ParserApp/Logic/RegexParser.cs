using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using ParserApp.Interfaces;

namespace ParserApp
{
    /// <summary>
    /// Реализация парсера с использованием регулярных выражений
    /// </summary>
    public class RegexParser : IWebPageParser
    {
        private const string FileName = "data.txt";

        /// <summary>
        /// Сохранение файла из URL
        /// </summary>
        /// <param name="address"></param>
        private void SetFileByUrl(string address)
        {
            Console.WriteLine(GetUrlFile(address, FileName) ? "File saved" : "Error");
        }

        private static bool GetUrlFile(string address, string fileName)
        {
            var client = new WebClient {Credentials = CredentialCache.DefaultNetworkCredentials};

            try
            {
                client.DownloadFile(address, fileName);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод для парсинга из файла
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string ParsFromFile(string html)
        {
            string res = null;
            string pattern = @"<.*?>";
            StreamReader f = new StreamReader(html);
            while (!f.EndOfStream)
            {
                string stream = f.ReadLine();
                string bet;
                Regex regex = new Regex(pattern);
                bet = regex.Replace(stream, string.Empty);
                if (String.IsNullOrWhiteSpace(bet) == false)
                {
                    res = string.Concat(res, bet);
                }
            }

            f.Close();
            return res;
        }

        public string ParseWebPage(string url)
        {
            SetFileByUrl(url);
            string res = null;
            string pattern = @"<.*?>";
            StreamReader f = new StreamReader("data.txt");
            while (!f.EndOfStream)
            {
                string stream = f.ReadLine();
                string bet;
                Regex regex = new Regex(pattern);
                bet = regex.Replace(stream, string.Empty);
                if (String.IsNullOrWhiteSpace(bet) == false)
                {
                    res = string.Concat(res, bet);
                }
            }

            f.Close();
            return res;
        }

        public Dictionary<string, int> GetWordsAndCounts(string clearString)
        {
            var res = new Dictionary<string, int>();

            foreach (var word in clearString.Split
                (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1))
            {
                if (word == "")
                    continue;
                var count = 0;
                res.TryGetValue(word, out count);
                res[word] = count + 1;
            }

            return res;
        }
    }
}