using System.Collections;
using Core.Animations;
using Core.Hero;
using UnityEngine;

namespace Core.BossSkills
{
    public class BossMagnetism : MonoBehaviour
    {
        [SerializeField] private Movement _heroMovement;
        [SerializeField] private float _magnetismSpeed;

        private IEnumerator _coroutine;
        private BossAnimations _bossAnimations;

        public void Construct(BossAnimations bossAnimations)
        {
            _bossAnimations = bossAnimations;
        }

        [ContextMenu("StartMagnetism")]
        private void StartMagnetism()
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