using System.Collections;
using TMPro;
using UnityEngine;

namespace BananaUtils.OnScreenDebugger.Scripts
{
    public class DebugMessageScript : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private float _timeOnScreen;

    
        public void AssignValues(string text, Color color, float timeOnScreen, float size)
        {
            _timeOnScreen = timeOnScreen;
            _text.text = text;
            _text.color = color;
            _text.GetComponent<RectTransform>().sizeDelta = new Vector2(200, size);
        }
    
        private void Start()
        {
            StartCoroutine(DestroyMessageRoutine());
        }


        private IEnumerator DestroyMessageRoutine()
        {
            yield return new WaitForSeconds(_timeOnScreen);
            Destroy(gameObject);
        }
    }
}
