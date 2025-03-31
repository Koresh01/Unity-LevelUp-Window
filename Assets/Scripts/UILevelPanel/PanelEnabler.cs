using UnityEngine;
using DG.Tweening;

[AddComponentMenu("Custom/PanelEnabler(���������� ���+����)")]
public class PanelEnabler : MonoBehaviour
{
    [Tooltip("Rect ���� ��������.")]
    [SerializeField] RectTransform rectTransform;

    /// <summary>
    /// ���������� ������ � ��������� ���������
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);

        // ������������� ��������� scale = 0
        rectTransform.localScale = Vector3.zero;

        // ��������� �������� ���������� scale �� ����������� �������� (1,1,1)
        rectTransform.DOScale(Vector3.one, 1f); // 1f - ����� ��������, ����� ���������
    }

    /// <summary>
    /// ��������� ������ �����-UP
    /// </summary>
    public void Close()
    {
        // ������������� ��������� scale
        rectTransform.localScale = Vector3.one;

        // ��������� �������� ���������� scale �� ������������ ��������
        rectTransform.DOScale(Vector3.zero, 0.7f) // 1f - ����� ��������
            .OnComplete(() => gameObject.SetActive(false)); // ��������� ������ ����� ���������� ��������
    }
}
