using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    public Vector2 startPosition;
    void Start()
    {
        transform.position = startPosition;
    }
}
