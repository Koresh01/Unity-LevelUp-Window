using UnityEngine;
using UnityEngine.UI;
using Zenject;

[AddComponentMenu("Custom/LevelUpPanelView(Обработчик нажатий на кнопки)")]
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
        // начисление ресурсов
        panelEnabler.Close();
    }

    void OnGet2X()
    {
        // показ рекламы
        // начисление 2х * ресурсов
        panelEnabler.Close();
    }
}
