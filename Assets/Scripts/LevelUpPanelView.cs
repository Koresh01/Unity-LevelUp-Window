using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Custom/LevelUpPanelView(������ �������� ������)")]
public class LevelUpPanelView : MonoBehaviour 
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
