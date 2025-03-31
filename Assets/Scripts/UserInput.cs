using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

/// <summary>
/// ���� �� ������������, ���������� ����� ������� ����� Unity.
/// </summary>
public class UserInput : MonoBehaviour
{
    [Inject]
    Camera cam;
    
    private InputActions _inputActions;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.SpheresPicker.Pick.performed += OnPick;  // performed ����������� ��� ���������� ��������
    }

    private void OnDisable()
    {
        _inputActions.SpheresPicker.Pick.performed -= OnPick;
        _inputActions.Disable();
    }

    private void OnPick(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Vector2 screenHitPos = GetInputPosition(context);
        Ray ray = cam.ScreenPointToRay(screenHitPos);

        int layerMask = ~LayerMask.GetMask("Spawner"); // ���������� ���� "Spawner"

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Debug.Log("��� ���������� � �����������: " + hit.collider.name);
            Sphere sphere = hit.collider.GetComponent<Sphere>();

            if (sphere != null)
            {
                sphere.SelfDestruction();
            }
        }
    }


    private Vector2 GetInputPosition(InputAction.CallbackContext context)
    {
        // ���� ���� ��� �� ����
        if (Mouse.current != null)
        {
            return Mouse.current.position.ReadValue();
        }

        // ���� ���� ��� �� ���������
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            return Touchscreen.current.primaryTouch.position.ReadValue();
        }

        return Vector2.zero;
    }
}
