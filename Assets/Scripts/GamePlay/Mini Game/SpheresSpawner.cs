using UnityEngine;
using System.Collections;
using Zenject;
using UnityEngine.UIElements;

[AddComponentMenu("Custom/SpheresSpawner(Логика появления сфер)")]
public class SpheresSpawner : MonoBehaviour
{
    [Inject]
    private readonly DiContainer _container;

    [Inject]
    SoundManager _soundManager;

    [SerializeField] private GameObject _spherePrefab;

    [Tooltip("Текущая сфера")]
    [SerializeField] private GameObject _curSphere;

    [Tooltip("Область спавна шариков.")]
    private BoxCollider _spawnCollider;

    Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCollider = GetComponent<BoxCollider>();
        StartSpawning();
    }

    /// <summary>
    /// Запуск интервального спавна шариков.
    /// </summary>
    public void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnSpheres());
        
    }

    /// <summary>
    /// Остановка интервального спавна шариков.
    /// </summary>
    public void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
    }


    private IEnumerator SpawnSpheres()
    {
        while (true)  // Цикл будет продолжаться, пока объект не удален.
        {
            if (_curSphere == null)  // Проверка на то, что текущий шарик удален.
            {
                yield return new WaitForSeconds(0.2f);  // Задержка перед спавном нового шарика.

                _soundManager.PlayButtonClick();

                Vector3 spawnPos = GetRandomPositionInsideCollider();

                // Не через Instantiate!!!
                _curSphere = _container.InstantiatePrefab(_spherePrefab, spawnPos, Quaternion.identity, null);
            }

            yield return null;  // Переход к следующему кадру.
        }
    }

    /// <summary>
    /// Получает рандомную позицию, внутри куба.
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPositionInsideCollider()
    {
        Vector3 center = _spawnCollider.bounds.center;
        Vector3 size = _spawnCollider.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);
        float randomZ = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }
}
