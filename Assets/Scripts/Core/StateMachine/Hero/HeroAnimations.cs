using UnityEngine;

namespace Core.StateMachine.Hero
{
    public class HeroAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int _xDirection = Animator.StringToHash("XDirection");
        private static readonly int _yDirection = Animator.StringToHash("YDirection");
        private static readonly int _punching = Animator.StringToHash("Punching");

        public void SetDirectionXFloat(float value) => _animator.SetFloat(_xDirection, value);
        public void SetDirectionYFloat(float value) => _animator.SetFloat(_yDirection, value);
        public void SetPunchingBool(bool enable) => _animator.SetBool(_punching, enable);

        public void EnableAnimator(bool enable) => _animator.enabled = enable;

    }
}