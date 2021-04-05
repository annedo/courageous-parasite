using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class MainScript : MonoBehaviour
{
    public Text MoneyText;
    public string TalkToNode = "";

    // Start is called before the first frame update
    void Start()
    {
        var dialogueRunner = FindObjectOfType<DialogueRunner>();

        if (!dialogueRunner.IsDialogueRunning)
        {
            if (this.TalkToNode != null)
            {
                FindObjectOfType<DialogueRunner>().StartDialogue(this.TalkToNode);
            }
            var audioSource = GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = string.Format("{0}{1:N2}", GameModel.CurrencySymbol, GameModel.CurrentMoney);
    }
}
