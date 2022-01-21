using StardewValley.Characters;

namespace Shrimma.RealisticPets
{
    public static class DogBehaviour
    {
        public static void TriggerDailyRoutine(Pet pet)
        {
            //TODO random
            bool hasActed = false;
            //do some specific actions depending on how loved pet is
            if (pet.LikesFarmer() || pet.LovesFarmer())
            {
                //TODO find a truffle????
                hasActed = true;
            }
            else if (pet.ToleratesFarmer())
            {
                hasActed = true;
            }
            else if (pet.DislikesFarmer())
            {
                //TODO something not so nice
                //dog poopy inside
                hasActed = true;
            }

            if (!hasActed)
            {
                //TODO fallback to some generic actions if we didn't do anything like based
                //dog poopy outside
            }
        }
    }
}
