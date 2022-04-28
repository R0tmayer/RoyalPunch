using System;
using System.Collections;
using Core.Input;
using UnityEngine;

namespace Core.Hero
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField] private Transform _rootBone;
        [SerializeField] private Transform _boss;
        public static RagdollActivator Instance;
        public Animator _animator;
        public float _lerp;
        public Rigidbody _mainRigidbody;
        public Rigidbody[] AllRigidbodies;
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

            for (int i = 0; i < AllRigidbodies.Length; i++)
            {
                AllRigidbodies[i].isKinematic = true;
            }
        }

        private void LateUpdate()
        {
            if (_isLerping == false)
                return;

            for (int i = 0; i < AllRigidbodies.Length; i++)
            {
                AllRigidbodies[i].transform.localPosition = Vector3.Lerp(AllRigidbodies[i].transform.localPosition,
                    _cachedBonesPositions[i], _lerp * Time.deltaTime);

                AllRigidbodies[i].transform.localEulerAngles = Vector3.Lerp(
                    AllRigidbodies[i].transform.localEulerAngles,
                    _cachedBonesAngles[i], _lerp * Time.deltaTime);
            }
        }

        [ContextMenu("MakePhysical")]
        public void ActivateRagdollAndPushWithForce(float force)
        {
            // _mainRigidbody.AddForce(_boss.transform.forward * force, ForceMode.Impulse);

            _animator.enabled = false;
            _collider.gameObject.SetActive(false);
            _input.InputOn = false;

            for (int i = 0; i < AllRigidbodies.Length; i++)
            {
                AllRigidbodies[i].isKinematic = false;
            }

            StartCoroutine(ReturnFromRagdollToIdle());
        }

        private IEnumerator ReturnFromRagdollToIdle()
        {
            _cachedBonesPositions = new Vector3[AllRigidbodies.Length];
            _cachedBonesAngles = new Vector3[AllRigidbodies.Length];
            for (int i = 0; i < AllRigidbodies.Length; i++)
            {
                _cachedBonesPositions[i] = AllRigidbodies[i].transform.localPosition;
                _cachedBonesAngles[i] = AllRigidbodies[i].transform.localEulerAngles;
            }

            yield return new WaitForSeconds(2);

            // var parent = _rootBone.parent;
            // _rootBone.parent = null;
            transform.position = _rootBone.position;
            // _rootBone.SetParent(parent);

            _animator.enabled = true;

            for (int i = 0; i < AllRigidbodies.Length; i++)
            {
                AllRigidbodies[i].isKinematic = true;
            }

            _isLerping = true;
            _input.InputOn = true;

            yield return null;
        }
    }
}