using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Game
    {
        private Player player;
        private Room[] dungeonMap;
        private Random random;
        public Game()
        {
            random = new Random();
            player = new Player();
            InitializeDungeon();
        }
        private void InitializeDungeon()
        {
            dungeonMap = new Room[10];
            for (int i = 0; i < 9; i++)
            {
                dungeonMap[i] = new Room(random.Next(4)); // Randomly assign events to rooms
            }
            dungeonMap[9] = new Room(4); // Boss room
        }

    }
}
