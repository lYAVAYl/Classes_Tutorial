using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Tutorial
{
    public abstract class Being
    {
        // Имя, Здоровье, Оружие, Урон, Броня, Блок, Вер-ть уклонится

        public string Name;

        public int Health;
        public int LiveStrieght;

        public double Swift;

        public Armor armor = new Armor();
        public Weapon weapon = new Weapon();

        public int Money;
                

        public Being (string name, int health, int livestreight, double swift, Armor armor, Weapon weapon, int money)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(" Поле имени не может быть пустым! ");
            else
                Name = name;

            if (health <= 0)
                throw new ArgumentException(" Здоровье не может быть меньше или равно нулю! ");
            else
                Health = health;



            if (livestreight < 0)
                throw new ArgumentException(" Жизненная Сила не может быть меньше нуля! ");
            else
                LiveStrieght = livestreight;



            if (swift < 0)
                throw new ArgumentException(" Вероятность уклонения не может быть меньше 0! ");
            else
                Swift = swift;



            if (armor == null)
                throw new ArgumentException(" Броня отсутствует! ");
            else
                this.armor = armor;

            if (weapon == null)
                throw new ArgumentException(" Оружие отсутствует! ");
            else
                this.weapon = weapon;



            if (money < 0)
                throw new ArgumentException(" Деньги не могут быть <0 ");
            else
                Money = money;
        }


    }
}
