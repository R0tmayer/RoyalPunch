using UnityEngine;

namespace Core.StateMachine.HeroSM
{
    public class HeroAnimationStates : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int _yDirection = Animator.StringToHash("YDirection");
        private static readonly int _punching = Animator.StringToHash("Punching");
        private static readonly int xDirection = Animator.StringToHash("XDirection");

        public void SetDirectionXFloat(float value) => _animator.SetFloat(xDirection, value);
        public void SetDirectionYFloat(float value) => _animator.SetFloat(_yDirection, value);
        public void SetPunchingBool(bool enable) => _animator.SetBool(_punching, enable);

        public void EnableAnimator(bool enable) => _animator.enabled = enable;

    }
}