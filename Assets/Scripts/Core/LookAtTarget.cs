using System;
using UnityEngine;

namespace Core
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public bool Enabled { get; set; } = true;

        private void Update()
        {
            if (Enabled)
                transform.LookAt(_target);
        }
    }
}