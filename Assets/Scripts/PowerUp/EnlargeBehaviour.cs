using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnlargeBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    private Vector3 originalSize;
    private Vector3 enlargedSize;
    private bool isGrowing = false;
    void Start()
    {
        originalSize = transform.localScale;
        enlargedSize = new Vector3(originalSize.x * 2, originalSize.y, originalSize.z);
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

    }

    public void OnElargeEnabled()
    {
        isGrowing = true;
    }

    public void OnElargeDisabled()
    {
        isGrowing = false;
    }
}
