using UnityEngine;

namespace Defender
{
    public class Corn : MonoBehaviour
    {
        [field: SerializeField] public int StartHealth { get; private set; } = 10;
        [field: SerializeField] public int UpgredeHealth { get; private set; } = 2;

        public int Health { get; private set; }
        public int Crystals { get; private set; }

        private void Awake()
        {
            LoadGameData();
        }

        public void TakeDamage()
        {
            if (Health <= 0) return;

            Health -= 1;
        }

        private void LoadGameData()
        {
            int healthGrade = PlayerPrefs.GetInt("healthGrade", 0);
            Health = StartHealth + (UpgredeHealth * healthGrade);
            Crystals = PlayerPrefs.GetInt("crystals", 0);
        }

        public void AddCrystals(int value)
        {
            Crystals += value;
            SaveController.SaveCrystals(Crystals);
        }

        public bool TrySpendCrystals(int value)
        {
            if (Crystals < value) return false;

            Crystals -= value;
            SaveController.SaveCrystals(Crystals);
            return true;
        }

        public void ReculculateHealth()
        {
            int helthGrate = PlayerPrefs.GetInt("healthGrade", 0);
            Health = StartHealth + (UpgredeHealth + helthGrate);
        }
    }
}