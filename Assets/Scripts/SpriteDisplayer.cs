using UnityEngine;

namespace Assets.Scripts
{
    class SpriteDisplayer : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            spriteRenderer.sprite = _currentSprite;
        }

        private Sprite _currentSprite;
        public void SetSprite(Object sprite)
        {
            _currentSprite = sprite as Sprite;
            spriteRenderer.enabled = true;
        }

        public void HideSprite()
            => spriteRenderer.enabled = false;
    }
}
