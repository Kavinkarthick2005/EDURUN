using UnityEngine;
using UnityEngine.UI;


public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5);
    }
}
