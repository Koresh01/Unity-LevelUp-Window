using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelAnimation : MonoBehaviour
{
    [SerializeField] private Image targetImage;

    private void Start()
    {
        RotateImage();
    }

    private void RotateImage()
    {
        targetImage.rectTransform
            .DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
