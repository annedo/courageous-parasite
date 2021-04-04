using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGear : MonoBehaviour
{
    public List<NotControlledGear> notControlledGears;
    public Text MoneyText;
    public Text TimerText;

    private float zRotate = 2.5f;
    private AudioSource gearClick;
    // Start is called before the first frame update
    void Start()
    {
        gearClick = gameObject.GetComponent<AudioSource>();
    }

    private float Timer = 0f;
    private int CurrentTime = 0;
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        CurrentTime = GameModel.GEAR_GAME_TIME_LIMIT - (int)Math.Round(Timer % 60, 0);

        MoneyText.text = $"${CurrentMoney}";
        TimerText.text = CurrentTime.ToString();

        if (CurrentTime <= 0)
        {
            GameModel.CurrentMoney += CurrentMoney;
            SceneManager.LoadScene("MainScene");
        }
    }

    private int CurrentMoney = 0;
    private int GearClickCount = 0;
    private void OnMouseDown()
    {
        GearClickCount++;
        gameObject.transform.rotation *= Quaternion.Euler(0, 0, zRotate);

        notControlledGears.ForEach(x => x.Rotate(-zRotate));

        gearClick.Play();

        if (GearClickCount == GameModel.GEAR_GAME_CLICKS_FOR_ONE_DOLLAR)
        {
            CurrentMoney++;
            GearClickCount = 0;
        }
    }
}
