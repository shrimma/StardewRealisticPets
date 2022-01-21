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
                    if (Helpers.HasCat())
                    {
                        var pet = Helpers.GetPet();
                        this.Monitor.Log($"It's a kitty that likes the farmer '{pet.friendshipTowardFarmer}', Last petted '{pet.lastPetDay[Game1.player.UniqueMultiplayerID]}'", LogLevel.Debug);                        
                    }
                    else if (Helpers.HasDog())
                    {
                        var pet = Helpers.GetPet();
                        this.Monitor.Log($"It's a doge that likes the farmer '{pet.friendshipTowardFarmer}'", LogLevel.Debug);
                    }
                }
                else
                {
                    this.Monitor.Log($"{Game1.player.Name} doesn't have a pet. Sad times..", LogLevel.Debug);
                }
            }
        }

        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }
    }
}
