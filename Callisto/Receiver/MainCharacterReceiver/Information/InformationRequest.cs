using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver.Information
{
    public class InformationRequest: IRequest
    {
        public Character character;
    }
}
