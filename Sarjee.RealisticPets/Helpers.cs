using Netcode;
using StardewValley;
using StardewValley.Characters;

namespace Shrimma.RealisticPets
{
    public static class Helpers
    {        
        public static bool HasPet()
        {
            return Game1.MasterPlayer.hasPet();
        }

        public static Pet GetPet()
        {
            return Game1.MasterPlayer.getPet();            
        }                                           
    }
}
