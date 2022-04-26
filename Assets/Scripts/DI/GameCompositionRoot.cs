using Core.Upgrades;
using Core.Vibrations;
using DELTation.DIFramework;
using DELTation.DIFramework.Containers;
using UnityEngine;

namespace DI
{
    public sealed class GameCompositionRoot : DependencyContainerBase
    {
        [SerializeField] private VibrationsConfig vibrationsVibrationsConfig;
        [SerializeField] private UpgradesConfig upgradesUpgradesConfig;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<VibrationsReproducer>()
                .Register<StatLevelSaver>()
                .RegisterIfNotNull(vibrationsVibrationsConfig)
                .RegisterIfNotNull(upgradesUpgradesConfig);
        }
    }
}