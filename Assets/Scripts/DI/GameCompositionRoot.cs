using Core;
using Core.Animations;
using Core.BossSkills;
using Core.Hero;
using Core.Input;
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
        [SerializeField] private HeroAnimations _heroAnimations;
        [SerializeField] private BossAnimations _bossAnimations;
        [SerializeField] private ColliderChecker _colliderChecker;
        [SerializeField] private BossMagnetism _bossMagnetism;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<StatLevelSaver>()
                .RegisterIfNotNull(_upgradesConfig)
                .RegisterIfNotNull(_heroAnimations)
                .RegisterIfNotNull(_colliderChecker)
                .RegisterIfNotNull(_bossAnimations)
                .RegisterIfNotNull(_bossMagnetism)
                .RegisterIfNotNull(_inputJoystickReceiver);
        }
    }
}