using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Upgrades
{
    [CreateAssetMenu(fileName = "Upgrades Config", menuName = "Configs/Upgrades", order = 1)]

    public class UpgradesConfig : ScriptableObject
    {
        [TabGroup("Upgrades", "Power")]
        [SerializeField]
        [ListDrawerSettings(ShowIndexLabels = true)]
        private Stat[] _powerStatList;        
        
        [TabGroup("Upgrades", "Health")]
        [SerializeField]
        [ListDrawerSettings(ShowIndexLabels = true)]
        private Stat[] _healthStatList;        
        
        public Stat[] PowerStatList => _powerStatList;
        public Stat[] HealthStatList => _healthStatList;
    }
}