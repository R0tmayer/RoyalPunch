using System;
using Core.Animations;
using Core.BossSkills;
using Core.Hero;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class BossCollision : MonoBehaviour
    {
        private ColliderChecker _colliderChecker;
        private HeroAnimations _heroAnimations;
        private BossAnimations _bossAnimations;
        private BossMagnetism _bossMagnetism;

        public void Construct(ColliderChecker colliderChecker, HeroAnimations heroAnimations,
            BossAnimations bossAnimations, BossMagnetism bossMagnetism)
        {
            _bossMagnetism = bossMagnetism;
            _bossAnimations = bossAnimations;
            _heroAnimations = heroAnimations;
            _colliderChecker = colliderChecker;
        }

        private void OnEnable()
        {
            _colliderChecker.BossCollisionEntered += StartPunching;
            _colliderChecker.BossCollisionEntered += _bossMagnetism.StopMagnetism;
            _colliderChecker.BossCollisionExited += StopPunching;
        }

        private void OnDisable()
        {
            _colliderChecker.BossCollisionEntered -= StartPunching;
            _colliderChecker.BossCollisionEntered -= _bossMagnetism.StopMagnetism;
            _colliderChecker.BossCollisionExited -= StopPunching;
        }

        private void StartPunching()
        {
            _heroAnimations.IsPunching = true;

            if (_bossAnimations.BossState == BossStates.Magnetism)
                _bossAnimations.SuperPunch();
            else
                _bossAnimations.IsPunching = true;
        }

        private void StopPunching()
        {
            _heroAnimations.IsPunching = false;
            _bossAnimations.IsPunching = false;
        }
    }
}