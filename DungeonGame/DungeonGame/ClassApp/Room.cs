using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ClassApp
{
    public class Room
    {
        public RoomEvent Event { get; set; }
        public Room(int eventType)
        {
            Event = (RoomEvent)eventType;
        }
    }
    enum RoomEvent
    {
        Empty,
        Monster,
        Trap,
        Chest,
        Merchant,
        Boss
    }
}
