using Assets.Scripts;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public Object[] Sprites;

    // Tone
    // SoundObject initialized by Range
    public AudioSource Audio;

    private SpriteDisplayer _spriteDisplayer;

    public bool Speaking;

    private void Start()
    {
        _spriteDisplayer = gameObject.GetComponent<SpriteDisplayer>();
    }

    private int LastSpriteIndex = 0;
    private int FrameCount = 0;
    public void SetSprite()
    {
        if (Speaking && FrameCount == GameModel.SPEAKER_FRAMERATE)
        {
            // 50/50 chance between n+1 and n+2
            var newIndex = ((LastSpriteIndex + 1) % Sprites.Length);// + Random.Range(0, 1);
            _spriteDisplayer.SetSprite(Sprites[newIndex]);

            // TODO - Play Audio

            FrameCount = 0;
            LastSpriteIndex = newIndex;
        }

        if (!Speaking)
            _spriteDisplayer.SetSprite(Sprites[0]);

        FrameCount++;
    }
}