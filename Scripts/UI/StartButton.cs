using UnityEngine;
using UnityEngine.SceneManagement;

namespace Defender
{
    public class StartButton : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }

}