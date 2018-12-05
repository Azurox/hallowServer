using Callisto.Receiver.Common;
using System.Collections.Generic;
using Callisto.Database.Models.CharacterModel;

namespace Callisto.Receiver.AccountReceiver.Characters
{
    public class CharactersRequest: IRequest
    {
        public List<Character> characters;
    }
}
