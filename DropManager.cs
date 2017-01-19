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
            drops.ForEach(drop => showDrop(drop));
        }

        public List<Drop> getFilteredDrops(Category[] filters)
        {
            return drops.Where(drop => filters.Contains(drop.category)).ToList();
        }

        public List<Drop> getFollowedDrops()
        {
            return drops.Where(drop => drop.followed).ToList();
        }

        public List<Drop> getNotIgnoredDrops()
        {
            return (from drop in drops where !drop.ignored select drop).ToList();
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