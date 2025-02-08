using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Monster
    {
        //класс содержит инфу о хп монстра и хранит сво-во
        public int Health { get; set; }
        public Monster(int health)
        {
            Health = health;
        }
    }
}
