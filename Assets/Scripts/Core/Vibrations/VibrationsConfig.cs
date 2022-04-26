using Lofelt.NiceVibrations;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

namespace Core.Vibrations
{
    [CreateAssetMenu(fileName = "Vibrations Config", menuName = "Configs/Vibrations", order = 1)]
    public class VibrationsConfig : ScriptableObject
    {
        [SerializeField] private HapticPatterns.PresetType _upgradeHaptic;
        [SerializeField] private HapticPatterns.PresetType _auctionFinishingHaptic;
        [SerializeField] private HapticPatterns.PresetType _tapSpeedUpHaptic;

        public HapticPatterns.PresetType UpgradeHaptic => _upgradeHaptic;
        public HapticPatterns.PresetType AuctionFinishingHaptic => _auctionFinishingHaptic;
        public HapticPatterns.PresetType TapSpeedUpHaptic => _tapSpeedUpHaptic;
    }
}