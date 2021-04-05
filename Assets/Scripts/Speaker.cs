using Assets.Scripts;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public Object[] Sprites;
    public AudioClip VoiceClip;

    private SpriteDisplayer _spriteDisplayer;
    private AudioSource _audioSource;

    public bool Speaking;

    private void Awake()
    {
        _spriteDisplayer = gameObject.GetComponent<SpriteDisplayer>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private int LastSpriteIndex = 0;
    private int FrameCount = 0;
    public void SetSprite()
    {
        if (Speaking && FrameCount >= GameModel.SPEAKER_FRAMERATE)
        {
            var newIndex = ((LastSpriteIndex + 1) % Sprites.Length);
            _spriteDisplayer.SetSprite(Sprites[newIndex]);

            _audioSource.PlayOneShot(VoiceClip);

            FrameCount = 0;
            LastSpriteIndex = newIndex;
        }

        if (!Speaking && Sprites.Length > 0)
            _spriteDisplayer.SetSprite(Sprites[0]);

        FrameCount++;
    }

    public void HideSprite()
    {
        _spriteDisplayer.HideSprite();
    }
}