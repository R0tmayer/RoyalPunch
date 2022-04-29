using UnityEngine;

namespace Core.StateMachine.Boss.States
{
    public class BossPunchState : BossBassState
    {
        private BossAnimations _animations;
        
        public override void EnterState(BossStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            _animations.SetPunchBool(true);
            stateMachine.LookAtTarget.Enabled = true;
        }

        public override void ExitState(BossStateMachine stateMachine)
        {
            _animations.SetPunchBool(false);
        }

        public override void UpdateState(BossStateMachine stateMachine){ }
        public override void OnCollisionEnter(BossStateMachine stateMachine, Collision collision){ }

        public override void OnTriggerExit(BossStateMachine stateMachine, Collider other)
        {
            stateMachine.SetIdleState();
        }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other){ }
        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other){ }
    }
}