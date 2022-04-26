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
        
        [TabGroup("Upgrades", "Speed")]
        [SerializeField]
        [ListDrawerSettings(ShowIndexLabels = true)]
        private Stat[] _speedStatList;        
        
        [TabGroup("Upgrades", "Armor")]
        [SerializeField]
        [ListDrawerSettings(ShowIndexLabels = true)]
        private Stat[] _armorStatList;

        public Stat[] PowerStatList => _powerStatList;
        public Stat[] SpeedStatList => _speedStatList;
        public Stat[] ArmorStatList => _armorStatList;
    }
}