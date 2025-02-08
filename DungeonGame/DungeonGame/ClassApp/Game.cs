using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Game
    {
        //базовые статы перса, и не только перса, при запуске игры
        private Player player;
        private Room[] dungeonMap;
        private Random random;
        public Game()
        {
            //создание игрока и начало
            random = new Random();
            player = new Player();
            InitializeDungeon();
        }
        private void InitializeDungeon()
        {
            //создание комнат подземелья 
            dungeonMap = new Room[10];
            for (int i = 0; i < 9; i++)
            {
                dungeonMap[i] = new Room(random.Next(4)); // рандомайзер
            }
            dungeonMap[9] = new Room(4); // комната босса 
        }

        public void Start()
        {
            //стартуем подземелье 
            Console.WriteLine("Welcome to the Deep Dark Dungeon!");
            for (int i = 0; i < dungeonMap.Length; i++)
            {
                //проходка по комнатам 
                Console.WriteLine($"Ты вошел в комнату {i + 1}.");
                EnterRoom(dungeonMap[i]);
                if (player.Health <= 0)
                {
                    //определение статуса жив и прошел или проиграл 
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
            //обработчик комнат 
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
                        MeetMerchant();
                        break;
                    }
                case RoomEvent.Boss:
                    {
                        FightBoss();
                        break;
                    }
                default:
                    Console.WriteLine("Эта комната пуста.");
                    break;
            }
        }

        private void FightMonster()
        {
            //обработчик битвы с противником 
            Monster monster = new Monster(random.Next(20, 51));
            Console.WriteLine($"Появляется монстр с запасом здоровья {monster.Health} HP!");
            while (monster.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("Выбери свое оружие: 1 - Меч, 2 - Лук");
                string choice = Console.ReadLine();
                if (choice == "1" || (choice == "2" && player.Arrows > 0))
                {
                    //боевка и работа с оружием 
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
                    //получаем по щам 
                    int monsterDamage = random.Next(5, 16);
                    player.Health -= monsterDamage;
                    Console.WriteLine($"Монстр ранил тебя нанеся {monsterDamage} урона!");
                }
            }
            if (player.Health > 0) Console.WriteLine("Ты одолел монстра!");
        }

        private void HitTrap()
        {
            // надо смотреть под ноги, ловушки никто не отменял 
            int damage = random.Next(10, 21);
            player.Health -= damage;
            Console.WriteLine($"Ты попался в ловушку и потерял {damage} HP!");
        }
        private void OpenChest()
        {
            //ооо сокровища 
            Console.WriteLine("Для открыть сундука нужно разгадать загадку: сколько будет 2 + 2?\r\n?");
            string answer = Console.ReadLine();
            if (answer == "4")
            {
                //вспоминаем математику 
                Console.WriteLine("Правильно! Вы нашли зелье, 10 золотых монет и 5 стрел.");
                player.Potions++;
                player.Gold += 10;
                player.Arrows += 5;
            }
            else
            {
                //с матешей плохо 
                Console.WriteLine("Ответ неверный! Сундук остается запертым.");
            }
        }

        private void MeetMerchant()
        {
            //встречаем местного бизнес мена 
            Console.WriteLine("Торговец предлагает вам зелье за 30 золотых. Вы хотите его купить? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes" && player.Gold >= 30)
            {
                //богато жить не запретишь  
                player.Gold -= 30;
                player.Potions++;
                Console.WriteLine("Ты купил зелье!");
            }
            else
            {
                //ладно, все же запретили 
                Console.WriteLine("У вас недостаточно золота или вы решили не покупать его.");
            }
        }

        private void FightBoss()
        {
            //битва с глав гадом 
            Monster boss = new Monster(100);
            Console.WriteLine("Финальный босс появляется со 100 HP!");
            while (boss.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("Выбери свое оружие: 1 - Меч, 2 - Лук");
                string choice = Console.ReadLine();
                if (choice == "1" || (choice == "2" && player.Arrows > 0))
                {
                    //кто ты воин? лучник или мечник 
                    int damage = choice == "1" ? random.Next(10, 21) : random.Next(5, 16);
                    if (choice == "2") player.Arrows--;
                    boss.Health -= damage;
                    Console.WriteLine($"Ты ранил босса нанеся {damage} урона!");
                }
                else
                {
                    Console.WriteLine("Ты не можешь использовать лук без стрел!");
                    continue;
                }
                if (boss.Health > 0)
                {
                    //получаем по щам 
                    int bossDamage = random.Next(15, 26);
                    player.Health -= bossDamage;
                    Console.WriteLine($"Босс ранил тебя нанеся {bossDamage} урона!");
                }
            }
            //press f for глав гад 
            if (player.Health > 0) Console.WriteLine("Ты одолел босса!");
        }

    }
}
