using UnityEngine;
using UnityEngine.InputSystem;

public class Orbit : MonoBehaviour
{
    [Header("Object to rotate")]
    [SerializeField] private Transform target;

    [Header("Input Action Reference")]
    [SerializeField] private InputActionReference lookAction;

    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 100f;

    private bool isDragging = false;

    private void OnEnable()
    {
        if (lookAction != null)
            lookAction.action.actionMap.Enable();
    }

    private void OnDisable()
    {
        if (lookAction != null)
            lookAction.action.Disable();
    }

    void Update()
    {
        if (isDragging && lookAction != null && lookAction.action != null)
        {
            Vector2 delta = lookAction.action.ReadValue<Vector2>();
            float rotationY = delta.x * rotationSpeed * Time.deltaTime;
            target.Rotate(Vector3.up, -rotationY, Space.World);
        }
    }

    public void StartDrag() => isDragging = true;
    public void StopDrag() => isDragging = false;
}
