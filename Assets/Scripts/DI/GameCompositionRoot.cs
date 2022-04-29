using Core;
using Core.BossSkills;
using Core.CustomInput;
using Core.Hero;
using Core.Upgrades;
using DELTation.DIFramework;
using DELTation.DIFramework.Containers;
using UnityEngine;

namespace DI
{
    public sealed class GameCompositionRoot : DependencyContainerBase
    {
        [SerializeField] private UpgradesConfig _upgradesConfig;
        [SerializeField] private InputJoystickReceiver _inputJoystickReceiver;
        [SerializeField] private BossMagnetism _bossMagnetism;
        [SerializeField] private RagdollActivator _ragdollActivator;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<StatLevelSaver>()
                .RegisterIfNotNull(_upgradesConfig)
                .RegisterIfNotNull(_bossMagnetism)
                .RegisterIfNotNull(_ragdollActivator)
                .RegisterIfNotNull(_inputJoystickReceiver);
        }
    }
}