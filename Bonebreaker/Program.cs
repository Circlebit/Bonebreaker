using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Framework.SetupConsole();
            
            Player Player = new Player(1, 1);

            World World_1 = new World(10, 10, Player);

            Framework.PrintMapFrame(World_1.Map);

            //TODO: Start a World

            //TODO: Player Movement - https://stackoverflow.com/questions/8898182/how-to-handle-key-press-event-in-console-application

            //TODO: Mainloop (per World)

        }
    }
}
