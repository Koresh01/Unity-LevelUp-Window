using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //[SerializeField] private Player player;

    public override void InstallBindings()
    {
        // ����������� ���������� �������
        //Container.BindInstance(player).AsSingle();
    }
}
/*
 � ���� ��� �� � ���� ��� ����������� ������ Player, �� ���������� ����� ���������:
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject] private Player _player;

    private void Start()
    {
        Debug.Log("Player �������: " + _player.name);
    }
}
 */