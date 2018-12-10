using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;

namespace Callisto.Receiver.MapReceiver.LoadMap
{
    public class SpawnCharacter: IRequest
    {
        public Character character;
    }
}
