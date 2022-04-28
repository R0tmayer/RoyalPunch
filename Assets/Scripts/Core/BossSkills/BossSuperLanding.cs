using Core.Animations;
using UnityEngine;

namespace Core.BossSkills
{
    public class BossSuperLanding : MonoBehaviour
    {
        [SerializeField] private LookAtTarget _lookAtTarget;
        [SerializeField] private GameObject _cone;
        private BossAnimations _bossAnimations;
        private HeroAnimations _heroAnimations;
        private static readonly int _farPlane = Shader.PropertyToID("_FarPlane");
        private MeshRenderer _meshRenderer;
    }
}