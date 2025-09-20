using UnityEngine;

namespace Defender
{
    public class ExitButton : MonoBehaviour
    {
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

            Application.Quit();
        }
    }
}