using UnityEngine;

public class magnetScript : MonoBehaviour
{
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        rotateTowardsPlayer();
    }

    void rotateTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        float d = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);

        if (direction.x >= 0 && direction.y >= 0)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(direction.y / d) * Mathf.Rad2Deg *-1);
        if (direction.x > 0 && direction.y < 0)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(direction.y / d) * Mathf.Rad2Deg *-1);
        if (direction.x < 0 && direction.y > 0)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(direction.y / d) * Mathf.Rad2Deg);
        if (direction.x <= 0 && direction.y <= 0)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(direction.y / d) * Mathf.Rad2Deg);

    }
}
