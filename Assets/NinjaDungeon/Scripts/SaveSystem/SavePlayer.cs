using ExperienceSystem;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class SavePlayer
    {
        [JsonProperty("player")]
        public PlayerData Player { get; }

        public SavePlayer(PlayerData player)
        {
            Player = player;
        }
    }
}