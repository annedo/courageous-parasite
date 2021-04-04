using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum CharacterName
    {
        DukeTheCeo, // PC
        Cog1, // NPCs 
        what3,
        what4
    }

    public static class GameModel
    {
        public static CharacterName CurrentNpc;

        public static double CurrentMoney = 0;
        public static string CurrencySymbol = "₴";

#pragma warning disable UNT0010 // MonoBehaviour instance creation
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
#pragma warning restore UNT0010 // MonoBehaviour instance creation

        /// <summary>
        /// The amount of frames between each sprite change for a speaker
        /// </summary>
        public const int SPEAKER_FRAMERATE = 50;

        /// <summary>
        /// Cog game
        /// The amount of money received from 1 click of the center gear.
        /// </summary>
        public const double GEAR_GAME_MONEY_PER_CLICK = 0.06;

        /// <summary>
        /// Cog game
        /// Time in seconds for a round of the cog game.
        /// </summary>
        public const int GEAR_GAME_TIME_LIMIT = 30;

        /// <summary>
        /// Trash game
        /// Time in seconds for a round of the trash game.
        /// </summary>
        public const int TRASH_GAME_TIME_LIMIT = 30;

        /// <summary>
        /// Trash game
        /// Amount of trash objects to spawn.
        /// </summary>
        public const int TRASH_GAME_TRASH_COUNT = 100;

        /// <summary>
        /// Trash game
        /// Amount of money objects to spawn.
        /// </summary>
        public const int TRASH_GAME_VALUABLES_COUNT = 15;
    }    
}
