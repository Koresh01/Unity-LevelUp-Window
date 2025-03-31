using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom Sphere/(Логика сферы)")]
public class Sphere : MonoBehaviour
{
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private float dissolveDuration = 1.5f;

    private Material material;
    private bool isVisible = false;

    private void Start()
    {
        material = objectRenderer.material;
        StartCoroutine(ShowObject());
    }

    public IEnumerator ShowObject()
    {
        float startValue = material.GetFloat("_dissolve");
        float time = 0;

        while (time < dissolveDuration)
        {
            time += Time.deltaTime;
            float dissolveValue = Mathf.Lerp(startValue, 0, time / dissolveDuration);
            material.SetFloat("_dissolve", dissolveValue);
            yield return null;
        }

        isVisible = false; // Теперь объект НЕ виден
    }

    public IEnumerator HideObject()
    {
        float startValue = material.GetFloat("_dissolve");
        float time = 0;

        while (time < dissolveDuration)
        {
            time += Time.deltaTime;
            float dissolveValue = Mathf.Lerp(startValue, 1, time / dissolveDuration);
            material.SetFloat("_dissolve", dissolveValue);
            yield return null;
        }

        isVisible = true; // Теперь объект ВИДЕН
    }

    /// <summary>
    /// Самоуничтожение
    /// </summary>
    public void SelfDestruction()
    {
        StopAllCoroutines();
        StartCoroutine(DestroyAfterDissolve());
    }

    private IEnumerator DestroyAfterDissolve()
    {
        yield return StartCoroutine(HideObject()); // Дожидаемся завершения скрытия
        Destroy(gameObject); // Удаляем объект
    }
}
