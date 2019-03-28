using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes_Tutorial
{
    class Program
    {
        /// <summary>
        /// Список брони
        /// </summary>
        static List<Armor> ArmorList = new List<Armor>()
        {
                new Armor {Name = "Без брони",          Block = 0,      Price = 0},
                new Armor {Name = "Крепкая одежда",     Block = 5,      Price = 10},
                new Armor {Name = "Шкура Влада",        Block = 15,     Price = 15},
                new Armor {Name = "Кожаная броня",      Block = 20,     Price = 25},
                new Armor {Name = "Железная броня",     Block = 25,     Price = 30},
                new Armor {Name = "Стальная броня",     Block = 35,     Price = 40},
                new Armor {Name = "Закалённая броня",   Block = 45,     Price = 50},
                new Armor {Name = "Элитная броня",      Block = 55,     Price = 65},
                new Armor {Name = "Легендарная броня",  Block = 70,     Price = 85},
                new Armor {Name = "Мифическая броня",   Block = 90,     Price = 100},
        };

        /// <summary>
        ///  Список оружия
        /// </summary>
        static List<Weapon> WeaponList = new List<Weapon>()
        {
                new Weapon {Name = "Кулаки",        Damage = 5,     Price = 0},
                new Weapon {Name = "Крепкая палка", Damage = 10,    Price = 10},
                new Weapon {Name = "Нож",           Damage = 15,    Price = 20},
                new Weapon {Name = "Кинжал",        Damage = 20,    Price = 30},
                new Weapon {Name = "Боевой топор",  Damage = 25,    Price = 40},
                new Weapon {Name = "Меч",           Damage = 30,    Price = 50},
                new Weapon {Name = "Копьё",         Damage = 35,    Price = 60},
                new Weapon {Name = "Секира",        Damage = 40,    Price = 70},
                new Weapon {Name = "Меч Огня",      Damage = 50,    Price = 85},
                new Weapon {Name = "Посох Звезды",  Damage = 60,    Price = 100}
        };






        /// <summary>
        /// Броня животных
        /// </summary>
        static List<Armor> AnimalArmor = new List<Armor>()
        {
                new Armor {Name = "Пушок",              Block = 0,      Price = 0},
                new Armor {Name = "Короткая шерсть",    Block = 5,      Price = 10},
                new Armor {Name = "Шерсть",             Block = 15,     Price = 15},
                new Armor {Name = "Толстая шесть",      Block = 20,     Price = 25}
        };

        /// <summary>
        /// Оружие животных
        /// </summary>
        static List<Weapon> AnimalWeapon = new List<Weapon>()
        {
                new Weapon {Name = "Лапки",         Damage = 1,     Price = 0},
                new Weapon {Name = "Укус",          Damage = 10,    Price = 0},
                new Weapon {Name = "Толчок",        Damage = 15,    Price = 0},
                new Weapon {Name = "Рога",          Damage = 20,    Price = 0},
                new Weapon {Name = "Мощные когти",  Damage = 25,    Price = 0},
        };
        

        static void Main(string[] args)
        {
           



            string heroName="";
            Person hero = new Person(EnterName(out heroName), 50, 20, 14.5, ArmorList[0], WeaponList[0], 0);

            Forest(hero);







        }

        #region Имя героя
        /// <summary>
        /// Ввод имени героя и проверка на корректность
        /// </summary>
        /// <param name="heroName">введённое имя</param>
        static string EnterName(out string heroName)
        {
            bool correct = false;
            heroName = "";

            while (!correct)
            {
                Console.Clear();
                Console.Write("Введите Имя героя: ");
                heroName = Console.ReadLine();

                if (heroName.Length == 0)
                {
                    Console.WriteLine("Поле не заполнено!");
                    Console.ReadKey(true);
                }
                else if (heroName.Length >= 16)
                {
                    Console.WriteLine("Имя слишком длинное!");
                    Console.ReadKey(true);
                }
                else
                    correct = true;
            }
            Console.Clear();
            return heroName;
        }
        #endregion


        // Локация ЛЕС
        static void Forest(Person person)
        {

            List<Enemy> enemyList = new List<Enemy>()
            {
                new Enemy ("Заяц", 10, 2, 33, AnimalArmor[0], AnimalWeapon[0], 1),      
                new Enemy ("Лиса", 15, 7, 20, AnimalArmor[1], AnimalWeapon[1], 3),                         
                new Enemy ("Волк", 20, 10, 13, AnimalArmor[1], AnimalWeapon[1], 5), 
                new Enemy ("Задира", 30,15,10,ArmorList[0],WeaponList[0], 5),
                new Enemy ("Кабан", 40,30,15,AnimalArmor[2],AnimalWeapon[2], 10),
                new Enemy ("Олень", 35, 25, 20.5, AnimalArmor[1] ,AnimalWeapon[3], 10),
                new Enemy ("Разбойник", 50, 30, 18, ArmorList[1], WeaponList[1], 12),
                new Enemy ("Вор", 60, 40, 25, ArmorList[2], WeaponList[3], 15),
                new Enemy ("Дезертир", 65, 40, 15, ArmorList[4], WeaponList[4], 20),
                new Enemy ("Медведь", 80, 60, 5, AnimalArmor[3], AnimalWeapon[4], 10)
            };

            Random rnd = new Random();

            int e = rnd.Next(5);

            while (person.Health>0 && enemyList[e].Health > 0)
            {
                Console.Clear();
                Info(person, enemyList[e]);

                Action(person, HeroAction(person), enemyList[e], EnemyAction(enemyList[e]));
                Console.ReadKey(true);
            }

            Console.Clear();
            Info(person, enemyList[e]);
            if (person.Health >= 0)
            {
                Console.WriteLine("Вы Выиграли! Вам удалось найти {0} монет!", enemyList[e].Money);
            }
            else
                Console.WriteLine("Вы так же ничтожны, как создатель этой игры! ");


        }




        // вывод информации о состоянии героя и врага
        static void Info(Person person, Enemy enemy)
        {
            Console.WriteLine($"[ {person.Name} ]".PadRight(30,' ') + $"[ {enemy.Name} ]\n" +
                              $"Здоровье: {person.Health}".PadRight(30, ' ') + $"Здоровье: {enemy.Health}\n" +
                              $"Шанс уклонения: {person.Swift}%".PadRight(30, ' ') + $"Шанс уклонения: {enemy.Swift}%\n" +
                              $"Оружие: {person.weapon.Name}".PadRight(30, ' ') + $"Оружие: {enemy.weapon.Name}\n" +
                              $"Броня: {person.armor.Name}".PadRight(30, ' ') + $"Оружие: {enemy.armor.Name}\n" +
                              $"Монеты: {person.Money}".PadRight(30, ' ') + "Монеты: ?\n" +
                              $"ЖИЗНЕННАЯ СИЛА: {person.LiveStrieght}".PadRight(30, ' ') + $"ЖИЗНЕННАЯ СИЛА: {person.LiveStrieght}{new string(' ', 18 - person.LiveStrieght.ToString().Length)}\n\n");
        }
        



        // Действие ВРАГА
        static int EnemyAction(Enemy enemy, int first = 4)
        {
            Random rnd = new Random();

            int choice = rnd.Next(2)+1; // случайный выбор действия
                               
            

            Console.Write(enemy.Name+" выбрал: ");
            switch (choice)
            {
                case (1):
                    Console.WriteLine("1 - Быстрый удар".PadRight(25, ' '));
                    break;

                case (2):
                    Console.WriteLine("2 - Сильный удар".PadRight(25, ' '));
                    break;

                case (3):
                    Console.WriteLine("3 - Контратака".PadRight(25, ' '));
                    break;
            }

            return choice;
        }

        // Действие ГЕРОЯ
        static int HeroAction(Person person)
        {
            Console.WriteLine("1 - Быстрый удар (выигрывает против Сильного удара)\n" +
                              "2 - Сильный удар (выигрывает против Контратаки)\n" +
                              "3 - Контратака (выигрывает против Быстрого удара)\n");

            Console.Write( person.Name+" Выбрал: ");

            var HeroChoice = Console.ReadKey(true).Key;
            while (HeroChoice != ConsoleKey.D1 && HeroChoice != ConsoleKey.D2 && HeroChoice != ConsoleKey.D3)
            {
                HeroChoice = Console.ReadKey(true).Key;
            }

            switch (HeroChoice)
            {
                case (ConsoleKey.D1):
                    Console.Write("1 - Быстрый удар".PadRight(25, ' '));
                    return 1;
                    break;

                case (ConsoleKey.D2):
                    Console.Write("2 - Сильный удар".PadRight(25, ' '));
                    return 2;
                    break;


                case (ConsoleKey.D3):
                    Console.Write("3 - Контратака".PadRight(25, ' '));
                    return 3;
                    break;

                default:
                    return 3;
                    break;
                    
            }


        }

        // Действие
        static void Action(Person person, int heroAction, Enemy enemy, int enemyAction)
        {
            if(heroAction == enemyAction)
            {
                Fight.HeroHit(person, enemy);
                Fight.EnemyHit(person, enemy);
            }
            else if ((heroAction == 1 && enemyAction == 2) || (heroAction == 2 && enemyAction == 3) || (heroAction == 3 && enemyAction == 1))
                Fight.HeroHit(person, enemy);
            else if ((heroAction == 1 && enemyAction == 3) || (heroAction == 3 && enemyAction == 2) || (heroAction == 2 && enemyAction == 1))
                Fight.EnemyHit(person, enemy);
                
        }

    }
}