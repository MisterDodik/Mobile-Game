using UnityEngine;

public class MovingWallMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 10);

        if (transform.position.x > 0)
            moveSpeed *= -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;

        position.x += moveSpeed;
        transform.position = position;
    }
}
