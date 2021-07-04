using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using NLog;
using ParserApp.Interfaces;

namespace ParserApp
{
    /// <summary>
    /// Реализация парсера с использованием HTML AgilityPack
    /// </summary>
    public class AgilitypackParser : IWebPageParser
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Сохранение HTML страницы
        /// </summary>
        /// <param name="site"></param>
        public void SaveHTMLPages(string site)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string directory = Directory.GetCurrentDirectory();
                    string html = client.DownloadString(site.ToString());
                    File.WriteAllText(directory + @"\" + "Site" + ".html", html);
                    Console.WriteLine("File save");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                logger.Error(e.ToString);
            }
        }
        
        public string ParseWebPage(string url)
        {
            SaveHTMLPages(url);
            Console.WriteLine("Words of - " + url);
            HtmlWeb htmlWeb = new HtmlWeb();
            try 
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error : " + e.ToString());
                logger.Error(e.ToString);
                return null;
            }
        }

        public Dictionary<string, int> GetWordsAndCounts(string clearString)
        {
            var res = new Dictionary<string, int>();

            foreach (var word in clearString.Split
                (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1)) 
            {
                if(word == "")
                    continue;
                var count = 0;
                res.TryGetValue(word, out count);
                res[word] = count + 1;
            }
            return res;
        }
    }
}