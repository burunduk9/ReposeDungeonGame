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

        public void Start()
        {
            Console.WriteLine("Welcome to the Deep Dark Dungeon!");
            for (int i = 0; i < dungeonMap.Length; i++)
            {
                Console.WriteLine($"Ты вошел в комнату {i + 1}.");
                EnterRoom(dungeonMap[i]);
                if (player.Health <= 0)
                {
                    Console.WriteLine("Ты был повержен ...");
                    break;
                }
                if (i == 9 && player.Health > 0)
                {
                    Console.WriteLine("Поздравляю! Вы победили босса и выиграли игру!");
                }
            }
        }

        private void EnterRoom(Room room)
        {
            switch (room.Event)
            {
                case RoomEvent.Monster:
                    {
                        FightMonster();
                        break;
                    }
                case RoomEvent.Trap:
                    {
                        HitTrap();
                        break;
                    }
                case RoomEvent.Chest:
                    {
                        OpenChest();
                        break;
                    }
                case RoomEvent.Merchant:
                    {
                        //MeetMerchant();
                        break;
                    }
                case RoomEvent.Boss:
                    {
                        //FightBoss();
                        break;
                    }
                default:
                    Console.WriteLine("Эта комната пуста.");
                    break;
            }
        }

        private void FightMonster()
        {
            Monster monster = new Monster(random.Next(20, 51));
            Console.WriteLine($"Появляется монстр с запасом здоровья {monster.Health} HP!");
            while (monster.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("Выбери свое оружие: 1 - Меч, 2 - Лук");
                string choice = Console.ReadLine();
                if (choice == "1" || (choice == "2" && player.Arrows > 0))
                {
                    int damage = choice == "1" ? random.Next(10, 21) : random.Next(5, 16);
                    if (choice == "2") player.Arrows--;
                    monster.Health -= damage;
                    Console.WriteLine($"Ты ранил монстра нанеся {damage} урона!");
                }
                else
                {
                    Console.WriteLine("Ты не можешь использовать лук без стрел!");
                    continue;
                }
                if (monster.Health > 0)
                {
                    int monsterDamage = random.Next(5, 16);
                    player.Health -= monsterDamage;
                    Console.WriteLine($"Монстр ранил тебя нанеся {monsterDamage} урона!");
                }
            }
            if (player.Health > 0) Console.WriteLine("Ты одолел монстра!");
        }

        private void HitTrap()
        {
            int damage = random.Next(10, 21);
            player.Health -= damage;
            Console.WriteLine($"Ты попался в ловушку и потерял {damage} HP!");
        }
        private void OpenChest()
        {
            Console.WriteLine("Для открыть сундука нужно разгадать загадку: сколько будет 2 + 2?\r\n?");
            string answer = Console.ReadLine();
            if (answer == "4")
            {
                Console.WriteLine("Правильно! Вы нашли зелье, 10 золотых монет и 5 стрел.");
                player.Potions++;
                player.Gold += 10;
                player.Arrows += 5;
            }
            else
            {
                Console.WriteLine("Ответ неверный! Сундук остается запертым.");
            }
        }

    }
}
