using System;
using NLog;
using NLog.Targets;
using ParserApp.Enums;
using ParserApp.Factories;

namespace ParserApp
{
    
    /// <summary>
    /// Меню для пользователя
    /// </summary>
    public class Menu
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Запуск меню
        /// </summary>
        public void Start()
        {
            
            Console.WriteLine("Выберите формат обработки ");
            int select = 1;
            try
            {
                while (select != 0)
                {
                    Console.WriteLine("Обработка с помощью реулягного выражения(1)\n" +
                                      "Обработка с помощью HTMLAgilityPack(2)\n" +
                                      "Выход(0)");
                    select = Int32.Parse(Console.ReadLine());

                    switch (select)
                    {
                        case 1:
                        {
                            LaunchPars(ParserType.Regex);
                            break;
                        }
                        case 2:
                        {
                            LaunchPars(ParserType.AgilityPack);
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Неверное значение");
                            logger.Info(" Неверное значение в switch-case");
                            break;
                        }
                        case 0:
                        {
                            Console.WriteLine("Выход");
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Это не число!");
                logger.Error(ex);
            }
        }
        
        /// <summary>
        /// Запуск парсинга
        /// </summary>
        /// <param name="type">Тип парсера</param>
        public void LaunchPars(ParserType type)
        {
            Console.WriteLine("Введите адрес");
            var address = Console.ReadLine();
            if (Validator.ValidateURL(address) == false)
                return;
            var factry = new ParsersFactory();
            var parser = factry.GetParser(type);
            var clear = parser.ParseWebPage(address);
            var dictionary = parser.GetWordsAndCounts(clear);
            foreach (var pair in dictionary)
            {
                Console.Write(pair.Key + "    " + pair.Value);
                Console.WriteLine();
            }
        }
    }
}