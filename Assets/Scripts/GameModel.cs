using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameModel
    {
        public static CharacterName CurrentNpc;

        public static int CurrentMoney = 0;

        // Add more characters here
        public static IReadOnlyDictionary<CharacterName, Speaker> PlayerSpeaker 
            = new Dictionary<CharacterName, Speaker>()
        {
                {
                    CharacterName.DukeTheCeo, new Speaker()
                    {
                        Sprites = Resources.LoadAll("Player/Sprites", typeof(Sprite)),
                        Audio = Resources.Load("Player/voice") as AudioSource
                    }
                },
                {
                    CharacterName.Cog1, new Speaker()
                    {
                        Sprites = Resources.LoadAll("Cog1/Sprites", typeof(Sprite)),
                        Audio = Resources.Load("Cog1/voice") as AudioSource
                    }
                }
        };

        /// <summary>
        /// The amount of frames between each sprite change for a speaker
        /// </summary>
        public const int SPEAKER_FRAMERATE = 50;

        /// <summary>
        /// Cog game
        /// The amount of clicks of the center gear to get 1 dollar.
        /// </summary>
        public const int GEAR_GAME_CLICKS_FOR_ONE_DOLLAR = 15;

        /// <summary>
        /// Time in seconds for a round of the cog game.
        /// </summary>
        public const int GEAR_GAME_TIME_LIMIT = 60;
    }

    public enum CharacterName
    {
        DukeTheCeo, // PC
        Cog1, // NPCs 
        what3,
        what4
    }
}
