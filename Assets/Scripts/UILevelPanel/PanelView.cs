using UnityEngine;
using UnityEngine.UI;
using Zenject;

[AddComponentMenu("Custom/LevelUpPanelView(Обработчик нажатий на кнопки)")]
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
        // начисление ресурсов
        resourcesListener.AddCurrency(MyResources.Coins, 5);
        resourcesListener.AddCurrency(MyResources.TimeBender, 5);
        resourcesListener.AddCurrency(MyResources.DepositOverride, 5);
        // Закрытие панели
        panelEnabler.Close();

        _soundManager.PlayButtonClick();
    }

    void OnGet2X()
    {
        // показ рекламы...

        // начисление 2х * ресурсов
        resourcesListener.AddCurrency(MyResources.Coins, 10);
        resourcesListener.AddCurrency(MyResources.TimeBender, 10);
        resourcesListener.AddCurrency(MyResources.DepositOverride, 10);
        //закрытие панели
        panelEnabler.Close();

        _soundManager.PlayButtonClick();
    }
}
