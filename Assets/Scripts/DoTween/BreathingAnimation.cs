using UnityEngine;
using DG.Tweening;

[AddComponentMenu("UI Effects/Breathing Animation")]
public class BreathingAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float animationDuration = 1f;

    private void Start()
    {
        AnimateBreathingEffect();
    }

    private void AnimateBreathingEffect()
    {
        targetTransform
            .DOScale(scaleFactor, animationDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
