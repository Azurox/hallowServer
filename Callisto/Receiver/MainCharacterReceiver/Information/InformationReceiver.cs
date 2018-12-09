using Callisto.Database.Models.CharacterModel;
using Callisto.Receiver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Receiver.MainCharacterReceiver.Information
{
    public class InformationReceiver: IReceiver
    {
        private readonly ICharacterRepository _characterRepository;

        public InformationReceiver(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }


        public async Task Listen(Socket socket, string data)
        {
            var character = await _characterRepository.GetCharacter(socket.volatileInformation.characterId);
            socket.Emit(InformationRequestAlias.INFORMATION, new InformationRequest()
            {
                character = character
            });
        }
    }
}
