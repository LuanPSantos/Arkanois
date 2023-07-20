using UnityEngine;
using UnityEngine.InputSystem;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform rightWeapon;
    [SerializeField]
    private Transform leftWeapon;

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

    public void OnLaserEnabled()
    {
        actionInput.Enable();
    }

    public void OnLaserDisabled()
    {
        actionInput.Disable();
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        Instantiate(bullet, rightWeapon.position, Quaternion.identity);
        Instantiate(bullet, leftWeapon.position, Quaternion.identity);
    }
}
