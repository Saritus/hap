using System;
using System.Collections.Generic;

namespace TouchWalkthrough
{
    abstract class FakeConnector
    {
        List<Drop> dummyDrops;

        private static bool connect()
        {
            return true;
        }

        private static void close()
        {

        }

        public static List<Drop> getNewDrops(DateTime lastUpdate)
        {
            return null;
        }

        public static bool saveNewDrop(Drop newDrop)
        {
            return false;
        }
    }
}