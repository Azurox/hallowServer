using Callisto.Database.Models.Common;
using Callisto.Receiver.Common;

namespace Callisto.Receiver.MapReceiver.LoadMap
{
    public class LoadMapRequest: IRequest
    {
        public string mapName;
        public Position position;
    }
}
