using UnityEngine;

namespace Core.StateMachine.BossSM.States
{
    public class BossFallState : BossBassState
    {
        public override void EnterState(BossStateMachine bossStateMachine)
        {
            
        }

        public override void ExitState(BossStateMachine bossStateMachine)
        {
        }

        public override void UpdateState(BossStateMachine bossStateMachine)
        {
        }

        public override void OnCollisionEnter(BossStateMachine bossStateMachine, Collision collision)
        {
        }

        public override void OnTriggerExit(BossStateMachine bossStateMachine, Collider other)
        {
        }

        public override void OnTriggerStay(BossStateMachine stateMachine, Collider other)
        {
        }

        public override void OnTriggerEnter(BossStateMachine stateMachine, Collider other)
        {
        }
    }
}