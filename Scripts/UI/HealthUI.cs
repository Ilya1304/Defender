using UnityEngine;
using UnityEngine.UI;

namespace Defender
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Corn _corn;
        [SerializeField] private Text _text;

        private void Update()
        {
            _text.text = _corn.Health.ToString();
        }
    }
}