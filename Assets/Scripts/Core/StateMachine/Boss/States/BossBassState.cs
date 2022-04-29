using UnityEngine;

namespace Core.StateMachine.Boss.States
{
    public abstract class BossBassState
    {
        #region Execution

        public abstract void EnterState(BossStateMachine stateMachine);

        public abstract void ExitState(BossStateMachine stateMachine);

        public abstract void UpdateState(BossStateMachine stateMachine);

        public abstract void OnCollisionEnter(BossStateMachine stateMachine, Collision collision);

        public abstract void OnTriggerExit(BossStateMachine stateMachine, Collider other);
        public abstract void OnTriggerStay(BossStateMachine stateMachine, Collider other);

        public abstract void OnTriggerEnter(BossStateMachine stateMachine, Collider other);

        #endregion
    }
}