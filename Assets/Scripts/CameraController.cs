using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 20f;

    [SerializeField]
    private bool smoothFollow = true;

    [SerializeField]
    private GameObject targetToFollow;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - targetToFollow.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = targetToFollow.transform.position + offset;
        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                newPosition,
                movementSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = newPosition;
        }
    }
}
