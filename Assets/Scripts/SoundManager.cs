using UnityEngine;

/// <summary>
/// Singleton-����� ��� ���������� ������� � ����.
/// ��������� �������������� ��������� �����, ����� ��� ��������� �����, ������� ������ � �. �.
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("Sound Clips")]
    [SerializeField] private AudioClip placeBlockSound; // ���� ��������� ������
    [SerializeField] private AudioClip buttonClickSound; // ���� ������� ������
    [SerializeField] private AudioClip moveErrorSound; // ���� ������ �����������/��������
    [SerializeField] private AudioClip clearLayerSound; // ���� �������� ����
    [SerializeField] private AudioClip moveRotateSound; // ���� ��������/�������� ������

    [SerializeField] private AudioSource audioSource; // �������� �����

    private void Awake()
    {
        // ���� AudioSource �� �������� ����� ���������, ������� ��� ����������
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// ������������� ���� ��������� ������.
    /// </summary>
    public void PlayPlaceBlock() => PlaySound(placeBlockSound);

    /// <summary>
    /// ������������� ���� ������� ������.
    /// </summary>
    public void PlayButtonClick() => PlaySound(buttonClickSound);

    /// <summary>
    /// ������������� ���� ������ ����������� ��� �������� ������.
    /// </summary>
    public void PlayMoveError() => PlaySound(moveErrorSound);

    /// <summary>
    /// ������������� ���� �������� ����.
    /// </summary>
    public void PlayClearLayer() => PlaySound(clearLayerSound);

    /// <summary>
    /// ������������� ���� �������� ��� �������� ������.
    /// </summary>
    public void PlayMoveRotate() => PlaySound(moveRotateSound);

    /// <summary>
    /// ������������� ���������� ����, ���� �� �� null.
    /// </summary>
    /// <param name="clip">���������, ������� ����� �������������.</param>
    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip); // ������������ ����� ��� ���������� ��������
        }
    }
}
