using UnityEngine;

namespace Assets.Scripts.TrashGame
{
    public class MoneyObject : MonoBehaviour
    {
        public double Value = 0;

        private TrashGame trashGame;
        private AudioSource AudioSource;
        private void Start()
        {
            trashGame = FindObjectOfType(typeof(TrashGame)) as TrashGame;
            AudioSource = gameObject.GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            trashGame.CurrentMoney += Value;
            AudioSource.Play();
            Destroy(gameObject);
        }
    }
}
