using UnityEngine;

namespace BananaUtils.OnScreenDebugger.Scripts
{
    public class OSDebug : MonoBehaviour
    {
        [SerializeField] private GameObject _debugMessage;
        [SerializeField] private GameObject _debugMessages;

        private static OSDebug _instance;

        public static OSDebug Debug
        {
            get
            {
                if (_instance == null)
                    _instance = new GameObject("OSDebug", typeof(OSDebug)).GetComponent<OSDebug>();
                return _instance;
            }

            private set
            {
                if (_instance != null && _instance != value)
                {
                    Destroy(value.gameObject);
                    return;
                }

                _instance = value;
            }
        }

        private void Awake() => _instance = GetComponent<OSDebug>();

        public void Log(float messageTimeOnScreen, params object[] message)
        {
            var debugMessage = 
                Instantiate(_debugMessage, _debugMessages.transform);
            debugMessage.GetComponent<DebugMessageScript>().AssignValues(string.Join("", message), Color.white, messageTimeOnScreen, 18);
            debugMessage.transform.SetParent(_debugMessages.transform);
        }

        public void LogWarning(float messageTimeOnScreen, params object[] message)
        {
            var debugMessage =
                Instantiate(_debugMessage, _debugMessages.transform);
            debugMessage.GetComponent<DebugMessageScript>().AssignValues(string.Join("", message), Color.yellow, messageTimeOnScreen, 18);
            debugMessage.transform.SetParent(_debugMessages.transform);
        }

        public void LogError(float messageTimeOnScreen, params object[] message)
        {
            var debugMessage = 
                Instantiate(_debugMessage, _debugMessages.transform);
            debugMessage.GetComponent<DebugMessageScript>().AssignValues(string.Join("", message), Color.red, messageTimeOnScreen, 18);
            debugMessage.transform.SetParent(_debugMessages.transform);
        }

        public void LogCustom(float messageTimeOnScreen, Color32 color, float fontSize, params object[] message)
        {
            var debugMessage = 
                Instantiate(_debugMessage, _debugMessages.transform);
            debugMessage.GetComponent<DebugMessageScript>().AssignValues(string.Join("", message), color, messageTimeOnScreen, fontSize);
            debugMessage.transform.SetParent(_debugMessages.transform);
        }
    }
}
