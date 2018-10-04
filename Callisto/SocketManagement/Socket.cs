using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto
{
    public class Socket
    {
        public Guid Guid { get; set; }

        public Socket(Guid guid)
        {
            Guid = guid;
        }

    }
}
