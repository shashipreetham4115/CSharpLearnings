using MovieTicketBookingSystem.Presentation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBookingSystem.Util
{
    internal class UniqueIdGenerator
    {
        private static UniqueIdGenerator? _instance = null;
        private int Id = 100000;

        private UniqueIdGenerator() { }

        public static UniqueIdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UniqueIdGenerator();
            }
            return _instance;
        }

        public int GetUniqueId()
        {
            return Id++;
        }
    }
}
