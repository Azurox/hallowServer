using Callisto.Database.Models.Common;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver.MoveCharacter
{
    public class MoveCharacterRequest: IRequest
    {
        public string characterId;
        public Position startPosition;
        public List<Position> path;
    }
}
