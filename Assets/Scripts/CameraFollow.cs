using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Smooth Settings")]
    [SerializeField] private float smoothTime = 0.15f;

    [Header("Offset")]
    [SerializeField] private Vector2 offset;

    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {

        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z
        );

        transform.position = Vector3.SmoothDamp
        (
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
        if (target.position.x < -2)
        {
            transform.position = new Vector3 (-2, target.position.y,transform.position.z);
        }
    }
}
