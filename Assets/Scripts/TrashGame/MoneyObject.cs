using UnityEngine;

namespace Assets.Scripts.TrashGame
{
    public class MoneyObject : MonoBehaviour
    {
        public double Value = 0;

        private TrashGame trashGame;
        private void Start()
        {
            trashGame = FindObjectOfType(typeof(TrashGame)) as TrashGame;
        }

        private void OnMouseDown()
        {
            trashGame.CurrentMoney += Value;
            Destroy(gameObject);
        }
    }
}
