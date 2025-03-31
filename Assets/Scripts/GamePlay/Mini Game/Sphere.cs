using UnityEngine;
using System.Collections;
using Zenject;

[AddComponentMenu("Custom/Sphere(������ �����)")]
public class Sphere : MonoBehaviour
{
    [Inject]
    ProgressListener progressListener;

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

        isVisible = false; // ������ ������ �� �����
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

        isVisible = true; // ������ ������ �����
    }

    /// <summary>
    /// ���������������
    /// </summary>
    public void SelfDestruction()
    {
        StopAllCoroutines();
        StartCoroutine(DestroyAfterDissolve());
        progressListener.IncProgress();
    }

    private IEnumerator DestroyAfterDissolve()
    {
        yield return StartCoroutine(HideObject()); // ���������� ���������� �������
        Destroy(gameObject); // ������� ������
    }
}
