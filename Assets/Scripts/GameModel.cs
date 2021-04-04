using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameModel
    {
        public static CharacterName CurrentNpc;

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
    }

    public enum CharacterName
    {
        DukeTheCeo, // PC
        Cog1, // NPCs 
        what3,
        what4
    }
}
