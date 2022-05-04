using Core.StateMachine.Boss;
using UnityEngine;

namespace Core.StateMachine.Hero.States
{
    public class HeroMoveAndPunchState : HeroBaseState
    {
        private HeroAnimations _animations;

        public override void EnterState(HeroStateMachine stateMachine)
        {
            _animations = stateMachine.Animations;
            stateMachine.Input.Enabled = true;
        }

        public override void ExitState(HeroStateMachine stateMachine)
        {
            stateMachine.Input.Enabled = false;
            _animations.SetPunchingBool(false);
        }

        public override void UpdateState(HeroStateMachine stateMachine)
        {
            var heroTransform = stateMachine.Hero.transform;
            var input = stateMachine.Input;
            var speed = GameParameters.Instance.HeroSpeed;

            SetBlendTree();
            Move();

            if (stateMachine.IsMagnetism)
                MoveToBoss();

            void SetBlendTree()
            {
                _animations.SetDirectionYFloat(input.Direction.y);
                _animations.SetDirectionXFloat(input.Direction.y < 0 ? -input.Direction.x : input.Direction.x);
            }

            void Move()
            {
                var movement = Vector3.zero;

                movement += heroTransform.right * input.Direction.x * speed * Time.deltaTime;
                movement += heroTransform.forward * input.Direction.y * speed * Time.deltaTime;

                stateMachine.CharacterController.Move(movement);
            }

            void MoveToBoss()
            {
                var movement = Vector3.zero;

                movement += heroTransform.forward * GameParameters.Instance.MagnetismSpeed * Time.deltaTime;
                stateMachine.CharacterController.Move(movement);
            }
        }

        public override void OnCollisionEnter(HeroStateMachine stateMachine, Collision collision){ }

        public override void OnTriggerExit(HeroStateMachine stateMachine, Collider other)
        {
            if (other.TryGetComponent(out BossStateMachine _))
            {
                _animations.SetPunchingBool(false);
            }
        }

        public override void OnTriggerEnter(HeroStateMachine heroStateMachine, Collider other)
        {
            if (other.TryGetComponent(out BossStateMachine _))
            {
                _animations.SetPunchingBool(true);
            }
        }
    }
}