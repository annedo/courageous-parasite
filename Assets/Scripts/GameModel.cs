using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum CharacterName
    {
        TAHM, // PC
        CETTALON, // NPCs 
        PAUL,
        CAPTAIN
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
                CharacterName.TAHM, new Speaker()
                {
                    Sprites = Resources.LoadAll("Player/Sprites", typeof(Sprite)),
                    VoiceClip = Resources.Load("Player/voice") as AudioClip
                }
            },
            {
                CharacterName.CETTALON, new Speaker()
                {
                    Sprites = Resources.LoadAll("Cettalon/Sprites", typeof(Sprite)),
                    VoiceClip = Resources.Load("Cettalon/voice") as AudioClip
                }
            },
            {
                CharacterName.PAUL, new Speaker()
                {
                    Sprites = Resources.LoadAll("Paul/Sprites", typeof(Sprite)),
                    VoiceClip = Resources.Load("Paul/voice") as AudioClip
                }
            },
            {
                CharacterName.CAPTAIN, new Speaker()
                {
                    Sprites = Resources.LoadAll("Captain/Sprites", typeof(Sprite)),
                    VoiceClip = Resources.Load("Captain/voice") as AudioClip
                }
            },
        };
#pragma warning restore UNT0010 // MonoBehaviour instance creation

        /// <summary>
        /// The amount of frames between each sprite change for a speaker
        /// </summary>
        public const int SPEAKER_FRAMERATE = 15;

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

        /// <summary>
        /// Skin game
        /// The amount of money received from one skin piece.
        /// </summary>
        public const double SKIN_GAME_MONEY_PER_PIECE = 1.39;

        /// <summary>
        /// Skin game
        /// Time in seconds for a round of the skin game.
        /// </summary>
        public const int SKIN_GAME_TIME_LIMIT = 30;
    }    
}
