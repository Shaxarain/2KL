using System;

namespace elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поздравляю! Перед тобой первый (и скорее всего последний) клавиатурный лифт!\nТеперь слушай инструктаж.\nКоманда open открывает двери, close - закрывает, если есть возможность.\nКоманда go запустит движение.\ncomeon - впустит новых пассажиров, goaway - позволит выйти.\nУ тебя есть право выбора и во время движения, но не делай глупостей.\nКоманда end значит, что ты накатался и пора валить.\nАх, да. Я не катаю тех, кто даёт неверные команды.\nТак где тебя подобрать?");
            Elevator.start();
        }
        public class Elevator
        {
            static int floor = 25; //кол-во этажей.
            static int startfloor = 1; //этаж, на котором стоит лифт.
            static int endfloor; //куда надо попасть.
            static int carrying = 5; //грузоподъёмность в людях (не больше 5 челов).
            static int alotof = 0; //реальное количество людишек
            static bool opendoor = true; // состояние дверей true = можно открыть.
            static bool work = true; //Чтобы свалить.
            public static void uroboros()
            {
                do
                {
                    control();
                } while (work != false);
            }
            public static void control()
            {
                Console.WriteLine("Что дальше?");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "go":
                        start();
                        break;
                    case "end":
                        end();
                        break;
                    case "Спасибо":
                        Console.WriteLine("Оу, эм... пожалуйста.");
                        control();
                        break;
                    case "open":
                        open();
                        break;
                    case "close":
                        close();
                        break;
                    case "comeon":
                        comeon();
                        break;
                    case "goaway":
                        goaway();
                        break;
                }
            }
            public static void open()
            {
                if (opendoor == true)
                {
                    Console.WriteLine("[Двери открыты]");
                    control();
                }
                else
                {
                    Console.WriteLine("Эй, чё делаешь. Я тут еду вообще-то.[Двери не открылись]");
                }
            }
            public static void close()
            {
                if (opendoor == false)
                {
                    Console.WriteLine("Двери итак закрыты...");
                }
                else
                {
                    Console.WriteLine("Двери закрылись.");
                    control();
                }
            }
            public static void start()
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
                    comeon();
                }
            }
            public static void comeon()
            {
                if (opendoor == true)
                {
                    Console.WriteLine("А сколько вас? Больше 5 не беру.");
                    alotof += Convert.ToInt32(Console.ReadLine());
                    if (alotof > carrying)
                    {
                        Console.WriteLine("Я лифт, а не грузоподъёмный кран! Кыш!");
                        end();
                    }
                    else if (alotof == carrying)
                    {
                        Console.WriteLine("Прям впритык. Надеюсь, канат не выдержит...");
                        move();
                    }
                    else
                    {
                        Console.WriteLine("На легке!");
                        move();
                    }
                }
                else
                {
                    Console.WriteLine("Я на ходу людишек не подбираю!");
                }
            }
            public static void goaway()
            {
                Console.WriteLine("Сколько выходит?");
                alotof -= Convert.ToInt32(Console.ReadLine());
                if (opendoor == true)
                {
                    if (alotof < 0)
                    {
                        Console.WriteLine("Слышь... Ты думаешь раз я лифт, что считать не умею?!!");
                        end();
                    }
                    else
                    {
                        Console.WriteLine("Ну и счастливого пути...");
                        if (alotof != 0)
                        {
                            control();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Чё, прям на ходу хотите выйти? Регламент запрещает так делать...");
                }
            }
            public static void move()
            {
                opendoor = false;
                Console.WriteLine("Мы начинаем движение. Ты можешь поменять этаж или продолжить движение - просто жми enter.");
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
                opendoor = true;
                control();
            }
            public static void end()
            {
                Console.WriteLine("[Лифт самоуничтожился]");
            }
        }
    }
}
