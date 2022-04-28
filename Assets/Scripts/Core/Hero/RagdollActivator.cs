using System;
using System.Collections;
using Core.Input;
using UnityEngine;

namespace Core.Hero
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _rootBone;
        [SerializeField] private Transform _boss;
        [SerializeField] private Transform _forcePoint;
        public static RagdollActivator Instance;
        public Animator _animator;
        [SerializeField] private float _lerp;
        [SerializeField] private float _power;
        public Rigidbody _mainRigidbody;
        public Rigidbody[] _allRigidbodies;
        public Collider _collider;

        private Vector3[] _cachedBonesPositions;
        private Vector3[] _cachedBonesAngles;

        public bool _isLerping;
        private InputJoystickReceiver _input;

        public void Construct(InputJoystickReceiver input)
        {
            _input = input;
        }

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = true;
            }
        }

        private void LateUpdate()
        {
            if (_isLerping == false)
                return;

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].transform.localPosition = Vector3.Lerp(_allRigidbodies[i].transform.localPosition,
                    _cachedBonesPositions[i], _lerp * Time.deltaTime);

                _allRigidbodies[i].transform.localEulerAngles = Vector3.Lerp(
                    _allRigidbodies[i].transform.localEulerAngles,
                    _cachedBonesAngles[i], _lerp * Time.deltaTime);
            }
        }
        
        [ContextMenu("MakePhysical")]
        public void MakePhysical()
        {
            ActivateRagdollAndPushWithForce(new Vector3(0, 1, -1), _power);
        }

        public void ActivateRagdollAndPushWithForce(Vector3 direction, float force)
        {
            _animator.enabled = false;
            _characterController.enabled = false;

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = false;
                _allRigidbodies[i].AddForceAtPosition(new Vector3(0, 1, -1) * force, _forcePoint.position, ForceMode.Impulse);
            }

            StartCoroutine(ReturnFromRagdollToIdle());
        }

        private IEnumerator ReturnFromRagdollToIdle()
        {
            _cachedBonesPositions = new Vector3[_allRigidbodies.Length];
            _cachedBonesAngles = new Vector3[_allRigidbodies.Length];
            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _cachedBonesPositions[i] = _allRigidbodies[i].transform.localPosition;
                _cachedBonesAngles[i] = _allRigidbodies[i].transform.localEulerAngles;
            }

            yield return new WaitForSeconds(2);

            // var parent = _rootBone.parent;
            // _rootBone.parent = null;
            transform.position = _rootBone.position;
            // _rootBone.SetParent(parent);

            _animator.enabled = true;

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = true;
            }

            _isLerping = true;
            _input.InputOn = true;

            yield return null;
        }
    }
}