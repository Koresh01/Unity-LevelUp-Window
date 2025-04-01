using UnityEngine;
using UnityEngine.UI;
using Zenject;

[AddComponentMenu("Custom/LevelUpPanelView(���������� ������� �� ������)")]
public class PanelView : MonoBehaviour 
{
    [Inject]
    PanelEnabler panelEnabler;
    [Inject]
    ResourcesListener resourcesListener;
    [Inject]
    SoundManager _soundManager;

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
        resourcesListener.AddCurrency(MyResources.Coins, 5);
        resourcesListener.AddCurrency(MyResources.TimeBender, 5);
        resourcesListener.AddCurrency(MyResources.DepositOverride, 5);
        // �������� ������
        panelEnabler.Close();

        _soundManager.PlayButtonClick();
    }

    void OnGet2X()
    {
        // ����� �������...

        // ���������� 2� * ��������
        resourcesListener.AddCurrency(MyResources.Coins, 10);
        resourcesListener.AddCurrency(MyResources.TimeBender, 10);
        resourcesListener.AddCurrency(MyResources.DepositOverride, 10);
        //�������� ������
        panelEnabler.Close();

        _soundManager.PlayButtonClick();
    }
}
