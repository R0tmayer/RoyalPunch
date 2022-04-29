using Core.StateMachine.HeroSM;
using UnityEngine;

namespace Core.StateMachine.BossSM.States
{
    public class BossIdleState : BossBassState
    {
        private BossAnimations _animations;

        public override void EnterState(BossStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            _animations.SetIdleBool(true);
            stateMachine.LookAtTarget.Enabled = true;
        }

        public override void ExitState(BossStateMachine stateMachine)
        {
            _animations.SetIdleBool(false);
        }

        public override void UpdateState(BossStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnter(BossStateMachine stateMachine, Collision collision)
        {
        }

        public override void OnTriggerExit(BossStateMachine stateMachine, Collider other)
        {
            
        }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other)
        {
            if (other.TryGetComponent(out HeroStateMachine _))
            {
                stateMachine.SetPunchState();
            }
        }

        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other)
        {
        }
    }
}