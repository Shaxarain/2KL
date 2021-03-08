using System;

namespace elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поздравляю! Перед тобой первый (и скорее всего последний) клавиатурный лифт!\nТеперь слушай инструктаж.\nКоманда open откроет дверь, close закроет, если есть возможность.\nКоманда go запустит движение, stop... ну ты понял.\nУ тебя есть право выбора и во время движения, но не делай глупостей.\nКоманда end значит, что ты накатался и пора валить.\nАх, да. Я не катаю тех, кто даёт неверные команды.\nТак где тебя подобрать?");
            Elevator.go();
        }
        public class Elevator
        {
            static int floor = 25; //кол-во этажей.
            static int startfloor = 1;
            static int endfloor;
            static int carrying = 5; //грузоподъёмность в людях (не больше 5 челов).
            static bool opendoor = true; // состояние дверей true = открыты.
            static bool work = true; //Чтобы свалить.
            public static void uroboros()
            {
                do
                {
                    Elevator.control();
                } while (work != false);
            }
            public static void control()
            {
                Console.WriteLine("Что дальше?");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "go":
                        Elevator.go();
                        break;
                    case "end":
                        end();
                        break;
                    case "Спасибо":
                        Console.WriteLine("Оу, эм... пожалуйста.");
                        control();
                        break;
                }
            }
            public static void go()
            {
                Console.WriteLine("На какой этаж пожаловать? Если чё их всего 25.");
                endfloor = Convert.ToInt32(Console.ReadLine());
                if (floor < endfloor || floor < 0)
                {
                    Console.WriteLine("Это за пределами моих возможностей...");
                    end();
                }
                else
                {
                    Console.WriteLine("Как скажешь, мешок с костями...");
                    move();
                }
            }
            public static void weight()
            {
                Console.WriteLine("Кстати, а сколько вас? Больше 5 не беру.");
                int y = Convert.ToInt32(Console.ReadLine());
                if (y > carrying)
                {
                    Console.WriteLine("Я лифт, а не грузоподъёмный кран! Кыш!");
                    end();
                }
                else if (y == carrying)
                {
                    Console.WriteLine("Прям впритык. Надеюсь, канат выдержит...");
                }
                else
                {
                    Console.WriteLine("На легке!");
                }
            }
            public static void move()
            {
                Console.WriteLine("Мы начинаем движение. Ты можешь поменять этаж или ехать куда хотел - просто жми enter.");
                if (startfloor < endfloor)
                {
                    for(int i = Elevator.startfloor; startfloor!=endfloor; startfloor++)
                    {
                        Console.WriteLine("Лифт на {0} этаже.", startfloor);
                        control();
                    }
                } else if (startfloor > endfloor)
                {
                    for (int i = Elevator.startfloor; startfloor != endfloor; startfloor--)
                    {
                        Console.WriteLine("Лифт на {0} этаже.",startfloor);
                        control();
                    }
                }
                else
                {
                    Console.WriteLine("Ой какое совпадение, а я уже тут.");
                }
                Console.WriteLine("Лифт на {0} этаже. Мы на месте.", startfloor);
                control();
            }
            public static void end()
            {
                Console.WriteLine("[Двери лифта открылись на первом попавшемся же этаже и механическая рука вытолкнула Вас прочь.]");
            }
        }
    }
}
