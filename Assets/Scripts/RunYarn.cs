using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class RunYarn : MonoBehaviour
{
    public YarnProgram yarnScript;

    public DialogueRunner dialogueRunner;

    public Speaker PlayerCharacter;
    public Speaker NonPlayerCharacter; // TODO - Read in name from scene parameter

    private bool isPlayerTalking = false;
    private bool isNonPlayerTalking = false;

    public Text PlayerText;
    public Text NonPlayerText;
    // Start is called before the first frame update
    void Awake()
    {
        // Pass Money to yarnScript        

        PlayerCharacter.Audio = GameModel.PlayerSpeaker[CharacterName.DukeTheCeo].Audio;
        PlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.DukeTheCeo].Sprites;
        NonPlayerCharacter.Audio = GameModel.PlayerSpeaker[CharacterName.Cog1].Audio;
        NonPlayerCharacter.Sprites = GameModel.PlayerSpeaker[CharacterName.Cog1].Sprites;

        dialogueRunner.Add(yarnScript);
    }

    private int FrameCount = 0;
    // Update is called once per frame
    void Update()
    {
        if (_currentLine == null && FrameCount > 100)
            dialogueRunner.StartDialogue("Wits"); // TODO - Scene parameter NPC name

        if (_currentLine != null)
        {
            if (_currentLine.Length == 1)
            {
                // Get current speaker PC or NPC
                isPlayerTalking = _currentLine[0] == CharacterName.DukeTheCeo.ToString()[0];
                isNonPlayerTalking = !isPlayerTalking; // TODO - check NPC names for proper value
                PlayerCharacter.Speaking = isPlayerTalking;
                NonPlayerCharacter.Speaking = isNonPlayerTalking;
            }

            PlayerCharacter.SetSprite();
            NonPlayerCharacter.SetSprite();
        }

        if (isPlayerTalking)
        {
            PlayerText.text = _currentLine;
            NonPlayerText.text = string.Empty;
        }            
        else
        {
            NonPlayerText.text = _currentLine;
            PlayerText.text = string.Empty;
        }            

        FrameCount++;
    }

    private string _currentLine;
    /// <summary>
    /// Get current string being 'Read' by Yarn. 
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void UpdateCurrentLine(string line)
        => _currentLine = line;

    /// <summary>
    /// Begin voice and animation for current speaker.
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void OnLineStart()
    {
        
    }

    /// <summary>
    /// Stop voice and animation for current speaker.
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void OnLineFinishDisplaying()
    {
        PlayerCharacter.Speaking = false;
        NonPlayerCharacter.Speaking = false;
    }

    /// <summary>
    /// Stop voice and animation for current speaker.
    /// Called by <see cref="DialogueUI"/> in Scene.
    /// </summary>
    public void OnDialogueEnd()
    {
        // TODO - Return to MainScene
    }
}
