using System;
using System.Collections.Generic;
using System.Linq;

namespace TouchWalkthrough
{
    class DropManager
    {
        public List<Drop> drops { get; set; }
        public DateTime lastTimestamp { get; private set; }
        //server daten

        public DropManager()
        {
            this.drops = createDummyDrops(5);
            foreach (Drop d in drops)
            {
                showDrop(d);
            }
        }

        public List<Drop> getDrops(Category[] filters)
        {
            //if all filters are active
            if (filters.Length == Enum.GetNames(typeof(Category)).Length)
            {
                return drops;
            }
            else
            {
                List<Drop> tempList = new List<Drop>();
                foreach (Drop drop in drops)
                {
                    if (filters.Contains(drop.category))
                    {
                        tempList.Add(drop);
                    }
                }
                return tempList;
            }
        }

        public List<Drop> getFollowedDrops()
        {
            List<Drop> tempList = new List<Drop>();
            foreach (Drop drop in drops)
            {
                if (drop.followed)
                    tempList.Add(drop);
            }
            return tempList;
        }

        public void ignoreDrop(Drop ev)
        {
            ev.ignored = true;
        }

        public void followDrop(Drop ev)
        {
            ev.followed = true;
        }

        public List<Drop> createDummyDrops(int i)
        {
            List<Drop> tempList = new List<Drop>();
            foreach (Category filter in Enum.GetValues(typeof(Category)))
            {
                for (int j = 0; j < i; j++)
                {
                    string f = Enum.GetName(typeof(Category), filter);
                    tempList.Add(new Drop(i, "Test" + f + i, filter, "Test" + f + i + "Description, ", DateTime.Today, DateTime.Now, new ExtendedLocation()));
                }
            }
            return tempList;
        }


        //server related
        public void updateDropList()
        {
            List<Drop> receivedDrops = new List<Drop>();
            receivedDrops = updateDropsSince(lastTimestamp);
            if (receivedDrops.Count > 0)
                drops.AddRange(receivedDrops);
            lastTimestamp = DateTime.Now;
        }

        public List<Drop> updateDropsSince(DateTime lastTimestamp)
        {
            List<Drop> receivedDrops = new List<Drop>();
            //TODO: frage bei server nach neuen events seit lastTimestamp
            return receivedDrops;
        }

        //Front end related
        public void showDrop(Drop ev)
        {
            Console.WriteLine(ev.id + ", " + ev.name);
        }

        public void showDropDetail(Drop ev)
        {
            Console.WriteLine("Details: " + ev.id + ", " + ev.name + ", " + ev.description);
        }
    }
}