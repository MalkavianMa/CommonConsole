using System;
using System.Collections.Generic;
using System.Text;

namespace DisposeClass
{
    /// <summary>

    /// The class to show three disposal function

    /// </summary>

    public class DisposeClass : IDisposable

    {
        public void Close()

        {
            Console.WriteLine("Close called!");

        }



        ~DisposeClass()

        {
            Console.WriteLine("Destructor called!");

        }



        #region IDisposable Members



        public void Dispose()

        {
            // TODO:  Add DisposeClass.Dispose implementation

            Console.WriteLine("Dispose called!");

            GC.SuppressFinalize(this);

        }



        #endregion

    }
}
