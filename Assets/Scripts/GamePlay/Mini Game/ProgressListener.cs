using System.Collections.Generic;
using UnityEngine;
using Zenject;

[AddComponentMenu("Custom/ProgressListener(Контроллер прогресса)")]
public class ProgressListener : MonoBehaviour 
{
    [Inject]
    SpheresSpawner spheresSpawner;
    [Inject]
    PanelEnabler panelEnabler;

    [Tooltip("Текущий score.")]
    [SerializeField] int progress = 0;

    [Tooltip("Текущий LVL.")]
    public int Level = 0;

    [Tooltip("Порог каждого уровня.")]
    [SerializeField] List<int> levelsPrice;
    


    /// <summary>
    /// Инкремент прогресса.
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
