using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            // Show destructor

            //Create();

            //Console.WriteLine("After created!");

            //CallGC();

            Run();

            Console.WriteLine("After Run!");

            CallGC();
            Console.ReadKey();

        }
        private static void Run()

        {
            using (DisposeClass myClass = new DisposeClass())

            {
                //other operation here

            }

        }

        private static void Create()

        {
            DisposeClass myClass = new DisposeClass();

        }

        private static void CallGC()

        {
            GC.Collect();

        }
    }
}
