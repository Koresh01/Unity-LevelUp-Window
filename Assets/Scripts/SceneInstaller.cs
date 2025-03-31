using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    //[SerializeField] private Player player;

    public override void InstallBindings()
    {
        // Привязываем переданные объекты
        //Container.BindInstance(player).AsSingle();
    }
}
/*
 И если где то в коде мне понадобится скрипт Player, то достаточно будет прописать:
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject] private Player _player;

    private void Start()
    {
        Debug.Log("Player получен: " + _player.name);
    }
}
 */