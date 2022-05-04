using System;
using UnityEngine;

namespace Core
{
    public class GameParameters : MonoBehaviour
    {
        public static GameParameters Instance;

        [field: SerializeField] public float HeroSpeed { get; private set; }
        [field: SerializeField] public float MagnetismSpeed { get; private set; }
        [field: SerializeField] public float ConeAngleToHero { get; private set; }
        [field: SerializeField] public float ConeDistance { get; private set;}
        [field: SerializeField] public float CircleDistance { get; private set;}
        [field: SerializeField] public float RagdollSleepTime { get; private set;}
        [field: SerializeField] public float PushForce { get; private set;}
        [field: SerializeField] public float UseSkillPeriod { get; private set;}
        [field: SerializeField] public float StandUpLerpRate { get; private set;}

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
        }
    }
}