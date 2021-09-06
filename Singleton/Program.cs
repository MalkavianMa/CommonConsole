using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            //Thread thread = new Thread(Start);
            //Thread thread1 = new Thread(Start);
            //thread.Start();
            //thread1.Start();//这种多线程访问偶尔单例唯一  无法保证单例唯一

            //Thread thread = new Thread(Start2);
            //Thread thread1 = new Thread(Start2);
            //thread.Start();
            //thread1.Start();//


            //Thread thread = new Thread(Start3);
            // Thread thread1 = new Thread(Start3);//建议普遍使用的单例模式 不太懒 不使用锁 且线程安全



            // Thread thread = new Thread(Start4);
            // Thread thread1 = new Thread(Start4);//完全懒惰的实例化

            //  Thread thread = new Thread(Start5);
            //  Thread thread1 = new Thread(Start5);//net4<= 可以使用的方式 懒惰  可以检查是否已使用IsValueCreated 属性创建实例

            // thread.Start();
            // thread1.Start();//

            List<string> vs = new List<string>();
            vs.Add("");

                Console.WriteLine( vs.Any());

            Console.ReadKey();
        }

        public static void Start() {
            Singleton singleton = Singleton.GetInstance();//多线程并发访问 不能保证单例唯一
            Console.WriteLine(singleton.MyProperty);
        }

        public static void Start2()
        {
            Singleton2 singleton = Singleton2.GetInstance();//
            Console.WriteLine(singleton.MyProperty);
        }

        public static void Start3()
        {
            Singleton3 singleton ;//
           // Console.WriteLine(singleton.MyProperty);
        }


        public static void Start4()
        {
            Singleton4 singleton;//
           // Console.WriteLine(singleton.MyProperty);
        }

        public static void Start5()
        {
            Singleton5 singleton = Singleton5.Instance;//
           // Console.WriteLine(singleton.MyProperty);
        }
    }
}
