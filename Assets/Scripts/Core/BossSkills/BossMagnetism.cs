using System;
using System.Collections;
using Core.Hero;
using UnityEngine;

namespace Core.BossSkills
{
    public class BossMagnetism : MonoBehaviour
    {
        [SerializeField] private Movement _heroMovement;
        [SerializeField] private float _magnetismSpeed;
        public static BossMagnetism Instance;

        private IEnumerator _coroutine;
        private BossAnimations _bossAnimations;

        public void Construct(BossAnimations bossAnimations)
        {
            _bossAnimations = bossAnimations;
        }

        private void Awake()
        {
            Instance = this;
        }

        [ContextMenu("StartMagnetism")]
        public void StartMagnetism()
        {
            _bossAnimations.IsMagnetism = true;
            _bossAnimations.BossState = BossStates.Magnetism;

            if (_coroutine == null)
            {
                _coroutine = PullCoroutine();
                StartCoroutine(_coroutine);
            }
        }

        public void StopMagnetism()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            _bossAnimations.IsMagnetism = false;
        }

        private IEnumerator PullCoroutine()
        {
            while (true)
            {
                _heroMovement.MoveToBossWithSpeed(_magnetismSpeed);
                yield return null;
            }
        }
    }
}