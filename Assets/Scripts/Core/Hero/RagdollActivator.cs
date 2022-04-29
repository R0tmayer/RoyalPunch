using System;
using System.Collections;
using Core.CustomInput;
using UnityEngine;

namespace Core.Hero
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _rootBone;
        [SerializeField] private Transform _forcePoint;
        public static RagdollActivator Instance;
        public Animator _animator;
        public Rigidbody[] _allRigidbodies;

        private Vector3[] _cachedBonesPositions;
        private Vector3[] _cachedBonesAngles;

        public bool _isLerping;
        private InputJoystickReceiver _input;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else if(Instance == this)
            {
                Destroy(gameObject);
            }

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
                    _cachedBonesPositions[i], GameParameters.Instance.StandUpLeprRate * Time.deltaTime);

                _allRigidbodies[i].transform.localEulerAngles = Vector3.Lerp(
                    _allRigidbodies[i].transform.localEulerAngles,
                    _cachedBonesAngles[i], GameParameters.Instance.StandUpLeprRate * Time.deltaTime);
            }
        }

        [ContextMenu("MakePhysical")]
        public void MakePhysical()
        {
            ActivateRagdollAndPushWithForce(-transform.forward, GameParameters.Instance.PushPower);
        }

        public void ActivateRagdollAndPushWithForce(Vector3 direction, float force)
        {
            _cachedBonesPositions = new Vector3[_allRigidbodies.Length];
            _cachedBonesAngles = new Vector3[_allRigidbodies.Length];

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _cachedBonesPositions[i] = _allRigidbodies[i].transform.localPosition;
                _cachedBonesAngles[i] = _allRigidbodies[i].transform.localEulerAngles;
            }

            _animator.enabled = false;
            _characterController.enabled = false;

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = false;
                _allRigidbodies[i].AddForceAtPosition(direction * force, _forcePoint.position, ForceMode.Impulse);
            }

            StartCoroutine(ReturnFromRagdollToIdle());
        }

        private IEnumerator ReturnFromRagdollToIdle()
        {
            yield return new WaitForSeconds(GameParameters.Instance.RagdollSleepTime);


            // var fallenBonesPositions = new Vector3[_allRigidbodies.Length];
            // var fallenBonesAngles = new Vector3[_allRigidbodies.Length];
            //
            // for (int i = 0; i < _allRigidbodies.Length; i++)
            // {
            //     fallenBonesPositions[i] = _allRigidbodies[i].transform.position;
            //     fallenBonesAngles[i] = _allRigidbodies[i].transform.eulerAngles;
            // }

            transform.position = _rootBone.position;
            //
            // for (int i = 0; i < _allRigidbodies.Length; i++)
            // {
            //     _allRigidbodies[i].transform.position = fallenBonesPositions[i];
            //     _allRigidbodies[i].transform.eulerAngles = fallenBonesAngles[i];
            // }

            for (int i = 0; i < _allRigidbodies.Length; i++)
            {
                _allRigidbodies[i].isKinematic = true;
            }

            _animator.enabled = true;
            _characterController.enabled = true;
            _input.Enabled = true;
            // _isLerping = true;
            
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);


            yield return null;
        }
    }
}