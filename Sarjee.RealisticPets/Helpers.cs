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
        
        public static bool HasCat()
        {            
            if (HasPet())
            {
                var pet = GetPet();
                return pet is Cat;
            }

            return false;
        }        

        public static bool HasDog()
        {
            if (HasPet())
            {
                var pet = GetPet();
                return pet is Dog;
            }

            return false;
        }

        public static bool DislikesFarmer(Pet pet)
        {
            return pet.friendshipTowardFarmer.Value < 200;
        }

        public static bool ToleratesFarmer(Pet pet)
        {
            return pet.friendshipTowardFarmer.Value >= 200 && pet.friendshipTowardFarmer.Value < 800;
        }

        public static bool LikesFarmer(Pet pet)
        {
            return pet.friendshipTowardFarmer.Value >= 800 && pet.friendshipTowardFarmer.Value < 1000;
        }

        public static bool LovesFarmer(Pet pet)
        {
            return pet.friendshipTowardFarmer.Value == 1000;
        }

        public static bool WasPetToday(Pet pet)
        {
            return pet.lastPetDay.ContainsKey(Game1.player.UniqueMultiplayerID) && pet.lastPetDay[Game1.player.UniqueMultiplayerID] == Game1.Date.TotalDays;
        }            
    }
}
