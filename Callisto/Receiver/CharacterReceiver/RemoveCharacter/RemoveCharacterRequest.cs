﻿using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.CharacterReceiver.RemoveCharacter
{
    public class RemoveCharacterRequest: IRequest
    {
        public string characterId;
    }
}
