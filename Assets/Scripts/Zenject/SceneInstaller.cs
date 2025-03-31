using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Tooltip("������� �������.")]
    [SerializeField] private SpheresSpawner spheresSpawner;

    [Tooltip("������.")]
    [SerializeField] private Camera cameraMain;

    [Tooltip("���������� ���������.")]
    [SerializeField] private ProgressListener progressListener;

    [Tooltip("������ �������� ������.")]
    [SerializeField] private PanelEnabler panelEnabler;

    public override void InstallBindings()
    {
        // ���������, ��� SpheresSpawner ����� ����� � ��� �� �������� �� ���� ����.
        Container.Bind<SpheresSpawner>().FromInstance(spheresSpawner).AsSingle();

        Container.Bind<Camera>().FromInstance(cameraMain).AsSingle();
        Container.Bind<ProgressListener>().FromInstance(progressListener).AsSingle();
        Container.Bind<PanelEnabler>().FromInstance(panelEnabler).AsSingle();
    }
}


/*
 � ���� ��� �� � ���� ��� ����������� ������ SpheresSpawner, �� ���������� ����� ���������:
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject] private SpheresSpawner spheresSpawner;

    private void Start()
    {
        Debug.Log("spheresSpawner �������: " + spheresSpawner.name);
    }
}
 */