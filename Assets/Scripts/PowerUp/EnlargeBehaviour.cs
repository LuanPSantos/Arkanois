using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnlargeBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float enlargeFactor = 1.4f;
    [SerializeField]
    private float powerUpDuration;
    private Vector3 originalSize;
    private Vector3 enlargedSize;
    private bool isGrowing = false;
    private bool isActive = false;
    private float durationTimer;
    void Start()
    {
        originalSize = transform.localScale;
        enlargedSize = new Vector3(originalSize.x * enlargeFactor, originalSize.y, originalSize.z);
    }

    private void Update()
    {
        if (isGrowing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, enlargedSize, speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalSize, speed * Time.deltaTime);
        }

        if (!isActive) return;

        durationTimer += Time.deltaTime;
        if (durationTimer > powerUpDuration)
        {
            OnElargeDisabled();
        }

    }

    public void OnElargeEnabled()
    {
        isGrowing = true;
        isActive = true;
        durationTimer = 0;
    }

    public void OnElargeDisabled()
    {
        isGrowing = false;
        isActive = false;
        durationTimer = 0;
    }
}
