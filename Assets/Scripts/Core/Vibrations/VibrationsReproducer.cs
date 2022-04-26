using Lofelt.NiceVibrations;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

namespace Core.Vibrations
{
    public class VibrationsReproducer
    {
        private const string VibrationsPrefsKey = nameof(VibrationsPrefsKey);

        public bool Enabled
        {
            get => PlayerPrefs.GetInt(VibrationsPrefsKey, 1) == 1;
            set => PlayerPrefs.SetInt(VibrationsPrefsKey, value ? 1 : 0);
        }

        public void TryPlayHaptic(HapticPatterns.PresetType hapticPreset)
        {
            if (Enabled)
                HapticPatterns.PlayPreset(hapticPreset);
        }
    }
}