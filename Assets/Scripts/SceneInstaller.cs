using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Tooltip("������� �������.")]
    [SerializeField] private SpheresSpawner spheresSpawner;

    [Tooltip("������.")]
    [SerializeField] private Camera cameraMain;

    public override void InstallBindings()
    {
        // ���������, ��� SpheresSpawner ����� ����� � ��� �� �������� �� ���� ����.
        Container.Bind<SpheresSpawner>().FromInstance(spheresSpawner).AsSingle();

        Container.Bind<Camera>().FromInstance(cameraMain).AsSingle();
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