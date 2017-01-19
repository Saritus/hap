using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    class Drop
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
        public DateTime endTime
        {
            get
            {
                return endTime;
            }
            set
            {
                lastChange = DateTime.Now;
                endTime = value;
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

        public Drop(int id, string name, Category category, string description, DateTime startTime, DateTime endTime, ExtendedLocation location, string picturePath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.picturePath = picturePath;
        }

        public Drop(int id, string name, Category category, string description, DateTime startTime, DateTime endTime, ExtendedLocation location)
            : this(id, name, category, description, startTime, endTime, location, "")
        {

        }

        public Drop(int id)
        {
            this.id = id;
        }

        public Drop()
        {

        }

        public Drop(string filename)
        {
            // TODO: load a drop from a xml file
        }

        public Drop(DataRow row)
        {
            // TODO: create a new Drop from a datarow (SQL)
        }

        public bool save(string filename)
        {
            // TODO: save this drop to xml file
            XML.Save<Drop>(this, filename);
            return false;
        }
    }
}
