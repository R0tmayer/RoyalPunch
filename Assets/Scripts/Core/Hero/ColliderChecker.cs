using System;
using Core.BossSkills;
using UnityEngine;

namespace Core.Hero
{
    public class ColliderChecker : MonoBehaviour
    {
        public event Action BossCollisionEntered;
        public event Action BossCollisionExited;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BossAnimations _))
                BossCollisionEntered?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BossAnimations _))
                BossCollisionExited?.Invoke();
        }
    }
}