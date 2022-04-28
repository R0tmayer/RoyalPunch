using System;
using Core.Input;
using UnityEngine;

namespace Core.Animations
{
    public class HeroAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private InputJoystickReceiver _input;
        private static readonly int _runForward = Animator.StringToHash("RunForward");
        private static readonly int _runBackward = Animator.StringToHash("RunBackward");
        private static readonly int _runLeft = Animator.StringToHash("RunLeft");
        private static readonly int _runRight = Animator.StringToHash("RunRight");
        private static readonly int _idle = Animator.StringToHash("Idle");
        private static readonly int _punching = Animator.StringToHash("Punching");

        public bool IsPunching { get; set; }

        public void Construct(InputJoystickReceiver input)
        {
            _input = input;
        }

        private void Update()
        {
            ResetAnimations();
            
            if(IsPunching)
                _animator.Play(_punching);
            
            if (_input.Direction == Vector2.zero)
            {
                _animator.SetBool(_idle,true);
                return;
            }

            if (Math.Abs(_input.Direction.x) > Math.Abs(_input.Direction.y))
                _animator.SetBool(_input.Direction.x < 0 ? _runRight : _runLeft, true);
            else
                _animator.SetBool(_input.Direction.y < 0 ? _runBackward : _runForward, true);
        }

        private void ResetAnimations()
        {
            _animator.SetBool(_runForward, false);
            _animator.SetBool(_runBackward, false);
            _animator.SetBool(_runLeft, false);
            _animator.SetBool(_runRight, false);
            _animator.SetBool(_idle, false);
            _animator.SetBool(_punching, false);
        }
    }
}