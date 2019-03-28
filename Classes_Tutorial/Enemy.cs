using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Tutorial
{
    class Enemy:Being
    {
        public Enemy(string EName, int EHealth, int ELiveSreight, double ESwift, Armor Earmor, Weapon Eweapon, int EMoney) : base(EName, EHealth, ELiveSreight, ESwift, Earmor, Eweapon, EMoney)
        {

        }

    }
}
