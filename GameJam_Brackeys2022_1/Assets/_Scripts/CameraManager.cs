using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [Range(1, 10)] [SerializeField] float lerpSpeed;


    void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 LerpPosition = Vector2.Lerp(transform.position, target.position, lerpSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(LerpPosition.x, LerpPosition.y, -10);
    }
}
