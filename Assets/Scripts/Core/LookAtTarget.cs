using System;
using Core.Hero;
using UnityEngine;

namespace Core
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        public bool IsLooking { get; set; } = true;

        private void Update()
        {
            if (IsLooking)
                transform.LookAt(_target);
        }
    }
}