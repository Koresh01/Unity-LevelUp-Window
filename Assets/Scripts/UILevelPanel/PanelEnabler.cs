using UnityEngine;
using DG.Tweening;

[AddComponentMenu("Custom/PanelEnabler(Контроллер вкл+выкл)")]
public class PanelEnabler : MonoBehaviour
{
    [Tooltip("Rect всей панельки.")]
    [SerializeField] RectTransform rectTransform;

    /// <summary>
    /// Отобразить панель с анимацией появления
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);

        // Устанавливаем начальный scale = 0
        rectTransform.localScale = Vector3.zero;

        // Запускаем анимацию увеличения scale до нормального значения (1,1,1)
        rectTransform.DOScale(Vector3.one, 1f); // 1f - время анимации, можно настроить
    }

    /// <summary>
    /// Выключить панель левел-UP
    /// </summary>
    public void Close()
    {
        // Устанавливаем начальный scale
        rectTransform.localScale = Vector3.one;

        // Запускаем анимацию уменьшения scale до минимального значения
        rectTransform.DOScale(Vector3.zero, 0.7f) // 1f - время анимации
            .OnComplete(() => gameObject.SetActive(false)); // Выключаем объект после завершения анимации
    }
}
