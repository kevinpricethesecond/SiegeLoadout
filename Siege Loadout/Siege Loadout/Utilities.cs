using System;
using TaleWorlds.Core;

namespace Siege_Loadout
{
    class Utilities
    {
        public static void PrintLine(string line)
        {
            InformationManager.DisplayMessage(new InformationMessage(line));
        }
    }
}
