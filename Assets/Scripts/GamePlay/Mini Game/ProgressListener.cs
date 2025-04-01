using System.Collections.Generic;
using UnityEngine;
using Zenject;

[AddComponentMenu("Custom/ProgressListener(���������� ���������)")]
public class ProgressListener : MonoBehaviour 
{
    [Inject]
    SpheresSpawner spheresSpawner;
    [Inject]
    PanelEnabler panelEnabler;

    [Tooltip("������� score.")]
    [SerializeField] int progress = 0;

    [Tooltip("������� LVL.")]
    public int Level = 0;

    [Tooltip("����� ������� ������.")]
    [SerializeField] List<int> levelsPrice;
    


    /// <summary>
    /// ��������� ���������.
    /// </summary>
    public void IncProgress()
    {
        progress++;
        HandleProgress();
    }

    void HandleProgress()
    {
        int cumulativeSum = 0;
        for (int lvl = 0; lvl < levelsPrice.Count; lvl++)
        {
            if (progress == cumulativeSum)
            {
                UpgradeLevel(lvl);
            }
            cumulativeSum += levelsPrice[lvl];
        }
    }

    void UpgradeLevel(int newLvL)
    {
        Level = newLvL;
        panelEnabler.Show();
    }
}
