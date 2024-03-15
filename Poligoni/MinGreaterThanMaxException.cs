using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligoni
{
    internal class MinGreaterThanMaxException : Exception
    {
        public MinGreaterThanMaxException() 
        {
            
        }
        public MinGreaterThanMaxException(string message)
        : base(message)
        {

        }

        public MinGreaterThanMaxException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
