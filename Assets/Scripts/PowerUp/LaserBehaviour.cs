using UnityEngine;
using UnityEngine.InputSystem;

public class LaserBehaviour : MonoBehaviour
{
    private InputAction actionInput;
    private PaddleControls controls;

    void Awake()
    {
        controls = new PaddleControls();
        actionInput = controls.Gameplay.Action;
    }

    void OnEnable()
    {
        actionInput.performed += OnInputAction;
    }

    void OnDisable()
    {
        actionInput.performed -= OnInputAction;
    }

    public void OnEnableLaser()
    {
        actionInput.Enable();
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        Debug.Log("------------------");
    }
}
