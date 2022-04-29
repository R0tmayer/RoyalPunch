using UnityEngine;

namespace Core.StateMachine.Hero.States
{
    public class HeroFallState : HeroBaseState
    {
        public override void EnterState(HeroStateMachine stateMachine)
        {
            stateMachine.CharacterController.enabled = false;
            stateMachine.Animations.EnableAnimator(false);
        }

        public override void ExitState(HeroStateMachine stateMachine){ }

        public override void UpdateState(HeroStateMachine stateMachine){ }

        public override void OnCollisionEnter(HeroStateMachine stateMachine, Collision collision){ }

        public override void OnTriggerExit(HeroStateMachine stateMachine, Collider other){ }

        public override void OnTriggerEnter(HeroStateMachine stateMachine, Collider other){ }
    }
}