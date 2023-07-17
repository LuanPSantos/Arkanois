using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnlargeBehaviour : MonoBehaviour
{
    private Vector3 originalSize;
    private Vector3 enlargedSize;
    void Start()
    {
        originalSize = transform.localScale;
        enlargedSize = new Vector3(originalSize.x * 2, originalSize.y, originalSize.z);
    }
    public void OnElargeEnabled()
    {
        transform.localScale = enlargedSize;
    }

    public void OnElargeDisabled()
    {
        transform.localScale = originalSize;
    }
}
