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

        public static void Log(params object[] message) => Log(5f, message);
        public static void LogWarning(params object[] message) => LogWarning(5f, message);
        public static void LogError(params object[] message) => LogError(5f, message);

        public static void Log(float messageTimeOnScreen, params object[] message) => 
            LogMessage(messageTimeOnScreen, Color.white, 18, message);

        public static void LogWarning(float messageTimeOnScreen, params object[] message) => 
            LogMessage(messageTimeOnScreen, Color.yellow, 18, message);

        public static void LogError(float messageTimeOnScreen, params object[] message) => 
            LogMessage(messageTimeOnScreen, Color.red, 18, message);

        public static void LogMessage(float messageTimeOnScreen, Color32 color, float fontSize, params object[] message)
        {
            var debugMessage = 
                Instantiate(Debug._debugMessage, Debug._debugMessages.transform);
            debugMessage.GetComponent<DebugMessageScript>().AssignValues(string.Join("", message), color, messageTimeOnScreen, fontSize);
            debugMessage.transform.SetParent(Debug._debugMessages.transform);
        }
    }
}
