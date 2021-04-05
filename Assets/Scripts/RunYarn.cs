using Assets.Scripts;
using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class RunYarn : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public Speaker PlayerCharacter;
    public Speaker NonPlayerCharacter;

    void Awake()
    {
        LoadCharacter(CharacterName.TAHM);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentLine != null && _currentLine.Length > 0 && _currentLine.Length < 13)
        {
            if (_currentLine.Contains(CharacterName.TAHM.ToString()))
                PlayerCharacter.Speaking = true;
            else if (_currentLine.Contains(CharacterName.CETTALON.ToString()))
            {
                LoadCharacter(CharacterName.CETTALON);
                NonPlayerCharacter.Speaking = true;
            }
            else if (_currentLine.Contains(CharacterName.PAUL.ToString()))
            {
                LoadCharacter(CharacterName.PAUL);
                NonPlayerCharacter.Speaking = true;
            }
            else if (_currentLine.Contains(CharacterName.CAPTAIN.ToString()))
            {
                LoadCharacter(CharacterName.CAPTAIN);
                NonPlayerCharacter.Speaking = true;
            }
        }

        PlayerCharacter.SetSprite();
        NonPlayerCharacter.SetSprite();
    }

    private string _currentLine;
    /// <summary>
    /// Get current string being 'Read' by Yarn. 
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void UpdateCurrentLine(string line)
        => _currentLine = line;

    /// <summary>
    /// Stop voice and animation for current speaker.
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void OnLineFinishDisplaying()
    {
        PlayerCharacter.Speaking = false;
        NonPlayerCharacter.Speaking = false;
    }

    private void LoadCharacter(CharacterName character)
    {
        switch (character)
        {
            case CharacterName.TAHM:
                PlayerCharacter.VoiceClip = GameModel.PlayerSpeaker[CharacterName.TAHM].VoiceClip;
                PlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.TAHM].Sprites;
                break;
            case CharacterName.CETTALON:
                NonPlayerCharacter.VoiceClip = GameModel.PlayerSpeaker[CharacterName.CETTALON].VoiceClip;
                NonPlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.CETTALON].Sprites;
                break;
            case CharacterName.PAUL:
                NonPlayerCharacter.VoiceClip = GameModel.PlayerSpeaker[CharacterName.PAUL].VoiceClip;
                NonPlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.PAUL].Sprites;
                break;
            case CharacterName.CAPTAIN:
                NonPlayerCharacter.VoiceClip = GameModel.PlayerSpeaker[CharacterName.CAPTAIN].VoiceClip;
                NonPlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.CAPTAIN].Sprites;
                break;
        }
    }

    // The method that gets called when '<<custom_wait>>' is run.
    private void CustomWait(string[] parameters, System.Action onComplete)
    {
        PlayerCharacter.Sprites = new Object[0];
        NonPlayerCharacter.Sprites = new Object[0];
        StartCoroutine(DoWait(onComplete));
    }

    private IEnumerator DoWait(System.Action onComplete)
    {
        yield return new WaitForSeconds(GameModel.GEAR_GAME_TIME_LIMIT);

        onComplete();
    }
}
