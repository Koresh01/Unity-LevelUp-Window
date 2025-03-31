using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/(Логика появления сфер)")]
public class SpheresSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    private BoxCollider _spawnCollider;

    private void Start()
    {
        _spawnCollider = GetComponent<BoxCollider>();
        StartCoroutine(SpawnSpheres());
    }


    /// <summary>
    /// Спавнит сферы с интервалом в 3 секунды.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnSpheres()
    {
        while (true)
        {
            Vector3 spawnPos = GetRandomPositionInsideCollider();
            Instantiate(_spherePrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(3f);
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
