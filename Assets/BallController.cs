using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;

    public float force = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    Vector3 direction = Vector3.zero;
    private void FixedUpdate()
    {
        if (direction != Vector3.zero)
        {
            rb.AddForce(direction * force, ForceMode.Force);
        }
    }

    public void onTilt(Vector3 input)
    {
        direction.x = input.y;
    }

    public void onKeyBoard(Vector3 input)
    {
        direction.x = input.x;
    }
}
