using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver.CharactersOnMap
{
    public class CharactersOnMapRequest: IRequest
    {
        public HashSet<Character> characters;
    }
}
