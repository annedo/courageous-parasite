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
        MoneyText.text = string.Format("{0}{1:N2}", GameModel.CurrencySymbol, GameModel.CurrentMoney);
    }
}
