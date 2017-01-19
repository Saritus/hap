using Android.Locations;
using System;
using System.Data;

namespace TouchWalkthrough
{
    class Drop
    {

        // Global settings
        private int id { get; set; }
        private string name { get; set; }

        private string description { get; set; }
        private Category category { get; set; }

        private DateTime startTime { get; set; }
        private DateTime endTime { get; set; }

        private ExtendedLocation location { get; set; }

        private string picturePath { get; set; }

        // User settings
        private bool followed { get; set; }
        private bool ignored { get; set; }

        public Drop(int id, string name, string description, Category category, DateTime startTime, DateTime endTime, ExtendedLocation location, string picPath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.picturePath = picPath;
        }

        public Drop(string xmlfile)
        {
            // TODO: load a drop from a xml file
        }

        public Drop(DataRow row)
        {
            // TODO: create a new Drop from a datarow
        }

        public bool save(string filename)
        {
            // TODO: save this drop to xml file
            XML.Save<Drop>(this, filename);
            return false;
        }
    }
}
