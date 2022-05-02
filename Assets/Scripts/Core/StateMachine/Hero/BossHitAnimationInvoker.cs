using Core.StateMachine.Boss;
using Core.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.StateMachine.Hero
{
    public class BossHitAnimationInvoker : MonoBehaviour
    {
        [SerializeField] private DamageInfoArea _damageInfoArea;
        [SerializeField] private Image _hitImageLeft;
        [SerializeField] private Image _hitImageRight;
        [SerializeField] private float _hitImageDuration;
        [SerializeField] private Ease _hitImageEase;
        
        private BossAnimations _bossAnimations;

        public void Construct(BossAnimations bossAnimations)
        {
            _bossAnimations = bossAnimations;
        }
        
        public void HitBossAnimationLeft() // animation event
        {
            _bossAnimations.SetHitTrigger();
            _damageInfoArea.ShowNewText();
            _hitImageLeft.DOFade(1, 0.1f).OnComplete(() => _hitImageLeft.DOFade(0, 0.1f));
        }

        public void HitBossAnimationRight() // animation event
        {
            _bossAnimations.SetHitTrigger();
            _damageInfoArea.ShowNewText();
            _hitImageRight.DOFade(1, _hitImageDuration)
                .SetEase(_hitImageEase)
                .OnComplete(() => _hitImageRight.DOFade(0, _hitImageDuration).SetEase(_hitImageEase));
        }
    }
}