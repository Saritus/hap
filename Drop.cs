using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using Android.Locations;
using System.Data;

namespace TouchWalkthrough
{
    class Drop
    {

        private int id { get; set; }
        private string description { get; set; }
        private Category category { get; set; }

        private DateTime startTime { get; set; }
        private DateTime endTime { get; set; }

        private ExtendedLocation location { get; set; }

        private bool followed { get; set; }
        private bool ignored { get; set; }

        public enum type { Event, Idea };

        public String name { get; set; }

        public Location pos { get; set; }

        public string imagepath { get; set; }

        public Drop()
        {
            // TODO: create a new drop
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