using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Single
    {
        private static Single instance;

        public static Single GetInstance()
        {
            if (instance == null)
                instance = new Single();
            return instance;
        }
    }
}
