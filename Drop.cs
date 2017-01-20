using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    public class Drop
    {
        // Internal settings
        public int id { get; private set; }
        public DateTime lastChange { get; private set; }

        // Creator settings
        public string name
        {
            get
            {
                return name;
            }
            set
            {
                lastChange = DateTime.Now;
                name = value;
            }
        }

        public Category category
        {
            get
            {
                return category;
            }
            set
            {
                lastChange = DateTime.Now;
                category = value;
            }
        }
        public string description
        {
            get
            {
                return description;
            }
            set
            {
                lastChange = DateTime.Now;
                description = value;
            }
        }

        public DateTime startTime
        {
            get
            {
                return startTime;
            }
            set
            {
                lastChange = DateTime.Now;
                startTime = value;
            }
        }

        public ExtendedLocation location
        {
            get
            {
                return location;
            }
            set
            {
                lastChange = DateTime.Now;
                location = value;
            }
        }

        public string picturePath
        {
            get
            {
                return picturePath;
            }
            set
            {
                lastChange = DateTime.Now;
                picturePath = value;
            }
        }

        // User settings
        public bool followed { get; set; }
        public bool ignored { get; set; }

        public Drop(int id, string name, Category category, string description, DateTime startTime, ExtendedLocation location, string picturePath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.location = location;
            this.picturePath = picturePath;
        }

        public void update(Drop newDrop)
        {
            this.id = newDrop.id;
            this.name = newDrop.name;
            this.description = newDrop.description;
            this.category = newDrop.category;
            this.startTime = newDrop.startTime;
            this.location = newDrop.location;
            this.picturePath = newDrop.picturePath;
        }

        public Drop(int id, string name, Category category, string description, DateTime startTime, ExtendedLocation location)
            : this(id, name, category, description, startTime, location, null)
        {

        }

        public Drop(int id, string name, Category category, string description, DateTime startTime)
            : this(id, name, category, description, startTime, null, null)
        {

        }

        public Drop(int id)
        {
            this.id = id;
        }

        public Drop()
        {

        }

        public void show()
        {
            Console.WriteLine(id + ", " + name);
        }

        public void showDetail()
        {
            Console.WriteLine("Details: " + id + ", " + name + ", " + description);
        }
    }
}
