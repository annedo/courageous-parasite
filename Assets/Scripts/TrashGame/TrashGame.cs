using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.TrashGame
{
    public class TrashGame : MonoBehaviour
    {
        public Text MoneyText;
        public Text TimerText;

        public List<TrashObject> TrashObjects;
        public List<MoneyObject> MoneyObjects;

        public double CurrentMoney = 0;

        // Start is called before the first frame update
        void Start()
        {
            SpawnObjects();
        }

        private float Timer = 0f;
        private int CurrentTime = 0;
        // Update is called once per frame
        void Update()
        {
            Timer += Time.deltaTime;
            CurrentTime = GameModel.TRASH_GAME_TIME_LIMIT - (int)Math.Round(Timer % 60, 0);

            MoneyText.text = string.Format("{0}{1:N2}", GameModel.CurrencySymbol, CurrentMoney);
            TimerText.text = CurrentTime.ToString();

            if (CurrentTime <= 0)
            {
                GameModel.CurrentMoney += CurrentMoney;
                SceneManager.LoadScene("MainScene");
            }
        }

        private void SpawnObjects()
        {
            // TrashObjects
            for (int i = 0; i < GameModel.TRASH_GAME_TRASH_COUNT; i++)
            {
                var trash = Instantiate(TrashObjects[Random.Range(0, TrashObjects.Count)]);
                trash.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                trash.transform.localScale = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                //trash.transform.rotation = new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                var renderer = trash.GetComponent<SpriteRenderer>();
                renderer.sortingOrder = 1;
            }

            // MoneyObjects
            for (int i = 0; i < GameModel.TRASH_GAME_VALUABLES_COUNT; i++)
            {
                var valuable = Instantiate(MoneyObjects[Random.Range(0, MoneyObjects.Count)]);
                valuable.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                //trash.transform.localScale = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                //trash.transform.rotation = new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
        }
    }
}