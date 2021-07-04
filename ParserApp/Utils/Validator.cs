using System;
using System.Text.RegularExpressions;
using NLog;

namespace ParserApp
{
    /// <summary>
    /// Класс с методами валидации
    /// </summary>
    public static class Validator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Валидация URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool ValidateURL(string url)
        {
            string pattern = @"^(http|http(s)?://)+([\w-]+\.)+(\[\?%&=]*)?";
            if (Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("url подтвержден");
                logger.Info(" url подтвержден");
                return true;
            }
            else
            {
                Console.WriteLine("Некорректный url");
                logger.Info(" Некорректный url");
                return false;
            }
        }
    }
}