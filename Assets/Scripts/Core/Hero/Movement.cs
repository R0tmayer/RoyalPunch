using System;
using Core.Input;
using UnityEngine;

namespace Core.Hero
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;

        private InputJoystickReceiver _input;

        public void Construct(InputJoystickReceiver input)
        {
            _input = input;
        }

        private void Update()
        { 
            var movement = Vector3.zero;
            
            movement += transform.right * _input.Direction.x * _speed * Time.deltaTime;
            movement += transform.forward * _input.Direction.y * _speed * Time.deltaTime;

            _characterController.Move(movement);
        }

        public void MoveToBossWithSpeed(float speed)
        {
            var movement = Vector3.zero;

            movement += transform.forward * speed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }
}