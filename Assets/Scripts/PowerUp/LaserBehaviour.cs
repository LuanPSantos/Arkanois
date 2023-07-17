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
    public void OnLaserEnabled()
    {
        actionInput.performed += OnInputAction;
        actionInput.Enable();
    }

    public void OnLaserDisabled()
    {
        actionInput.performed -= OnInputAction;
        actionInput.Disable();
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        Instantiate(bullet, rightWeapon.position, Quaternion.identity);
        Instantiate(bullet, leftWeapon.position, Quaternion.identity);
    }
}
