using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    Rigidbody rb;
    float force = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        force = Random.Range(20, 30);

        float angle = Random.Range(45, 135);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sqrt(1 - x * x);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);

        Destroy(gameObject, 10);
    }

}
