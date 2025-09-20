using UnityEngine;

namespace Defender
{
    public class SaveController : MonoBehaviour
    {
        public void ClearSave()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        public static void SaveLevel(int level)
        {
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.Save();
        }

        public static void SaveCrystals(int crystals)
        {
            PlayerPrefs.SetInt("crystals", crystals);
            PlayerPrefs.Save();
        }
    }
}