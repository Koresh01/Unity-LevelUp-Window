using UnityEngine;

[AddComponentMenu("Custom/ProgressListener(���������� ���������)")]
public class ProgressListener : MonoBehaviour 
{
    [SerializeField] int progress = 0;

    /// <summary>
    /// ��������� ���������.
    /// </summary>
    public void IncProgress()
    {
        progress++;
    }
}
