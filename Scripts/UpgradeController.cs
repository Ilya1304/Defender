using UnityEngine;
using UnityEngine.UI;

namespace Defender
{
    public class UpgradeController : MonoBehaviour
    {
        private const string HealthGrade = "healthGrade";

        [SerializeField] private int _healthGradePrice = 5;
        [SerializeField] private int _healthGrade = 0;
        [SerializeField] private Corn _corn;
        [SerializeField] private Text _healthGradeText;

        private void Awake()
        {
            _healthGrade = PlayerPrefs.GetInt(HealthGrade, 0);
        }

        private void Update()
        {
            _healthGradeText.text = _healthGradePrice.ToString();
        }

        public void OnClickUpgradeHealth()
        {
            if (_corn.TrySpendCrystals(_healthGradePrice))
            {
                _healthGrade++;
                PlayerPrefs.SetInt(HealthGrade, _healthGrade);
                PlayerPrefs.Save();
                _corn.ReculculateHealth();
            }
        }
    }
}