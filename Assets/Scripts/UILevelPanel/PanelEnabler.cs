using UnityEngine;
using System.Collections;
using DG.Tweening;
using Zenject;
using TMPro;

[AddComponentMenu("Custom/PanelEnabler(���������� ���+����)")]
public class PanelEnabler : MonoBehaviour
{
    [Inject]
    SpheresSpawner spheresSpawner;

    [Inject]
    ProgressListener progressListener;

    [Tooltip("Text ������� �������.")]
    [SerializeField] TextMeshProUGUI curLevel;

    [Tooltip("Rect ���� ��������.")]
    [SerializeField] RectTransform rectTransform;

    /// <summary>
    /// ���������� ������ � ��������� ���������
    /// </summary>
    public void Show()
    {
        // ���������� �������� ������:
        spheresSpawner.StopSpawning();


        gameObject.SetActive(true);

        // ���������� ����� �������� ������:
        curLevel.text = $"- LEVEL {progressListener.Level} -";

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

        // ����� ���������� �������� ������:
        spheresSpawner.StartSpawning();
    }
}
