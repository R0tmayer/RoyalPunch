using Core;
using Core.CustomInput;
using Core.StateMachine.Boss;
using Core.StateMachine.Hero;
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
        [SerializeField] private HeroStateMachine _heroStateMachine;
        [SerializeField] private RagdollActivator _ragdollActivator;
        [SerializeField] private BossAnimations _bossAnimations;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<StatLevelSaver>()
                .RegisterIfNotNull(_upgradesConfig)
                .RegisterIfNotNull(_ragdollActivator)
                .RegisterIfNotNull(_heroStateMachine)
                .RegisterIfNotNull(_bossAnimations)
                .RegisterIfNotNull(_inputJoystickReceiver);
        }
    }
}