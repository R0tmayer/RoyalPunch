using UnityEngine;

namespace Core.StateMachine.Boss
{
    public class BossAnimations : MonoBehaviour
    {
        [SerializeField] private Animator Animator;
        
        private static readonly int _idle = Animator.StringToHash("Idle");
        private static readonly int _punching = Animator.StringToHash("Punching");
        private static readonly int _landing = Animator.StringToHash("Landing");
        private static readonly int _cone = Animator.StringToHash("Cone");
        private static readonly int _magnetism = Animator.StringToHash("Magnetism");
        private static readonly int _superPunch = Animator.StringToHash("SuperPunch");
        private static readonly int _hit = Animator.StringToHash("Hit");

        public void SetIdleBool(bool enable) => Animator.SetBool(_idle, enable);
        public void SetPunchBool(bool enable) => Animator.SetBool(_punching, enable);
        public void SetLandingBool(bool enable) => Animator.SetBool(_landing, enable);
        public void SetConeBool(bool enable) => Animator.SetBool(_cone, enable);
        public void SetMagnetismBool(bool enable) => Animator.SetBool(_magnetism, enable);
        public void SetSuperPunchBool(bool enable) => Animator.SetBool(_superPunch, enable);
        public void SetHitTrigger() => Animator.SetTrigger(_hit);
    }
}