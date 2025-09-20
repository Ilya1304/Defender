using UnityEngine;
using UnityEngine.UI;

namespace Defender
{
    public class CrystalUI : MonoBehaviour
    {
        [SerializeField] private Corn _corn;
        [SerializeField] private Text _text;

        private void Update()
        {
            _text.text = _corn.Crystals.ToString();
        }
    }
}