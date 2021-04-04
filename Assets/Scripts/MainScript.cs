using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = $"${GameModel.CurrentMoney}";
    }
}
