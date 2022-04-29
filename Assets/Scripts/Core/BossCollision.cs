using System;
using Core.BossSkills;
using Core.Hero;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class BossCollision : MonoBehaviour
    {
        // private BossMagnetism _bossMagnetism;
        //
        // public void Construct( BossMagnetism bossMagnetism)
        // {
        //     _bossMagnetism = bossMagnetism;
        // }

        private void OnEnable()
        {
            // _colliderChecker.BossCollisionEntered += StartPunching;
            // _colliderChecker.BossCollisionEntered += _bossMagnetism.StopMagnetism;
            // _colliderChecker.BossCollisionExited += StopPunching;
        }

        private void OnDisable()
        {
            // _colliderChecker.BossCollisionEntered -= StartPunching;
            // _colliderChecker.BossCollisionEntered -= _bossMagnetism.StopMagnetism;
            // _colliderChecker.BossCollisionExited -= StopPunching;
        }

        // private void StartPunching()
        // {
        //     _heroAnimations.IsPunching = true;
        //
        //     if (_bossAnimations.BossState == BossStates.Magnetism)
        //         _bossAnimations.SuperPunch();
        //     else
        //         _bossAnimations.IsPunching = true;
        // }
        //
        // private void StopPunching()
        // {
        //     _heroAnimations.IsPunching = false;
        //     _bossAnimations.IsPunching = false;
        // }
    }
}