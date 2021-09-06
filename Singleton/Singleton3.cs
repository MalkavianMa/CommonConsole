using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
  public sealed class Singleton3
    {
        private static readonly Singleton3 instance = new Singleton3();
       // public string MyProperty { get; set; }
        private Singleton3()
        {
          //  MyProperty = System.Guid.NewGuid().ToString();
        }

        //static Singleton3()   {   } //去掉这句为饿汉模式

        public static Singleton3 GetInstance()
        {
            return instance;
        }
    }
}
