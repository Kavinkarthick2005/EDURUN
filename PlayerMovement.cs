using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool Movement;
    public float speed = 5f;
    public float laneDistance = 2.5f;
    private int lane = 1; // 0 = left, 1 = center, 2 = right
    public float jumpForce = 7f;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 0)
        {
            lane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 2)
        {
            lane++;
        }

        Vector3 targetPosition = transform.position;
        targetPosition.x = lane * laneDistance - laneDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
