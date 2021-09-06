using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton4
    {
        public string MyProperty { get; set; }
        private Singleton4()
        {
            MyProperty = System.Guid.NewGuid().ToString();
        }

        public static Singleton4 Instance { get { return Nested.instance; } }

        private class Nested
        {
            // 显式静态构造告诉C＃编译器
            // 未标记类型BeforeFieldInit
            static Nested()
            {
            }

            internal static readonly Singleton4 instance = new Singleton4();
        }
    }
}
