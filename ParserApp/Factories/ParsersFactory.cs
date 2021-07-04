using System;
using ParserApp.Enums;
using ParserApp.Interfaces;

namespace ParserApp.Factories
{
    /// <summary>
    /// Фабрика парсеров
    /// </summary>
    public class ParsersFactory
    {
        
        /// <summary>
        /// Получение парсера
        /// </summary>
        /// <param name="type">Тип парсера</param>
        /// <returns>Экземпляр парсера</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IWebPageParser GetParser(ParserType type)
        {
            return type switch
            {
                ParserType.Regex => new RegexParser(),
                ParserType.AgilityPack => new AgilitypackParser(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}