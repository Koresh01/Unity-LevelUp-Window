using UnityEngine;
using UnityEngine.UI;
using Zenject;

[AddComponentMenu("Custom/LevelUpPanelView(���������� ������� �� ������)")]
public class PanelView : MonoBehaviour 
{
    [Inject]
    PanelEnabler panelEnabler;

    [SerializeField] Button get1X;
    [SerializeField] Button get2X;

    private void OnEnable()
    {
        get1X.onClick.AddListener(OnGet1X);
        get2X.onClick.AddListener(OnGet2X);
    }

    private void OnDisable()
    {
        get1X.onClick.RemoveAllListeners();
        get2X.onClick.RemoveAllListeners();
    }

    void OnGet1X()
    {
        // ���������� ��������
        panelEnabler.Close();
    }

    void OnGet2X()
    {
        // ����� �������
        // ���������� 2� * ��������
        panelEnabler.Close();
    }
}
