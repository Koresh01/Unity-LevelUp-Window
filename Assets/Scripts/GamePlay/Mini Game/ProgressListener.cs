using UnityEngine;

[AddComponentMenu("Custom/ProgressListener(Контроллер прогресса)")]
public class ProgressListener : MonoBehaviour 
{
    [SerializeField] int progress = 0;

    /// <summary>
    /// Инкремент прогресса.
    /// </summary>
    public void IncProgress()
    {
        progress++;
    }
}
