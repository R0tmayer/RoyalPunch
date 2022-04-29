using UnityEngine;

namespace Core.Upgrades
{
    public class StatLevelSaver
    {
        private const string _powerLevelPrefsKey = nameof(_powerLevelPrefsKey);
        private const string _healthLevelPrefsKey = nameof(_healthLevelPrefsKey);

        public int PowerLevel
        {
            get => PlayerPrefs.GetInt(_powerLevelPrefsKey, 0);
            private set => PlayerPrefs.SetFloat(_powerLevelPrefsKey, value);
        }

        public int HealthLevel
        {
            get => PlayerPrefs.GetInt(_healthLevelPrefsKey, 0);
            private set => PlayerPrefs.SetFloat(_healthLevelPrefsKey, value);
        }

        public void IncrementPowerLevel() => PowerLevel++;
        public void IncrementHealthLevel() => HealthLevel++;
    }
}