using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Singleton
    {
        private static Singleton instance;

        public string MyProperty { get; set; }


        private Singleton()
        {
            MyProperty = System.Guid.NewGuid().ToString();
        }
        
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
