using System.Collections.Generic;

namespace ParserApp.Interfaces
{
    /// <summary>
    /// Интерфейс парсеров веб страниц
    /// </summary>
    public interface IWebPageParser
    {
        /// <summary>
        /// Метод возвращающий контент веб страницы
        /// </summary>
        /// <param name="url">Ссылка на веб страницу</param>
        /// <returns>Строка очищенная от символов и тегов</returns>
        public string ParseWebPage(string url);
        
        /// <summary>
        /// Метод подсчёта уникальных строк
        /// </summary>
        /// <param name="clearString">Строка со словами</param>
        /// <returns>Словарь со словами и их количеством</returns>
        public Dictionary<string, int> GetWordsAndCounts(string clearString);
    }
}