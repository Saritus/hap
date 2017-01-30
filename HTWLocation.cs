using Android.Locations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace TouchWalkthrough
{
    public class HTWLocation
    {
        static Dictionary<string, Point> roomTable;

        public string name { get; set; }

        public Building building { get; set; }

        public int floor { get; set; }

        public string room { get; set; }

        public Location location { get; set; }

        public Point position { get; set; }

        public HTWLocation(string room)
        {
            if (roomTable == null)
            {
                fillDictionary();
            }

            position = roomTable[room];

            name = room;

            Regex regex = new Regex("[A-Z][0-9]+[a-z]?");
            if (regex.IsMatch(room))
            {
                this.building = (Building)Enum.Parse(typeof(Building), room[0].ToString());
                this.floor = int.Parse(room[1].ToString());
                this.room = room.Substring(1);
            }
            else
            {
                // No regular room
            }
        }

        public HTWLocation(Building building, string room)
            : this(building.ToString() + room)
        {
        }

        public HTWLocation()
        {

        }

        public override string ToString()
        {
            return name;
        }

        private void fillDictionary()
        {
            roomTable = new Dictionary<string, Point>();
            roomTable["Z136b"] = new Point(3, 4);
        }
    }
}
