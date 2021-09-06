using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Singleton2
    {
        private static Singleton2 instance;
        private static object _lock = new object();
        public string MyProperty { get; set; }

        private Singleton2()
        {
            MyProperty = System.Guid.NewGuid().ToString();

        }

        public static Singleton2 GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                    }
                }
            }
            return instance;
        }
    }
}
