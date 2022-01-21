using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Characters;

namespace Shrimma.RealisticPets
{
    public class ModEntry : Mod
    {        
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Helper.Events.GameLoop.GameLaunched += this.GameLoop_GameLaunched;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoop_GameLaunched(object sender, GameLaunchedEventArgs e)
        {            
            this.Helper.Events.GameLoop.DayStarted += this.GameLoop_DayStarted;
            this.Helper.Events.GameLoop.DayEnding += this.GameLoop_DayEnding;
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
        {            
            if (Game1.IsMasterGame)
            {
                if (Helpers.HasPet())
                {
                    this.Monitor.Log($"{Game1.player.Name} has a pet.", LogLevel.Debug);
                    var pet = Helpers.GetPet();
                    if (pet.IsCat())
                    {                        
                        this.Monitor.Log($"It's a kitty that likes the farmer '{pet.friendshipTowardFarmer}', Last petted '{pet.lastPetDay[Game1.player.UniqueMultiplayerID]}'", LogLevel.Debug);                        
                    }
                    else if (pet.IsDog())
                    {                        
                        this.Monitor.Log($"It's a doge that likes the farmer '{pet.friendshipTowardFarmer}'", LogLevel.Debug);
                    }
                }
                else
                {
                    this.Monitor.Log($"{Game1.player.Name} doesn't have a pet. Sad times..", LogLevel.Debug);
                }
            }
        }

        private void GameLoop_DayEnding(object sender, DayStartedEventArgs e)
        {
            if (Game1.IsMasterGame)
            {
                if (Helpers.HasPet())
                {
                    var pet = Helpers.GetPet();
                    if (pet.IsCat())
                    {
                        this.Monitor.Log($"{Game1.player.Name} has a kitty!", LogLevel.Debug);
                        CatBehaviour.TriggerDailyRoutine(pet);
                    }
                    else if (pet.IsDog())
                    {
                        this.Monitor.Log($"{Game1.player.Name} has a doge!", LogLevel.Debug);
                        DogBehaviour.TriggerDailyRoutine(pet);
                    }
                }
                else
                {
                    this.Monitor.Log($"{Game1.player.Name} doesn't have a pet. Sad times.", LogLevel.Debug);
                }
            }
        }
    }
}
