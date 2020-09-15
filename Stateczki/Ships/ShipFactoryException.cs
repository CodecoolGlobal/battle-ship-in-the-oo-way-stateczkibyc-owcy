using System;
using System.Collections.Generic;
using System.Text;

namespace Stateczki.Ships
{
    public class ShipFactoryException : Exception
    {
        public ShipFactoryException(string message)
            : base(message)
        {
        }
    }
}
