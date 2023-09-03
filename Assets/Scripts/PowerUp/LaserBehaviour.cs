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
    [SerializeField]
    private float powerUpDuration;

    private InputAction actionInput;
    private PaddleControls controls;

    private bool isActive = false;
    private float durationTimer;


    void Awake()
    {
        controls = new PaddleControls();
        actionInput = controls.Gameplay.Action;
    }

    void Update()
    {
        if (!isActive) return;

        durationTimer += Time.deltaTime;
        if (durationTimer > powerUpDuration)
        {
            OnLaserDisabled();
        }
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
        durationTimer = 0f;
        isActive = true;
    }

    public void OnLaserDisabled()
    {
        actionInput.Disable();
        durationTimer = 0f;
        isActive = false;
    }

    public void OnInputAction(InputAction.CallbackContext context)
    {
        Instantiate(bullet, rightWeapon.position, Quaternion.identity);
        Instantiate(bullet, leftWeapon.position, Quaternion.identity);
    }
}
