using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Player
    {
        public int Health { get; set; } = 100;
        public int Potions { get; set; } = 3;
        public int Gold { get; set; } = 0;
        public int Arrows { get; set; } = 5;
    }
}
