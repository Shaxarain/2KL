using System;

namespace elevator2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в лифт.\nТы можешь выбрать этаж набрав номер (с 1 по 5).\nКоманда open откроет дверь, close закроет, если есть возможность.\nКоманда go запустит движение, stop... ну ты понял.\n У тебя есть право выбора и во время движения, но не делай глупостей.");
            object choice = Console.ReadLine();
            if (choice < 0 || choice > 25)
            {

            }
            switch (choice)
            {
                case "go":
                    Console.WriteLine("Погнали");
                    break;
            }
        }
    }
}
