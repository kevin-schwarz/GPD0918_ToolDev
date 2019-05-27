using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPD0918_ToolDev
{

    public interface IGameSerializer
    {

        void Serialize(Game _game, string _path);

        Game Deserialize(string _path);

    }

}
