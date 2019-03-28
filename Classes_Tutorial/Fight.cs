using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Tutorial
{
    class Fight
    {
        // Быстрый удар  -->  Сильный удар
        // Сильный удар  -->  Контратака
        // Контратака    -->  Быстрый удар

        static Random rnd = new Random();
        static int miss = rnd.Next(100);

        public static void EnemyHit(Person person, Enemy enemy)
        {
            if (miss > person.Swift)
                person.Health = person.Health + (person.armor.Block / 2) - enemy.weapon.Damage;
            else
                Console.WriteLine($"{person.Name} смог уклониться!");
        }

        public static void HeroHit(Person person, Enemy enemy)
        {
            if (miss > enemy.Swift)
                enemy.Health = enemy.Health + (enemy.armor.Block / 2) - person.weapon.Damage;
            else
                Console.WriteLine($"{enemy.Name} смог уклониться!");
        }
        



    }
}
