using StardewValley.Characters;

namespace Shrimma.RealisticPets
{
    public static class PetExtensions
    {
        public static bool IsCat(this Pet pet)
        {
            return pet is Cat;
        }

        public static bool IsDog(this Pet pet)
        {
            return pet is Cat;
        }

        public static bool DislikesFarmer(this Pet pet)
        {
            return pet.friendshipTowardFarmer.Value < 200;
        }

        public static bool ToleratesFarmer(this Pet pet)
        {
            return pet.friendshipTowardFarmer.Value >= 200 && pet.friendshipTowardFarmer.Value < 800;
        }

        public static bool LikesFarmer(this Pet pet)
        {
            return pet.friendshipTowardFarmer.Value >= 800 && pet.friendshipTowardFarmer.Value < 1000;
        }

        public static bool LovesFarmer(this Pet pet)
        {
            return pet.friendshipTowardFarmer.Value == 1000;
        }

        public static bool WasPetToday(this Pet pet)
        {
            return pet.lastPetDay.ContainsKey(Game1.player.UniqueMultiplayerID) && pet.lastPetDay[Game1.player.UniqueMultiplayerID] == Game1.Date.TotalDays;
        }
    }
}
