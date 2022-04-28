using System;
using System.Collections;
using Core.BossSkills;
using Core.Hero;
using UnityEngine;

namespace Core.Animations
{
    public class BossAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _timeToReturnIdleState;
        [SerializeField] private BossSuperCone _bossSuperCone;
        
        [SerializeField] private float _angleToHero;
        [SerializeField] private float _distanceToHero;

        private static readonly int _idle = Animator.StringToHash("idle");
        private static readonly int _punching = Animator.StringToHash("Punching");
        private static readonly int _magnetism = Animator.StringToHash("Magnetism");
        private static readonly int _superPunch = Animator.StringToHash("SuperPunch");
        private static readonly int _superCone = Animator.StringToHash("SuperCone");
        private HeroAnimations _heroAnimations;

        public BossStates BossState { get; set; }
        public bool IsPunching { get; set; }
        public bool IsMagnetism { get; set; }

        public void Construct(HeroAnimations heroAnimations)
        {
            _heroAnimations = heroAnimations;
        }

        private void Awake()
        {
            BossState = BossStates.Idle;
        }

        private void Update()
        {
            ResetAnimations();

            if (IsPunching)
            {
                BossState = BossStates.Punching;
                _animator.SetBool(_punching, true);
            }

            if (IsMagnetism)
            {
                BossState = BossStates.Magnetism;
                _animator.SetBool(_magnetism, true);
            }
        }

        public void SuperPunch()
        {
            ResetAnimations();
            _animator.SetTrigger(_superPunch);
            PushHero();
            StartCoroutine(SetIdleStateAfterTime());
        }

        public void SuperConeAnimation()
        {
            _animator.SetTrigger(_superCone);
        }

        private void PushHero()
        {
            RagdollActivator.Instance.ActivateRagdollAndPushWithForce(2);
            _heroAnimations.IsPunching = false;
        }

        public void PushHeroIfAngleAndDistanceLessThan()
        {
            // Carefully animation event exist
            
            print("Angle to hero = " + _bossSuperCone.AngleToHero);
            print("Angle to hero = " + _bossSuperCone.DistanceToHero);

            if (_bossSuperCone.AngleToHero < _angleToHero && _bossSuperCone.DistanceToHero < _distanceToHero)
            {
                PushHero();
            }
        }

        private IEnumerator SetIdleStateAfterTime()
        {
            yield return new WaitForSeconds(_timeToReturnIdleState);

            if (_heroAnimations.IsPunching)
            {
                BossState = BossStates.Punching;
                IsPunching = true;
            }
        }

        private void ResetAnimations()
        {
            _animator.SetBool(_punching, false);
            _animator.SetBool(_magnetism, false);
        }
    }
}