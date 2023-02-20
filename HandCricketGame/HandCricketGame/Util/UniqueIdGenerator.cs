using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketGame.Util
{
    public class UniqueIdGenerator
    {
        private static UniqueIdGenerator? _instance = null;

        private UniqueIdGenerator() { }

        public static UniqueIdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UniqueIdGenerator();
            }
            return _instance;
        }

        public string GetUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
