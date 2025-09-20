using UnityEngine;
using UnityEngine.SceneManagement;

namespace Defender
{
    public class MenuButton : MonoBehaviour
    {
        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }
    }

}