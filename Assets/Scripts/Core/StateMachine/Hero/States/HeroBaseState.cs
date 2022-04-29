using UnityEngine;

namespace Core.StateMachine.Hero.States
{
    public abstract class HeroBaseState
    {
        public abstract void EnterState(HeroStateMachine stateMachine);
        
        public abstract void ExitState(HeroStateMachine stateMachine);
        
        public abstract void UpdateState(HeroStateMachine stateMachine);

        public abstract void OnCollisionEnter(HeroStateMachine stateMachine, Collision collision);
        
        public abstract void OnTriggerExit(HeroStateMachine stateMachine, Collider other);
        
        public abstract void OnTriggerEnter(HeroStateMachine stateMachine, Collider other);
    }
}