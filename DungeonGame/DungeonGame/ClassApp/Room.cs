using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Room
    {
        //класс для комнат с обработчиком его событий
        public RoomEvent Event { get; set; }
        public Room(int eventType)
        {
            Event = (RoomEvent)eventType;
        }
    }
    public enum RoomEvent
    {
        //вариации возможных объектов, ктр можно встретить в подземке
        Empty,
        Monster,
        Trap,
        Chest,
        Merchant,
        Boss
    }
}
