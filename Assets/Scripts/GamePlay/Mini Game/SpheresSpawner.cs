using UnityEngine;
using System.Collections;
using Zenject;
using UnityEngine.UIElements;

[AddComponentMenu("Custom/SpheresSpawner(������ ��������� ����)")]
public class SpheresSpawner : MonoBehaviour
{
    [Inject]
    private readonly DiContainer _container;

    [SerializeField] private GameObject _spherePrefab;
    private BoxCollider _spawnCollider;

    Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCollider = GetComponent<BoxCollider>();
        StartSpawning();
    }

    /// <summary>
    /// ������ ������������� ������ �������.
    /// </summary>
    public void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnSpheres());
        
    }

    /// <summary>
    /// ��������� ������������� ������ �������.
    /// </summary>
    public void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
    }

    /// <summary>
    /// ������� ����� � ���������� � 3 �������.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnSpheres()
    {
        while (true)
        {
            Vector3 spawnPos = GetRandomPositionInsideCollider();
            _container.InstantiatePrefab(_spherePrefab, spawnPos, Quaternion.identity, null);
            // Instantiate(_spherePrefab, spawnPos, Quaternion.identity); ��� ������, ����� ����� �� ������� ����������� ProgressListener.
            yield return new WaitForSeconds(4f);
        }
    }

    /// <summary>
    /// �������� ��������� �������, ������ ����.
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
