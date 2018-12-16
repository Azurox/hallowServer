using Callisto.Database.Models.Common;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver.moveTo
{
    public class IllegalMovementRequest: IRequest
    {
        public Position position;
    }
}
